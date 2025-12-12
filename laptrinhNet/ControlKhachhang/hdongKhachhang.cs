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
            txtSophong.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtCoc.ReadOnly = true;
            txtTienphong.ReadOnly = true;

            // DatePicker: Không có ReadOnly nên phải dùng Enabled = false
            Tungay.Enabled = false;
            Denngay.Enabled = false;
            txtTenKH.Enabled = false;
            txtCoc.Enabled = false;
            txtSophong.Enabled = false; 
            

            // Đảm bảo ComboBox vẫn chọn được
            cboMaHD.Enabled = true;
        }
        public void SetKhachHang(KhachHang kh) // 'kh' chỉ sống trong hàm này
        {

            _currKhachHang = kh; // Lưu biến toàn cục

            if (kh != null)
            {
                using (var db = new QLPhongTroDataContext())
                {
                    // Lấy danh sách TẤT CẢ mã hợp đồng của khách này
                    var listMaHD = db.HopDongs
                                        .Where(h => h.MaKH == kh.MaKH && h.TrangThai != "Hủy")
                                        .OrderByDescending(h => h.NgayBD)
                                        .Select(h => h.MaHopDong)
                                        .ToList();

                    // Đổ vào ComboBox
                    // Khi gán DataSource, sự kiện SelectedIndexChanged sẽ tự chạy để load chi tiết HĐ đầu tiên
                    cboMaHD.DataSource = listMaHD;

                    if (listMaHD.Count == 0) ClearData();
                }
            }
        }
        private void ClearData()
        {
            cboMaHD.Text = "";
            txtSophong.Text = "";
            txtTenKH.Text = "";
            txtCoc.Text = "";
            txtTienphong.Text = "";
            Tungay.Value = DateTime.Now;
            Denngay.Value = DateTime.Now;
        }
        private void LoadChiTietHopDong(string maHD)
        {
            if (string.IsNullOrEmpty(maHD)) return;

            using (var db = new QLPhongTroDataContext())
            {
                // Copy logic query cũ vào đây, thêm điều kiện 'where h.MaHopDong == maHD'
                var hopDongInfo = (from h in db.HopDongs
                                   join p in db.PhongTros on h.MaPhong equals p.MaPhong
                                   join l in db.LoaiPhongTros on p.MaLoai equals l.MaLoai
                                   join k in db.KhachHangs on h.MaKH equals k.MaKH
                                   where h.MaHopDong == maHD // <--- Quan trọng: Lọc theo mã được chọn
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
                    txtSophong.Text = hopDongInfo.TenPhong;
                    txtTenKH.Text = hopDongInfo.TenKH;

                    CultureInfo cul = new CultureInfo("vi-VN");
                    txtCoc.Text = hopDongInfo.TienCoc?.ToString("N0", cul) ?? "0";
                    txtTienphong.Text = hopDongInfo.TienPhong?.ToString("N0", cul) ?? "0";

                    Tungay.Value = hopDongInfo.NgayBD ?? DateTime.Now;
                    Denngay.Value = hopDongInfo.NgayKT ?? DateTime.Now;
                }
            }
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

                }
            }
        }

        private void btnGiahan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboMaHD.Text)) return;

            // Tính ngày dự kiến để hiện thông báo (cộng thêm 3 tháng)
            DateTime ngayMoi = Denngay.Value.AddMonths(3);

            // Hiện hộp thoại xác nhận
            var confirm = MessageBox.Show($"Gửi yêu cầu gia hạn HĐ {cboMaHD.Text} đến ngày {ngayMoi:dd/MM/yyyy}?",
                                          "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Tạo nội dung gửi đi (Sử dụng cboMaHD.Text)
                string noiDung = $"Yêu cầu gia hạn HĐ {cboMaHD.Text} thêm 3 tháng.";

                // Lấy mã khách hàng (Ưu tiên lấy từ biến toàn cục, nếu lỗi thì query lại từ DB)
                string maKH = _currKhachHang?.MaKH;

                if (string.IsNullOrEmpty(maKH))
                {
                    using (var db = new QLPhongTroDataContext())
                    {
                        // Tìm hợp đồng dựa trên mã trong ComboBox
                        var hd = db.HopDongs.FirstOrDefault(h => h.MaHopDong == cboMaHD.Text);
                        maKH = hd?.MaKH;
                    }
                }

                // Gọi hàm gửi yêu cầu nếu đã có mã KH
                if (!string.IsNullOrEmpty(maKH))
                {
                    GuiYeuCauHoTro(maKH, noiDung);
                }
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboMaHD.Text)) return;

            string maKH = "";
            DateTime ngayKetThuc;

            // Lấy thông tin ngày kết thúc thực tế từ Database để so sánh
            using (var db = new QLPhongTroDataContext())
            {
                // Tìm hợp đồng dựa trên mã trong ComboBox
                var hd = db.HopDongs.FirstOrDefault(h => h.MaHopDong == cboMaHD.Text);

                if (hd == null) return; // Nếu không tìm thấy thì thoát

                maKH = hd.MaKH;
                ngayKetThuc = hd.NgayKT ?? DateTime.Now;
            }

            DateTime today = DateTime.Now;
            string noiDung = "";

            // Logic kiểm tra: Hủy trước hạn hay Thanh lý đúng hạn
            if (today < ngayKetThuc)
            {
                // Trường hợp chưa hết hạn -> Cảnh báo phạt
                if (MessageBox.Show("Hủy trước hạn hợp đồng sẽ bị phạt cọc.\nBạn có chắc chắn muốn tiếp tục?",
                                    "Cảnh báo hủy trước hạn", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    noiDung = $"Yêu cầu hủy HĐ {cboMaHD.Text} TRƯỚC HẠN. Chấp nhận chịu phạt.";
                    GuiYeuCauHoTro(maKH, noiDung);
                }
            }
            else
            {
                // Trường hợp đã hết hạn -> Hỏi thanh lý
                if (MessageBox.Show("Hợp đồng đã đáo hạn. Bạn muốn gửi yêu cầu thanh lý?",
                                    "Xác nhận thanh lý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    noiDung = $"Yêu cầu thanh lý HĐ {cboMaHD.Text} ĐÃ ĐÁO HẠN.";
                    GuiYeuCauHoTro(maKH, noiDung);
                }
            }
        }

        private void cboMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maHD = cboMaHD.SelectedValue?.ToString() ?? cboMaHD.Text;
            LoadChiTietHopDong(maHD);
        }
    }
}



