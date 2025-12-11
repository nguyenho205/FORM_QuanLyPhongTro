using laptrinhNet.Database;
using laptrinhNet.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet.ControlKhachhang
{

    public partial class hdongKhachhang : UserControl
    {
        public hdongKhachhang()
        {
            InitializeComponent();
        }
        private KhachHang _currKhachHang;
        private void hdongKhachhang_Load(object sender, EventArgs e)
        {

            string currentUser = DangNhap.NguoiDungHienTai;

            if (!string.IsNullOrEmpty(currentUser) && currentUser.ToUpper().StartsWith("KH"))
            {
                using (var db = new QLPhongTroDataContext())
                {
                    var kh = db.KhachHangs.FirstOrDefault(k => k.MaKH == currentUser);

                    if (kh != null)
                    {
                        SetKhachHang(kh);
                    }
                }
            }
        }
        public void SetKhachHang(KhachHang kh) // 'kh' chỉ sống trong hàm này
        {
            _currKhachHang = kh; // Lưu 'kh' vào biến toàn cục '_currKhachHang' để dùng sau này

            if (kh != null)
            {
                using (var db = new QLPhongTroDataContext())
                {
                    // Lấy hợp đồng mới nhất
                    var hopDongInfo = (from h in db.HopDongs
                                       join p in db.PhongTros on h.MaPhong equals p.MaPhong
                                       join l in db.LoaiPhongTros on p.MaLoai equals l.MaLoai
                                       join k in db.KhachHangs on h.MaKH equals k.MaKH
                                       where h.MaKH == kh.MaKH && h.TrangThai != "Hủy"
                                       orderby h.NgayKT descending
                                       select new
                                       {
                                           h.MaHopDong,
                                           h.MaPhong,
                                           h.NgayBD,
                                           h.NgayKT,
                                           h.TienCoc,
                                           TenPhong = p.TenPhong,
                                           TenKH = k.TenKH,
                                           TienPhong = l.GiaPhong
                                       }).FirstOrDefault();

                    if (hopDongInfo != null)
                    {
                        txtMaHD.Text = hopDongInfo.MaHopDong;
                        txtSophong.Text = hopDongInfo.TenPhong;
                        txtTenKH.Text = hopDongInfo.TenKH;

                        CultureInfo cul = new CultureInfo("vi-VN");
                        txtCoc.Text = hopDongInfo.TienCoc?.ToString("N0", cul) ?? "0";
                        txtTienphong.Text = hopDongInfo.TienPhong?.ToString("N0", cul) ?? "0";

                        Tungay.Value = hopDongInfo.NgayBD ?? DateTime.Now;
                        Denngay.Value = hopDongInfo.NgayKT ?? DateTime.Now;
                    }
                    else
                    {
                        ClearData();
                    }
                }
            }
        }
        private void ClearData()
        {
            txtMaHD.Text = "";
            txtSophong.Text = "";
            txtTenKH.Text = "";
            txtCoc.Text = "";
            txtTienphong.Text = "";
            Tungay.Value = DateTime.Now;
            Denngay.Value = DateTime.Now;
        }
     
        private void GuiYeuCauHoTro(string maKH, string noiDung)
        {
            using (var db = new QLPhongTroDataContext())
            {
                // 1. Kiểm tra spam (tránh gửi trùng nội dung khi chưa xử lý)
                bool daGui = db.YeuCauHoTros.Any(y => y.MaKH == maKH
                                                   && y.NoiDung == noiDung
                                                   && y.TrangThai == "Chưa xử lý");
                if (daGui)
                {
                    MessageBox.Show("Yêu cầu này đã được gửi trước đó và đang chờ xử lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 2. Sinh mã tự động (YCxxx)
                var lastRequest = db.YeuCauHoTros.OrderByDescending(x => x.MaYeuCau).FirstOrDefault();
                string newMaYC = "YC001";

                if (lastRequest != null)
                {
                    string numberPart = lastRequest.MaYeuCau.Substring(2); // Lấy phần số sau chữ YC
                    if (int.TryParse(numberPart, out int number))
                    {
                        number++;
                        newMaYC = "YC" + number.ToString("D3");
                    }
                }

                // 3. Tạo record mới
                YeuCauHoTro yc = new YeuCauHoTro();
                yc.MaYeuCau = newMaYC;
                yc.MaKH = maKH;
                yc.NgayGui = DateTime.Now;
                yc.NoiDung = noiDung;
                yc.TrangThai = "Chưa xử lý";
                yc.MaNV_XuLy = null;
                yc.NgayXuLy = null;
                yc.PhanHoi = "";

                try
                {
                    db.YeuCauHoTros.Add(yc);

                    db.SaveChanges();

                    MessageBox.Show($"Đã gửi yêu cầu thành công!\nMã phiếu: {newMaYC}\nNội dung: {noiDung}\n\nVui lòng chờ nhân viên xác nhận.", "Thành công");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                }
            }
        }

        private void btnGiahan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text)) return;

            DateTime ngayMoi = Denngay.Value.AddMonths(3);
            Denngay.Value = ngayMoi;

            var confirm = MessageBox.Show($"Gửi yêu cầu gia hạn đến {ngayMoi:dd/MM/yyyy}?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string noiDung = $"Yêu cầu gia hạn HĐ {txtMaHD.Text} thêm 3 tháng.";

                // Lấy mã KH an toàn
                string maKH = _currKhachHang?.MaKH;
                if (string.IsNullOrEmpty(maKH))
                {
                    using (var db = new QLPhongTroDataContext())
                    {
                        var hd = db.HopDongs.FirstOrDefault(h => h.MaHopDong == txtMaHD.Text);
                        maKH = hd?.MaKH;
                    }
                }

                GuiYeuCauHoTro(maKH, noiDung);
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text)) return;

            string maKH = "";
            DateTime ngayKetThuc;

            using (var db = new QLPhongTroDataContext())
            {
                var hd = db.HopDongs.FirstOrDefault(h => h.MaHopDong == txtMaHD.Text);
                if (hd == null) return;

                maKH = hd.MaKH;
                ngayKetThuc = hd.NgayKT ?? DateTime.Now;
            }

            DateTime today = DateTime.Now;
            string noiDung = "";

            if (today < ngayKetThuc)
            {
                if (MessageBox.Show("Hủy trước hạn sẽ bị phạt. Tiếp tục?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    noiDung = $"Yêu cầu hủy HĐ {txtMaHD.Text} TRƯỚC HẠN. Chấp nhận phạt.";
                    GuiYeuCauHoTro(maKH, noiDung);
                }
            }
            else
            {
                if (MessageBox.Show("Gửi yêu cầu thanh lý hợp đồng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    noiDung = $"Yêu cầu thanh lý HĐ {txtMaHD.Text} ĐÃ ĐÁO HẠN.";
                    GuiYeuCauHoTro(maKH, noiDung);
                }
            }
        }
    }
}



