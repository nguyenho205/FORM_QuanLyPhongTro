using laptrinhNet.Database;
using laptrinhNet.Database.DTOs;
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
    public partial class hdon_ttoanKhachhang : UserControl
    {
        public hdon_ttoanKhachhang()
        {
            InitializeComponent();
        }

        private void hdon_ttoanKhachhang_Load(object sender, EventArgs e)
        {
            cbMaHD.SelectedIndexChanged += cbMaHD_SelectedIndexChanged;
        }

        private KhachHang khachHangHienTai;

        public void SetKhachHang(KhachHang kh)
        {
            khachHangHienTai = kh;
            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            if (khachHangHienTai == null) return;

            using (var db = new QLPhongTroDataContext())
            {
                // Lấy tất cả MaHopDong của khách hàng hiện tại
                var dsMaHopDong = db.HopDongs
                                    .Where(h => h.MaKH == khachHangHienTai.MaKH)
                                    .Select(h => h.MaHopDong)
                                    .ToList();

                // Lấy danh sách hóa đơn theo hợp đồng
                var dsHoaDon = db.HoaDons
                                 .Where(hd => dsMaHopDong.Contains(hd.MaHopDong))
                                 .OrderByDescending(hd => hd.NgayLap)
                                 .ToList();

                // Gán vào ComboBox
                cbMaHD.DataSource = dsHoaDon;
                cbMaHD.DisplayMember = "MaHD";
                cbMaHD.ValueMember = "MaHD";
                if (dsHoaDon.Count > 0)
                {
                    cbMaHD.SelectedIndex = 0;
                    cbMaHD_SelectedIndexChanged(cbMaHD, EventArgs.Empty); 
                }

            }
        }

        private void cbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaHD.SelectedItem == null) return;

            var hd = cbMaHD.SelectedItem as HoaDon;
            if (hd == null) return;


            cbTrangthai.Text = hd.TrangThaiThanhToan;
            NgayLap.Value = hd.NgayLap ?? DateTime.Now;
            Han.Value = (hd.NgayLap ?? DateTime.Now).AddDays(15);
            txtGhichu.Text = hd.GhiChu;


            using (var db = new QLPhongTroDataContext())
            {
                var dsCT = db.CT_HoaDons
                             .Where(ct => ct.MaHD == hd.MaHD)
                             .ToList();

                int dienDaDung = 0;
                int nuocDaDung = 0;
                decimal tongTienDien = 0;
                decimal tongTienNuoc = 0;
                decimal phiDVKhac = 0;

                foreach (var ct in dsCT)
                {
                    if (ct.MaDV.Trim() == "DV01")
                    {
                        if (ct.ChiSoCu.HasValue && ct.ChiSoMoi.HasValue)
                        {
                            dienDaDung = ct.ChiSoMoi.Value - ct.ChiSoCu.Value;
                            tongTienDien = dienDaDung * ct.DonGia;
                        }
                    }
                    else if (ct.MaDV.Trim() == "DV02")
                    {
                        if (ct.ChiSoCu.HasValue && ct.ChiSoMoi.HasValue)
                        {
                            nuocDaDung = ct.ChiSoMoi.Value - ct.ChiSoCu.Value;
                            tongTienNuoc = nuocDaDung * ct.DonGia;
                        }
                    }
                    else
                    {
                        int sl = ct.SoLuong ?? 1;
                        phiDVKhac += sl * ct.DonGia;
                    }
                }

                var culture = new CultureInfo("vi-VN");

                txtDiendadung.Text = dienDaDung.ToString();
                txtNuocdadung.Text = nuocDaDung.ToString();
                txtTongDien.Text = tongTienDien.ToString("N0", culture);
                txtTongNuoc.Text = tongTienNuoc.ToString("N0", culture);
                txtDichvu.Text = phiDVKhac.ToString("N0", culture);
                decimal tongTatCa = tongTienDien + tongTienNuoc + phiDVKhac;
                txtTongtien.Text = tongTatCa.ToString("N0", culture);

            }
        }
    }
}


