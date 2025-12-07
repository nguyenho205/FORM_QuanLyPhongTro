using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using laptrinhNet.Database;
using laptrinhNet.Database.Entities;
using Excel = Microsoft.Office.Interop.Excel;

namespace laptrinhNet.ControlNhanvien
{
    public partial class hdon_ttoanNhanvien : UserControl
    {
        QLPhongTroDataContext db;
        // Biến lưu giá dịch vụ lấy từ DB
        private decimal Gia_Dien = 0;
        private decimal Gia_Nuoc = 0;
        private decimal Gia_Wifi = 0;

        // Biến lưu Mã dịch vụ (để lưu vào CT_HOADON)
        private string MaDV_Dien = "DV01"; // Mặc định theo ảnh bạn gửi
        private string MaDV_Nuoc = "DV02";
        private string MaDV_Wifi = "DV03";
        public hdon_ttoanNhanvien()
        {
            InitializeComponent();
            try
            {
                if (!string.IsNullOrEmpty(Session.ConnectionString))
                {
                    db = new QLPhongTroDataContext(Session.ConnectionString);
                }
                else
                {
                    db = new QLPhongTroDataContext();
                }
            }
            catch
            {
                db = new QLPhongTroDataContext();
            }
        }


        private void hdon_ttoanNhanvien_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachPhong();
                LoadGiaDichVu();

                txtDienDaDung.TextChanged += TinhTienTuDong;
                txtNuocDaDung.TextChanged += TinhTienTuDong;
                txtTienPhong.TextChanged += TinhTongTien;
                txtTienWifi.TextChanged += TinhTongTien;
                txtTienDien.TextChanged += TinhTongTien;
                txtTienNuoc.TextChanged += TinhTongTien;

