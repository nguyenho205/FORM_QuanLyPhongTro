using laptrinhNet.Database;
using laptrinhNet.Database.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet.ControlAdmin
{
    public partial class hdon_ttoanAdmin : UserControl
    {
        private decimal _giaDienHienTai = 0;
        private decimal _giaNuocHienTai = 0;
        public hdon_ttoanAdmin()
        {
            InitializeComponent();
        }

        private void hdon_ttoanAdmin_Load(object sender, EventArgs e)
        {
            LoadDataDichVu(); 
            LoadCboMaDV();  
            LoadCboLoaiDV();

            cbo_MaDV.SelectedIndex = -1;
            ResetForm();

            // Cấu hình ComboBox Trạng thái
            cbo_TrangThaiTT.Items.Clear();
            cbo_TrangThaiTT.Items.Add("Chưa thanh toán");
            cbo_TrangThaiTT.Items.Add("Đã thanh toán");

            cbo_Phuongthuc_TT.Items.Clear();
            cbo_Phuongthuc_TT.Items.Add("Tiền mặt");
            cbo_Phuongthuc_TT.Items.Add("Chuyển khoản");

            LoadDataHoaDon(); // Hàm load grid bạn đã c
            txt_TienNuoc.Enabled = false;
            txt_TienDien.Enabled = false;
            txt_TienWifi.Enabled = false;
            txt_TongTien.Enabled = false;
            txt_TienPhong.Enabled = false;
        }
        // 1. Load danh sách dịch vụ lên DataGridView
        private void LoadDataDichVu()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var list = db.DichVus.Select(dv => new DichVuDTO
                {
                    MaDV = dv.MaDV,
                    TenDV = dv.TenDV,
                    DonGia = dv.DonGia ?? 0, // Xử lý null giá
                    LoaiDV = dv.LoaiDichVu,
                    GhiChu = dv.GhiChu
                }).ToList();

                grid_DichVu.DataSource = list;
            }
        }

        // 2. Load Mã Dịch Vụ vào ComboBox
        private void LoadCboMaDV()
        {
            using (var db = new QLPhongTroDataContext())
            {
                cbo_MaDV.DataSource = db.DichVus.ToList();
                cbo_MaDV.DisplayMember = "MaDV"; // Hiển thị Mã
                cbo_MaDV.ValueMember = "MaDV";   // Giá trị cũng là Mã
            }
        }

        // 3. Load Loại Dịch Vụ (Cố định/Đo lường)
        private void LoadCboLoaiDV()
        {
            cbo_LoaiDV.Items.Clear();
            cbo_LoaiDV.Items.Add("Cố định");   
            cbo_LoaiDV.Items.Add("Đo lường"); 
            cbo_LoaiDV.SelectedIndex = 0;     
        }

        // 4. Hàm Reset Form
        private void ResetForm()
        {
            txt_TenDV.Text = "";
            txt_DonGia.Text = "";
            txt_GhiChu.Text = "";
            cbo_LoaiDV.SelectedIndex = -1;
            // cbo_MaDV.SelectedIndex = -1; // Không reset cái này ở đây để tránh trigger sự kiện change liên tục
        }

        private void cbo_MaDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có đang chọn giá trị hợp lệ không
            if (cbo_MaDV.SelectedValue == null) return;

            string maDVChon = cbo_MaDV.SelectedValue.ToString();

            using (var db = new QLPhongTroDataContext())
            {
                var dv = db.DichVus.FirstOrDefault(x => x.MaDV == maDVChon);

                if (dv != null)
                {
                    // Đổ dữ liệu cũ lên form để người dùng sửa
                    txt_TenDV.Text = dv.TenDV;

                    // Format tiền cho dễ nhìn (bỏ format nếu muốn người dùng nhập lại dễ hơn)
                    txt_DonGia.Text = dv.DonGia.ToString();

                    cbo_LoaiDV.Text = dv.LoaiDichVu; // Tự động chọn đúng loại cũ
                    txt_GhiChu.Text = dv.GhiChu;
                }
            }
        }

        private void grid_DichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = grid_DichVu.Rows[e.RowIndex];
                // Khi gán giá trị này, sự kiện cbo_MaDV_SelectedIndexChanged ở trên sẽ TỰ ĐỘNG CHẠY
                // và điền nốt các ô còn lại (Tên, Giá, Loại...).
                cbo_MaDV.SelectedValue = row.Cells["MaDV"].Value.ToString();
            }
        }

        private void btn_SuaDV_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (cbo_MaDV.SelectedValue == null || string.IsNullOrEmpty(cbo_MaDV.Text))
            {
                MessageBox.Show("Vui lòng chọn Mã dịch vụ cần sửa!");
                return;
            }

            if (string.IsNullOrEmpty(txt_TenDV.Text))
            {
                MessageBox.Show("Tên dịch vụ không được để trống!");
                return;
            }

            // 2. Thực hiện cập nhật
            using (var db = new QLPhongTroDataContext())
            {
                string maDV = cbo_MaDV.SelectedValue.ToString();
                var dv = db.DichVus.FirstOrDefault(x => x.MaDV == maDV);

                if (dv != null)
                {
                    // Gán giá trị MỚI từ form vào đối tượng
                    dv.TenDV = txt_TenDV.Text;

                    decimal donGia = 0;
                    decimal.TryParse(txt_DonGia.Text, out donGia);
                    dv.DonGia = donGia;

                    dv.LoaiDichVu = cbo_LoaiDV.Text; // Lấy "Cố định" hoặc "Đo lường"
                    dv.GhiChu = txt_GhiChu.Text;

                    // Lưu xuống DB
                    db.SaveChanges();
                    MessageBox.Show("Cập nhật dịch vụ thành công!");

                    // 3. Load lại giao diện
                    LoadDataDichVu(); // Load lại Grid để thấy thay đổi
                                      // Không cần load lại CboMaDV vì mã không đổi

                    ResetForm();
                    cbo_MaDV.SelectedIndex = -1; // Reset về trạng thái trống
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dịch vụ để sửa!");
                }
            }
        }
        //HÓA ĐOenN THANH TOÁN
        private void LayDonGiaDichVu()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var dvDien = db.DichVus.FirstOrDefault(d => d.MaDV == "DV01");
                if (dvDien != null) _giaDienHienTai = dvDien.DonGia ?? 0;

                var dvNuoc = db.DichVus.FirstOrDefault(d => d.MaDV == "DV02");
                if (dvNuoc != null) _giaNuocHienTai = dvNuoc.DonGia ?? 0;
            }
        }
        private void LoadDataHoaDon()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var list = from hd in db.HoaDons
                           join hopdong in db.HopDongs on hd.MaHopDong equals hopdong.MaHopDong
                           join phong in db.PhongTros on hopdong.MaPhong equals phong.MaPhong
                           join khach in db.KhachHangs on hopdong.MaKH equals khach.MaKH
                           orderby hd.NgayLap descending
                           select new CTHoaDonDTO
                           {
                               MaHD = hd.MaHD,
                               TenPhong = phong.TenPhong,
                               TenKhach = khach.TenKH,
                               NgayLap = hd.NgayLap ?? DateTime.Now,

                               // Lấy số lượng điện (DV01)
                               SoDien = (int)(db.CT_HoaDons
                                             .Where(ct => ct.MaHD == hd.MaHD && ct.MaDV == "DV01")
                                             .Select(ct => ct.SoLuong).FirstOrDefault() ?? 0),

                               // Lấy số lượng nước (DV02)
                               SoNuoc = (int)(db.CT_HoaDons
                                             .Where(ct => ct.MaHD == hd.MaHD && ct.MaDV == "DV02")
                                             .Select(ct => ct.SoLuong).FirstOrDefault() ?? 0),

                               TongTien = hd.TongTien ?? 0,
                               TrangThai = hd.TrangThaiThanhToan,
                               GhiChu = hd.GhiChu
                           };

                grid_HoaDon.DataSource = list.ToList();
            }
        }
        private void grid_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maHD = grid_HoaDon.Rows[e.RowIndex].Cells["MaHD"].Value?.ToString();
            txtMaHD.Text = maHD;
            txtMaHD.Enabled = false;

            using (var db = new QLPhongTroDataContext())
            {
                // 1. Lấy Hóa Đơn & Hợp Đồng
                var hd = db.HoaDons.FirstOrDefault(x => x.MaHD == maHD);
                if (hd == null) return;
                var hopDong = db.HopDongs.FirstOrDefault(h => h.MaHopDong == hd.MaHopDong);

                // 2. Đổ thông tin chung
                txtSoPhong.Text = hopDong?.PhongTroData?.TenPhong;
                txt_TenKH.Text = hopDong?.KhachHangData?.TenKH;
                cbo_TrangThaiTT.Text = hd.TrangThaiThanhToan;
                txt_GhiChu.Text = hd.GhiChu;
                cbo_Phuongthuc_TT.Text = hd.PhuongThucTT;
                if (hd.NgayThanhToan != null) dt_NgayTT_HD.Value = hd.NgayThanhToan.Value;

                // 3. Tiền phòng
                decimal tienPhong = 0;
                if (hopDong?.PhongTroData?.LoaiPTDaTa != null)
                    tienPhong = hopDong.PhongTroData.LoaiPTDaTa.GiaPhong ?? 0;
                txt_TienPhong.Text = tienPhong.ToString("N0");

                // 4. LẤY CHI TIẾT (QUAN TRỌNG: Refresh lại từ DB để lấy số mới nhất)
                var listChiTiet = db.CT_HoaDons.AsNoTracking().Where(ct => ct.MaHD == maHD).ToList();

                // >> ĐIỆN (DV01)
                var ctDien = listChiTiet.FirstOrDefault(ct => ct.MaDV.Trim().ToUpper() == "DV01");
                txt_SoDien.Text = (ctDien?.SoLuong ?? 0).ToString();
                txt_TienDien.Text = (ctDien?.ThanhTien ?? 0).ToString("N0");

                // >> NƯỚC (DV02)
                var ctNuoc = listChiTiet.FirstOrDefault(ct => ct.MaDV.Trim().ToUpper() == "DV02");
                txt_SoNuoc.Text = (ctNuoc?.SoLuong ?? 0).ToString();
                txt_TienNuoc.Text = (ctNuoc?.ThanhTien ?? 0).ToString("N0");

                // >> WIFI (DV03)
                var ctWifi = listChiTiet.FirstOrDefault(ct => ct.MaDV.Trim().ToUpper() == "DV03");
                txt_TienWifi.Text = (ctWifi?.ThanhTien ?? 0).ToString("N0");

                // 5. Tổng tiền (Lấy từ DB vì nút Sửa đã tính và lưu vào DB rồi)
                txt_TongTien.Text = (hd.TongTien ?? 0).ToString("N0");
            }
        }

        private void btn_SuaHD_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                var hd = db.HoaDons.FirstOrDefault(x => x.MaHD == txtMaHD.Text);
                if (hd == null) return;

                // 1. LẤY SỐ LƯỢNG MỚI TỪ GIAO DIỆN
                int soDienMoi = 0; int.TryParse(txt_SoDien.Text, out soDienMoi);
                int soNuocMoi = 0; int.TryParse(txt_SoNuoc.Text, out soNuocMoi);

                // 2. LẤY GIÁ DỊCH VỤ TRỰC TIẾP TỪ DB (Không dùng biến toàn cục để tránh lỗi = 0)
                // Dùng .Trim() để đảm bảo tìm thấy giá
                decimal giaDienChuan = 0;
                var dvDien = db.DichVus.FirstOrDefault(d => d.MaDV.Trim() == "DV01");
                if (dvDien != null) giaDienChuan = dvDien.DonGia ?? 0;

                decimal giaNuocChuan = 0;
                var dvNuoc = db.DichVus.FirstOrDefault(d => d.MaDV.Trim() == "DV02");
                if (dvNuoc != null) giaNuocChuan = dvNuoc.DonGia ?? 0;

                // 3. CẬP NHẬT CHI TIẾT VÀO BỘ NHỚ LIST
                // Lấy toàn bộ chi tiết ra list
                var listChiTiet = db.CT_HoaDons.Where(x => x.MaHD == hd.MaHD).ToList();

                // Cập nhật Điện
                var ctDien = listChiTiet.FirstOrDefault(ct => ct.MaDV != null && ct.MaDV.Trim().ToUpper() == "DV01");
                if (ctDien != null)
                {
                    ctDien.SoLuong = soDienMoi;
                    ctDien.DonGia = giaDienChuan;          // Gán giá chuẩn vừa lấy
                    ctDien.ThanhTien = soDienMoi * giaDienChuan; // Tự nhân tiền
                }

                // Cập nhật Nước
                var ctNuoc = listChiTiet.FirstOrDefault(ct => ct.MaDV != null && ct.MaDV.Trim().ToUpper() == "DV02");
                if (ctNuoc != null)
                {
                    ctNuoc.SoLuong = soNuocMoi;
                    ctNuoc.DonGia = giaNuocChuan;          // Gán giá chuẩn vừa lấy
                    ctNuoc.ThanhTien = soNuocMoi * giaNuocChuan; // Tự nhân tiền
                }

                // 4. TÍNH TỔNG TIỀN (Dựa trên List đã cập nhật giá mới)
                decimal tienPhong = 0;
                var hopDong = db.HopDongs.FirstOrDefault(h => h.MaHopDong == hd.MaHopDong);
                if (hopDong?.PhongTroData?.LoaiPTDaTa != null)
                {
                    tienPhong = hopDong.PhongTroData.LoaiPTDaTa.GiaPhong ?? 0;
                }

                // Hàm Sum sẽ cộng các giá trị ThanhTien MỚI NHẤT trong listChiTiet
                decimal tongTienDichVu = listChiTiet.Sum(ct => ct.ThanhTien ?? 0);

                hd.TongTien = tienPhong + tongTienDichVu;

                // 5. CẬP NHẬT TRẠNG THÁI & NGÀY
                hd.TrangThaiThanhToan = cbo_TrangThaiTT.Text;
                hd.GhiChu = txt_GhiChu.Text;

                if (cbo_TrangThaiTT.Text == "Đã thanh toán")
                {
                    if (hd.NgayThanhToan == null) hd.NgayThanhToan = DateTime.Now;

                    if (string.IsNullOrEmpty(cbo_Phuongthuc_TT.Text))
                        hd.PhuongThucTT = "Tiền mặt";
                    else
                        hd.PhuongThucTT = cbo_Phuongthuc_TT.Text;
                }
                else
                {
                    hd.NgayThanhToan = null;
                    hd.PhuongThucTT = null;
                }

                // 6. LƯU
                try
                {
                    db.SaveChanges();
                    MessageBox.Show($"Cập nhật thành công!\nTổng tiền mới: {hd.TongTien:N0} VNĐ", "Thành công");
                    LoadDataHoaDon();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
                }
            }
        }

        private void cbo_TrangThaiTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_TrangThaiTT.Text == "Đã thanh toán")
            {
                dt_NgayTT_HD.Value = DateTime.Now;
                dt_NgayTT_HD.Enabled = true;
                cbo_Phuongthuc_TT.Enabled = true;
            }
            else
            {
                dt_NgayTT_HD.Enabled = false;
                cbo_Phuongthuc_TT.Enabled = false;
                cbo_Phuongthuc_TT.SelectedIndex = -1;
            }
        }
    }
}
