using laptrinhNet.Database;
using laptrinhNet.Database.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity; // Important for AsNoTracking
using System.Linq;
using System.Windows.Forms;

namespace laptrinhNet.ControlAdmin
{
    public partial class hdon_ttoanAdmin : UserControl
    {
        // Global variables for UI display purposes only (not used for saving)
        private decimal _giaDienGiaoDien = 0;
        private decimal _giaNuocGiaoDien = 0;

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

            // Configure Status ComboBox
            cbo_TrangThaiTT.Items.Clear();
            cbo_TrangThaiTT.Items.Add("Chưa thanh toán");
            cbo_TrangThaiTT.Items.Add("Đã thanh toán");

            // Configure Payment Method ComboBox
            cbo_Phuongthuc_TT.Items.Clear();
            cbo_Phuongthuc_TT.Items.Add("Tiền mặt");
            cbo_Phuongthuc_TT.Items.Add("Chuyển khoản");

            // Get current prices for UI calculation
            LayDonGiaDichVuChoGiaoDien();

            LoadDataHoaDon();

            // Lock calculated fields
            txt_TienNuoc.Enabled = false;
            txt_TienDien.Enabled = false;
            txt_TienWifi.Enabled = false;
            txt_TongTien.Enabled = false;
            txt_TienPhong.Enabled = false;
        }

        // --- HELPER METHODS ---

        private void LayDonGiaDichVuChoGiaoDien()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var dvDien = db.DichVus.FirstOrDefault(d => d.MaDV.Trim() == "DV01");
                if (dvDien != null) _giaDienGiaoDien = dvDien.DonGia ?? 0;