                // Tự động sinh mã hóa đơn ngay khi mở form
                TaoMaHoaDonTuDong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi động: " + ex.Message);
            }
        }

        // --- HÀM QUAN TRỌNG: SINH MÃ TỰ ĐỘNG ---
        void TaoMaHoaDonTuDong()
        {
            try
            {
                // 1. Lấy hóa đơn có mã lớn nhất hiện tại trong Database
                // (OrderByDescending để lấy cái mới nhất)
                var lastHD = db.HoaDons.OrderByDescending(x => x.MaHD).FirstOrDefault();

                if (lastHD == null)
                {
                    // Trường hợp 1: Database chưa có gì hết -> Bắt đầu là HD001
                    txtMaHoaDon.Text = "HD001";
                }
                else
                {
                    // Trường hợp 2: Đã có mã cũ (Ví dụ: HD005)
                    string maCu = lastHD.MaHD;

                    // Cắt bỏ 2 ký tự đầu ("HD") để lấy phần số ("005")
                    // Lưu ý: Mã trong DB phải chuẩn định dạng HDxxx mới chạy được nhé
                    string phanSo = maCu.Substring(2);

                    int soMoi = 0;
                    if (int.TryParse(phanSo, out soMoi))
                    {
                        soMoi = soMoi + 1; // Cộng thêm 1 (5 -> 6)

                        // Format "D3" nghĩa là đảm bảo đủ 3 chữ số (6 -> "006", 10 -> "010")
                        txtMaHoaDon.Text = "HD" + soMoi.ToString("D3");
                    }
                    else
                    {
                        // Nếu mã cũ bị lỗi format lạ (ví dụ "HDAAA") -> Reset về HD001
                        txtMaHoaDon.Text = "HD001";
                    }
                }
            }
            catch (Exception)
            {
                // Gặp lỗi bất kỳ thì mặc định về HD001 cho an toàn
                txtMaHoaDon.Text = "HD001";
            }
        }

        // --- 1. LẤY GIÁ DỊCH VỤ TỪ DATABASE ---
        void LoadGiaDichVu()
        {
            // Lấy giá Điện (DV01)
            var dvDien = db.DichVus.FirstOrDefault(d => d.MaDV == MaDV_Dien);
            if (dvDien != null) Gia_Dien = dvDien.DonGia ?? 0;

            // Lấy giá Nước (DV02)
            var dvNuoc = db.DichVus.FirstOrDefault(d => d.MaDV == MaDV_Nuoc);
            if (dvNuoc != null) Gia_Nuoc = dvNuoc.DonGia ?? 0;

            // Lấy giá Wifi (DV03)
            var dvWifi = db.DichVus.FirstOrDefault(d => d.MaDV == MaDV_Wifi);
            if (dvWifi != null)
            {
                Gia_Wifi = dvWifi.DonGia ?? 0;
                txtTienWifi.Text = Gia_Wifi.ToString("0.##"); // Điền luôn tiền wifi cố định
            }
        }

        void LoadDanhSachPhong()
        {
            var listPhong = db.PhongTros.ToList();
            cbbSoPhong.DataSource = listPhong;
            cbbSoPhong.DisplayMember = "TenPhong";
            cbbSoPhong.ValueMember = "MaPhong";
            cbbSoPhong.SelectedIndex = -1;
        }

        // --- 2. XỬ LÝ KHI CHỌN PHÒNG ---
        private void cbbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSoPhong.SelectedIndex == -1 || cbbSoPhong.SelectedValue == null) return;

            string maPhong = "";
            if (cbbSoPhong.SelectedValue is PhongTro)
                maPhong = ((PhongTro)cbbSoPhong.SelectedValue).MaPhong;
            else
                maPhong = cbbSoPhong.SelectedValue.ToString();

            // Tìm Hợp đồng
            var hopDong = db.HopDongs.FirstOrDefault(hd => hd.MaPhong == maPhong);
            if (hopDong != null)
            {
                var khach = db.KhachHangs.FirstOrDefault(k => k.MaKH == hopDong.MaKH);
                txtTenKhachHang.Text = khach != null ? khach.TenKH : "Không tìm thấy tên khách";
                txtTenKhachHang.Tag = hopDong.MaHopDong;
            }
            else
            {
                txtTenKhachHang.Text = "Chưa có hợp đồng";
                txtTenKhachHang.Tag = null;
            }

            // Tìm Giá Phòng
            var phong = db.PhongTros.FirstOrDefault(p => p.MaPhong == maPhong);
            if (phong != null)
            {
                // Lấy giá từ bảng LoaiPhongTro
                var loaiPhong = db.LoaiPhongTros.FirstOrDefault(l => l.MaLoai == phong.MaLoai);
                if (loaiPhong != null)
                    txtTienPhong.Text = loaiPhong.GiaPhong.HasValue ? loaiPhong.GiaPhong.Value.ToString("0.##") : "0";
            }
        }

        // --- 3. TÍNH TIỀN TỰ ĐỘNG ---
        private void TinhTienTuDong(object sender, EventArgs e)
        {
            decimal slDien = 0, slNuoc = 0;
            decimal.TryParse(txtDienDaDung.Text, out slDien);
            decimal.TryParse(txtNuocDaDung.Text, out slNuoc);

            txtTienDien.Text = (slDien * Gia_Dien).ToString("0.##");
            txtTienNuoc.Text = (slNuoc * Gia_Nuoc).ToString("0.##");
        }

        private void TinhTongTien(object sender, EventArgs e)
        {
            // Logic tính tổng (nếu muốn hiển thị realtime)
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang.Tag == null)
            {
                MessageBox.Show("Chưa có hợp đồng, không thể lập hóa đơn!"); return;
            }

            // Sinh lại mã 1 lần nữa cho chắc chắn thời gian thực
            TaoMaHoaDonTuDong();

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    decimal tPhong = 0, tDien = 0, tNuoc = 0, tWifi = 0;
                    decimal slDien = 0, slNuoc = 0;

                    decimal.TryParse(txtTienPhong.Text, out tPhong);
                    decimal.TryParse(txtTienDien.Text, out tDien);
                    decimal.TryParse(txtTienNuoc.Text, out tNuoc);
                    decimal.TryParse(txtTienWifi.Text, out tWifi);
                    decimal.TryParse(txtDienDaDung.Text, out slDien);
                    decimal.TryParse(txtNuocDaDung.Text, out slNuoc);

                    // 1. TẠO HÓA ĐƠN
                    HoaDon hd = new HoaDon();
                    hd.MaHD = txtMaHoaDon.Text; // Lấy từ TextBox (đã tự sinh mã)

                    hd.MaHopDong = txtTenKhachHang.Tag.ToString();
                    hd.NgayLap = dtpNgayLap.Value;
                    hd.ThangNam = dtpNgayLap.Value;
                    hd.TrangThaiThanhToan = "Chưa thanh toán";
                    hd.PhuongThucTT = (chkChuyenKhoan != null && chkChuyenKhoan.Checked) ? "Chuyển khoản" : "Tiền mặt";

                    hd.TongTien = tPhong + tDien + tNuoc + tWifi;
                    hd.GhiChu = "Hóa đơn tháng " + dtpNgayLap.Value.ToString("MM/yyyy");
                    db.HoaDons.Add(hd);
                    db.SaveChanges();

                    // 2. TẠO CHI TIẾT
                    if (slDien > 0)
                    {
                        CT_HoaDon ctDien = new CT_HoaDon();
                        ctDien.MaHD = hd.MaHD;
                        ctDien.MaDV = MaDV_Dien;
                        ctDien.SoLuong = (int)slDien;
                        ctDien.DonGia = Gia_Dien;
                        ctDien.ThanhTien = tDien;
                        db.CT_HoaDons.Add(ctDien);
                    }

                    if (slNuoc > 0)
                    {
                        CT_HoaDon ctNuoc = new CT_HoaDon();
                        ctNuoc.MaHD = hd.MaHD;
                        ctNuoc.MaDV = MaDV_Nuoc;
                        ctNuoc.SoLuong = (int)slNuoc;
                        ctNuoc.DonGia = Gia_Nuoc;
                        ctNuoc.ThanhTien = tNuoc;
                        db.CT_HoaDons.Add(ctNuoc);
                    }

                    if (tWifi > 0)
                    {
                        CT_HoaDon ctWifi = new CT_HoaDon();
                        ctWifi.MaHD = hd.MaHD;
                        ctWifi.MaDV = MaDV_Wifi;
                        ctWifi.SoLuong = 1;
                        ctWifi.DonGia = Gia_Wifi;
                        ctWifi.ThanhTien = tWifi;
                        db.CT_HoaDons.Add(ctWifi);
                    }

                    db.SaveChanges();
                    transaction.Commit();

                    MessageBox.Show($"Thêm thành công! Mã HĐ: {hd.MaHD}\nTổng tiền: {hd.TongTien:N0}");

                    // Reset mã mới cho lần nhập tiếp theo
                    TaoMaHoaDonTuDong();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Hiển thị lỗi chi tiết
                    string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    if (ex.InnerException != null && ex.InnerException.InnerException != null)
                        msg = ex.InnerException.InnerException.Message;

                    MessageBox.Show("Lỗi: " + msg);
                }
            }
        }

        private void btnBaoCao_Click_1(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayBC = dtpNgayBaoCao.Value.Date;

                // Lấy danh sách và CHỌN CÁC CỘT MUỐN HIỂN THỊ
                var listHD = db.HoaDons
                    .Where(h => h.NgayLap.HasValue && h.NgayLap.Value.Year == ngayBC.Year
                                                   && h.NgayLap.Value.Month == ngayBC.Month
                                                   && h.NgayLap.Value.Day == ngayBC.Day)
                    .Select(h => new
                    {
                        MaHD = h.MaHD,
                        TenPhong = db.HopDongs.FirstOrDefault(x => x.MaHopDong == h.MaHopDong).MaPhong, // Lấy tạm Mã phòng để hiện
                        TongTien = h.TongTien,
                        NgayLap = h.NgayLap,
                        GhiChu = h.GhiChu // <--- QUAN TRỌNG: Phải chọn cột này nó mới hiện
                    })
                    .ToList();

                if (listHD.Count == 0)
                {
                    MessageBox.Show("Không có hóa đơn trong ngày này!");
                    dgvBaoCao.DataSource = null; // Xóa trắng bảng
                    if (txtTongThu != null) txtTongThu.Text = "0";
                    return;
                }

                // Đổ dữ liệu vào bảng DataGridView
                dgvBaoCao.DataSource = listHD;

                // Tính tổng tiền hiển thị
                decimal tongThu = listHD.Sum(h => h.TongTien ?? 0);
                if (txtTongThu != null) txtTongThu.Text = tongThu.ToString("N0");

                MessageBox.Show($"Tìm thấy {listHD.Count} hóa đơn.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message);
            }
        }

        // --- HÀM XUẤT HÓA ĐƠN RA EXCEL ---
        void XuatRaExcel(string maHD)
        {
            try
            {
                // 1. Lấy thông tin hóa đơn từ Database
                var hd = db.HoaDons.FirstOrDefault(h => h.MaHD == maHD);
                if (hd == null) return;

                // Lấy thông tin Khách hàng và Phòng qua các bảng liên kết
                // (Do mình đã cắt liên kết virtual, nên phải query thủ công một chút cho chắc)
                var hopDong = db.HopDongs.FirstOrDefault(x => x.MaHopDong == hd.MaHopDong);
                string tenKhach = "";
                string tenPhong = "";

                if (hopDong != null)
                {
                    var kh = db.KhachHangs.FirstOrDefault(k => k.MaKH == hopDong.MaKH);
                    var pt = db.PhongTros.FirstOrDefault(p => p.MaPhong == hopDong.MaPhong);
                    tenKhach = kh != null ? kh.TenKH : "Khách vãng lai";
                    tenPhong = pt != null ? pt.TenPhong : "Không rõ";
                }

                // Lấy chi tiết dịch vụ (Điện, Nước...)
                var listChiTiet = db.CT_HoaDons.Where(ct => ct.MaHD == maHD).ToList();

                // 2. Khởi tạo Excel
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                // 3. Định dạng chung (Font chữ)
                Excel.Range chung = (Excel.Range)exSheet.Cells[1, 1];
                chung.Font.Size = 12;
                chung.Font.Name = "Times New Roman";

                // 4. Viết Tiêu đề Hóa Đơn
                Excel.Range header = (Excel.Range)exSheet.Cells[1, 1];
                exSheet.Range["A1:E1"].Merge(); // Gộp ô từ A1 đến E1
                header.Value = "HÓA ĐƠN THANH TOÁN TIỀN TRỌ";
                header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                header.Font.Size = 16;
                header.Font.Bold = true;

                // 5. Viết thông tin chung
                exSheet.Cells[3, 2] = "Mã Hóa Đơn:"; exSheet.Cells[3, 3] = "'" + hd.MaHD; // Thêm dấu ' để ko bị lỗi số
                exSheet.Cells[4, 2] = "Phòng:"; exSheet.Cells[4, 3] = tenPhong;
                exSheet.Cells[5, 2] = "Khách hàng:"; exSheet.Cells[5, 3] = tenKhach;
                exSheet.Cells[6, 2] = "Ngày lập:"; exSheet.Cells[6, 3] = hd.NgayLap.HasValue ? hd.NgayLap.Value.ToString("dd/MM/yyyy") : "";

                // 6. Viết Tiêu đề bảng chi tiết (Dòng 8)
                exSheet.Cells[8, 1] = "STT";
                exSheet.Cells[8, 2] = "Tên Dịch Vụ";
                exSheet.Cells[8, 3] = "Số Lượng";
                exSheet.Cells[8, 4] = "Đơn Giá";
                exSheet.Cells[8, 5] = "Thành Tiền";

                // Định dạng tiêu đề bảng đậm
                exSheet.Range["A8:E8"].Font.Bold = true;
                exSheet.Range["A8:E8"].ColumnWidth = 15;

                // 7. Đổ dữ liệu chi tiết (Dòng 9 trở đi)
                int dong = 9;

                // A. Tiền phòng (Lấy từ Tổng tiền - Tiền dịch vụ, hoặc lấy từ Logic cũ)
                // Ở đây mình ví dụ lấy từ CT_HOADON, nếu bạn ko lưu Tiền Phòng vào CT_HOADON thì phải tính riêng
                // Nhưng tạm thời mình liệt kê các dịch vụ điện nước trước

                int stt = 1;
                foreach (var item in listChiTiet)
                {
                    // Lấy tên dịch vụ từ bảng DICHVU
                    var dv = db.DichVus.FirstOrDefault(d => d.MaDV == item.MaDV);
                    string tenDV = dv != null ? dv.TenDV : item.MaDV;

                    exSheet.Cells[dong, 1] = stt;
                    exSheet.Cells[dong, 2] = tenDV;
                    exSheet.Cells[dong, 3] = item.SoLuong;
                    exSheet.Cells[dong, 4] = item.DonGia;
                    exSheet.Cells[dong, 5] = item.ThanhTien;

                    dong++; stt++;
                }

                // 8. Tổng cộng
                dong++;
                exSheet.Cells[dong, 4] = "TỔNG CỘNG:";
                exSheet.Cells[dong, 4].Font.Bold = true;
                exSheet.Cells[dong, 5] = hd.TongTien;
                exSheet.Cells[dong, 5].Font.Bold = true;
                exSheet.Cells[dong, 5].Font.Color = System.Drawing.Color.Red;

                // 9. Hiển thị Excel lên
                exApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvBaoCao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có click vào dòng dữ liệu không (tránh click vào tiêu đề)
            if (e.RowIndex >= 0)
            {
                // Lấy Mã Hóa Đơn từ dòng được chọn
                // Lưu ý: Cột đầu tiên (index 0) hoặc tên cột phải đúng là "MaHD"
                // Trong code select báo cáo lần trước mình để: MaHD = h.MaHD
                string maHD = dgvBaoCao.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();

                // Hỏi xác nhận cho chuyên nghiệp
                if (MessageBox.Show("Bạn có muốn xuất hóa đơn " + maHD + " ra Excel không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XuatRaExcel(maHD);
                }
            }
        }
    }
}
