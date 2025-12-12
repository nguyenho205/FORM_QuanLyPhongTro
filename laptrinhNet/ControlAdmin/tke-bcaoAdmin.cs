using laptrinhNet.Database;
using laptrinhNet.Database.DTOs;
using laptrinhNet.Database.Entities;
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
    public partial class tke_bcaoAdmin : UserControl
    {
        public tke_bcaoAdmin()
        {
            InitializeComponent();
        }

        private void tke_bcaoAdmin_Load(object sender, EventArgs e)
        {
            // Optional: Configure DateTimePicker format if not set in Designer
            dtpThang.Format = DateTimePickerFormat.Custom;
            dtpThang.CustomFormat = "MM/yyyy";
        }

        private void btn_XemThongKe_Click(object sender, EventArgs e)
        {
            // 1. Get Month and Year from DateTimePicker
            DateTime ngayChon = dtpThang.Value;
            int thang = ngayChon.Month;
            int nam = ngayChon.Year;

            // Change cursor to wait cursor to indicate processing
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                using (var db = new QLPhongTroDataContext())
                {
                    // 2. QUERY INVOICE LIST (Step 1)
                    // Fetch basic invoice info first
                    var listRaw = (from hd in db.HoaDons
                                   join hopdong in db.HopDongs on hd.MaHopDong equals hopdong.MaHopDong
                                   join phong in db.PhongTros on hopdong.MaPhong equals phong.MaPhong
                                   join khach in db.KhachHangs on hopdong.MaKH equals khach.MaKH
                                   where hd.TrangThaiThanhToan == "Đã thanh toán"
                                         && hd.NgayThanhToan != null
                                         && hd.NgayThanhToan.Value.Month == thang
                                         && hd.NgayThanhToan.Value.Year == nam
                                   select new
                                   {
                                       hd.MaHD,
                                       TenPhong = phong.TenPhong,
                                       TenKhach = khach.TenKH,
                                       NgayThanhToan = hd.NgayThanhToan.Value,
                                       TongTien = hd.TongTien ?? 0,
                                       // Fix capitalization error: hopdong (lowercase)
                                       GiaPhong = hopdong.PhongTroData.LoaiPTDaTa.GiaPhong ?? 0
                                   }).ToList();

                    // Check if no data found
                    if (listRaw.Count == 0)
                    {
                        MessageBox.Show($"Không có hóa đơn nào đã thanh toán trong tháng {thang}/{nam}!");
                        crystalViewTKDT.ReportSource = null; // Clear previous report
                        return;
                    }

                    // 3. OPTIMIZATION: FETCH ALL DETAILS IN ONE GO (Step 2)
                    // Get all Invoice IDs from the list above
                    var listMaHD = listRaw.Select(x => x.MaHD).ToList();

                    // Fetch all detail rows for these invoices at once
                    // (Assuming DB table is CT_HoaDons based on previous context)
                    var listAllChiTiet = db.CT_HoaDons
                                           .Where(ct => listMaHD.Contains(ct.MaHD))
                                           .ToList();

                    // 4. CALCULATE DETAILS IN MEMORY (Step 3)
                    List<ThongKeDoanhThuDTO> listReport = new List<ThongKeDoanhThuDTO>();

                    foreach (var item in listRaw)
                    {
                        // Filter details from memory list (Fast)
                        var chiTietCuaHD = listAllChiTiet.Where(ct => ct.MaHD == item.MaHD).ToList();

                        // Calculate Electricity (DV01)
                        decimal tienDien = chiTietCuaHD.Where(ct => ct.MaDV != null && ct.MaDV.Trim().ToUpper() == "DV01")
                                                       .Sum(ct => ct.ThanhTien ?? 0);

                        // Calculate Water (DV02)
                        decimal tienNuoc = chiTietCuaHD.Where(ct => ct.MaDV != null && ct.MaDV.Trim().ToUpper() == "DV02")
                                                       .Sum(ct => ct.ThanhTien ?? 0);

                        // Calculate Other Services
                        decimal tienDichVu = (item.TongTien) - (item.GiaPhong + tienDien + tienNuoc);

                        // Add to report list
                        listReport.Add(new ThongKeDoanhThuDTO
                        {
                            MaHD = item.MaHD,
                            TenPH = item.TenPhong,
                            TenKH = item.TenKhach,
                            NgayThanhToan = item.NgayThanhToan,
                            TongTien = item.TongTien,
                            TienPhong = item.GiaPhong,
                            TienDien = tienDien,
                            TienNuoc = tienNuoc,
                            TienDichVu = tienDichVu < 0 ? 0 : tienDichVu
                        });
                    }

                    // 5. PUSH TO REPORT
                    ThongKeDoanhThuReport rpt = new ThongKeDoanhThuReport();
                    rpt.SetDataSource(listReport);

                    // Pass Title Parameter
                    rpt.SetParameterValue("Thang", string.Format("Tháng {0} năm {1}", thang, nam));

                    // 6. DISPLAY
                    crystalViewTKDT.ReportSource = rpt;
                    crystalViewTKDT.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message);
            }
            finally
            {
                // Reset cursor
                Cursor.Current = Cursors.Default;
            }
        }
    }
}