                var dvNuoc = db.DichVus.FirstOrDefault(d => d.MaDV.Trim() == "DV02");
                if (dvNuoc != null) _giaNuocGiaoDien = dvNuoc.DonGia ?? 0;
            }
        }

        private void LoadDataDichVu()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var list = db.DichVus.Select(dv => new DichVuDTO
                {
                    MaDV = dv.MaDV,
                    TenDV = dv.TenDV,
                    DonGia = dv.DonGia ?? 0,
                    LoaiDV = dv.LoaiDichVu,
                    GhiChu = dv.GhiChu
                }).ToList();

                grid_DichVu.DataSource = list;
            }
        }

        private void LoadCboMaDV()
        {
            using (var db = new QLPhongTroDataContext())
            {
                cbo_MaDV.DataSource = db.DichVus.ToList();
                cbo_MaDV.DisplayMember = "MaDV";
                cbo_MaDV.ValueMember = "MaDV";
            }
        }

        private void LoadCboLoaiDV()
        {
            cbo_LoaiDV.Items.Clear();
            cbo_LoaiDV.Items.Add("Cố định");
            cbo_LoaiDV.Items.Add("Đo lường");
            cbo_LoaiDV.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            txt_TenDV.Text = "";
            txt_DonGia.Text = "";
            txt_GhiChu.Text = "";
            cbo_LoaiDV.SelectedIndex = -1;
        }

        // --- SERVICE MANAGEMENT EVENTS ---

        private void cbo_MaDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_MaDV.SelectedValue == null) return;
            string maDVChon = cbo_MaDV.SelectedValue.ToString();

            using (var db = new QLPhongTroDataContext())
            {
                var dv = db.DichVus.FirstOrDefault(x => x.MaDV == maDVChon);
                if (dv != null)
                {
                    txt_TenDV.Text = dv.TenDV;
                    txt_DonGia.Text = dv.DonGia.ToString();
                    cbo_LoaiDV.Text = dv.LoaiDichVu;
                    txt_GhiChu.Text = dv.GhiChu;
                }
            }
        }

        private void grid_DichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = grid_DichVu.Rows[e.RowIndex];
                cbo_MaDV.SelectedValue = row.Cells["MaDV"].Value.ToString();
            }
        }

        private void btn_SuaDV_Click(object sender, EventArgs e)
        {
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

            using (var db = new QLPhongTroDataContext())
            {
                string maDV = cbo_MaDV.SelectedValue.ToString();
                var dv = db.DichVus.FirstOrDefault(x => x.MaDV == maDV);

                if (dv != null)
                {
                    dv.TenDV = txt_TenDV.Text;
                    decimal.TryParse(txt_DonGia.Text, out decimal donGia);
                    dv.DonGia = donGia;
                    dv.LoaiDichVu = cbo_LoaiDV.Text;
                    dv.GhiChu = txt_GhiChu.Text;

                    db.SaveChanges();
                    MessageBox.Show("Cập nhật dịch vụ thành công!");
                    LoadDataDichVu();
                    ResetForm();
                    cbo_MaDV.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dịch vụ để sửa!");
                }
            }
        }

        // --- INVOICE MANAGEMENT EVENTS ---

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
                               // Subquery using Trim() for safety
                               SoDien = (int)(db.CT_HoaDons.Where(ct => ct.MaHD == hd.MaHD && ct.MaDV.Trim() == "DV01").Select(ct => ct.SoLuong).FirstOrDefault() ?? 0),
                               SoNuoc = (int)(db.CT_HoaDons.Where(ct => ct.MaHD == hd.MaHD && ct.MaDV.Trim() == "DV02").Select(ct => ct.SoLuong).FirstOrDefault() ?? 0),
                               TongTien = hd.TongTien ?? 0,
                               TrangThai = hd.TrangThaiThanhToan,
                               GhiChu = hd.GhiChu,
                               // Add Payment info to DTO if needed for Grid display, otherwise just for CellClick
                               PhuongThucTT = hd.PhuongThucTT,
                               NgayThanhToan = hd.NgayThanhToan ?? DateTime.Now
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

            // Use AsNoTracking() to ignore cache and fetch fresh data
            using (var db = new QLPhongTroDataContext())
            {
                var hd = db.HoaDons.AsNoTracking().FirstOrDefault(x => x.MaHD == maHD);
                if (hd == null) return;
                var hopDong = db.HopDongs.AsNoTracking().FirstOrDefault(h => h.MaHopDong == hd.MaHopDong);

                // Basic Info
                txtSoPhong.Text = hopDong?.PhongTroData?.TenPhong;
                txt_TenKH.Text = hopDong?.KhachHangData?.TenKH;
                cbo_TrangThaiTT.Text = hd.TrangThaiThanhToan;
                txt_GhiChu.Text = hd.GhiChu;
                cbo_Phuongthuc_TT.Text = hd.PhuongThucTT;
                dt_NgayTT_HD.Value = hd.NgayThanhToan ?? DateTime.Now;
                // Room Price
                decimal tienPhong = 0;
                if (hopDong?.PhongTroData?.LoaiPTDaTa != null)
                    tienPhong = hopDong.PhongTroData.LoaiPTDaTa.GiaPhong ?? 0;
                txt_TienPhong.Text = tienPhong.ToString("N0");

                // Detail Services (Using AsNoTracking + Trim + ToUpper)
                var listChiTiet = db.CT_HoaDons.AsNoTracking().Where(ct => ct.MaHD == maHD).ToList();

                // Electricity (DV01)
                var ctDien = listChiTiet.FirstOrDefault(ct => ct.MaDV != null && ct.MaDV.Trim().ToUpper() == "DV01");
                txt_SoDien.Text = (ctDien?.SoLuong ?? 0).ToString();
                txt_TienDien.Text = (ctDien?.ThanhTien ?? 0).ToString("N0");

                // Water (DV02)
                var ctNuoc = listChiTiet.FirstOrDefault(ct => ct.MaDV != null && ct.MaDV.Trim().ToUpper() == "DV02");
                txt_SoNuoc.Text = (ctNuoc?.SoLuong ?? 0).ToString();
                txt_TienNuoc.Text = (ctNuoc?.ThanhTien ?? 0).ToString("N0");

                // Wifi (DV03)
                var ctWifi = listChiTiet.FirstOrDefault(ct => ct.MaDV != null && ct.MaDV.Trim().ToUpper() == "DV03");
                txt_TienWifi.Text = (ctWifi?.ThanhTien ?? 0).ToString("N0");

                // Total
                txt_TongTien.Text = (hd.TongTien ?? 0).ToString("N0");
            }
        }

        private void btn_SuaHD_Click_1(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                // 2. Tìm hóa đơn
                var hd = db.HoaDons.FirstOrDefault(x => x.MaHD == txtMaHD.Text);
                if (hd == null) return;

                // 3. LẤY SỐ LƯỢNG MỚI TỪ GIAO DIỆN
                int soDienMoi = 0; int.TryParse(txt_SoDien.Text, out soDienMoi);
                int soNuocMoi = 0; int.TryParse(txt_SoNuoc.Text, out soNuocMoi);

                // 4. LẤY GIÁ DỊCH VỤ CHUẨN TỪ DB
                decimal giaDienChuan = 0;
                var dvDien = db.DichVus.FirstOrDefault(d => d.MaDV.Trim() == "DV01");
                if (dvDien != null) giaDienChuan = dvDien.DonGia ?? 0;

                decimal giaNuocChuan = 0;
                var dvNuoc = db.DichVus.FirstOrDefault(d => d.MaDV.Trim() == "DV02");
                if (dvNuoc != null) giaNuocChuan = dvNuoc.DonGia ?? 0;

                // 5. CẬP NHẬT CHI TIẾT
                var listChiTiet = db.CT_HoaDons.Where(x => x.MaHD == hd.MaHD).ToList();

                // Cập nhật Điện
                var ctDien = listChiTiet.FirstOrDefault(ct => ct.MaDV != null && ct.MaDV.Trim().ToUpper() == "DV01");
                if (ctDien != null)
                {
                    ctDien.SoLuong = soDienMoi;
                    ctDien.DonGia = giaDienChuan;
                    ctDien.ThanhTien = soDienMoi * giaDienChuan;
                }

                // Cập nhật Nước
                var ctNuoc = listChiTiet.FirstOrDefault(ct => ct.MaDV != null && ct.MaDV.Trim().ToUpper() == "DV02");
                if (ctNuoc != null)
                {
                    ctNuoc.SoLuong = soNuocMoi;
                    ctNuoc.DonGia = giaNuocChuan;
                    ctNuoc.ThanhTien = soNuocMoi * giaNuocChuan;
                }

                // 6. TÍNH LẠI TỔNG TIỀN
                decimal tienPhong = 0;
                var hopDong = db.HopDongs.FirstOrDefault(h => h.MaHopDong == hd.MaHopDong);
                if (hopDong?.PhongTroData?.LoaiPTDaTa != null)
                {
                    tienPhong = hopDong.PhongTroData.LoaiPTDaTa.GiaPhong ?? 0;
                }

                decimal tongTienDichVu = listChiTiet.Sum(ct => ct.ThanhTien ?? 0);
                hd.TongTien = tienPhong + tongTienDichVu;

                // 7. CẬP NHẬT TRẠNG THÁI & NGÀY THANH TOÁN (SỬA CHỖ NÀY)
                hd.TrangThaiThanhToan = cbo_TrangThaiTT.Text;
                hd.GhiChu = txt_GhiChu.Text;

                if (cbo_TrangThaiTT.Text == "Đã thanh toán")
                {
                    // --- SỬA LỖI Ở ĐÂY ---
                    // Lấy giá trị ngày từ DateTimePicker (dt_NgayTT_HD) mà người dùng chọn
                    hd.NgayThanhToan = dt_NgayTT_HD.Value;
                    db.SaveChanges();

                    // Cập nhật phương thức thanh toán
                    if (string.IsNullOrEmpty(cbo_Phuongthuc_TT.Text))
                        hd.PhuongThucTT = "Tiền mặt";
                    else
                        hd.PhuongThucTT = cbo_Phuongthuc_TT.Text;
                }
                else // Nếu chuyển về Chưa thanh toán
                {
                    hd.NgayThanhToan = null;
                    hd.PhuongThucTT = null;
                }

                // 8. LƯU
                try
                {
                    db.SaveChanges();
                    MessageBox.Show($"Cập nhật thành công!\nNgày thanh toán: {hd.NgayThanhToan:dd/MM/yyyy}", "Thành công");
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
                // Enable controls so user can edit if needed
                dt_NgayTT_HD.Enabled = true;
                cbo_Phuongthuc_TT.Enabled = true;

                // If it was null/empty before, default to Now, otherwise keep selected
                // (Optional: dt_NgayTT_HD.Value = DateTime.Now;)
            }
            else
            {
                dt_NgayTT_HD.Enabled = false;
                cbo_Phuongthuc_TT.Enabled = false;
                cbo_Phuongthuc_TT.SelectedIndex = -1;
            }
        }

        // Optional: Add TextChanged events to txt_SoDien and txt_SoNuoc to calculate totals on UI in real-time
        private void txt_SoLuong_TextChanged(object sender, EventArgs e)
        {
            // Copy logic from previous UpdateGiaoDien() here if you want real-time calculation
        }
    }
}