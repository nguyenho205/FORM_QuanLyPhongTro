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

        private void hdongKhachhang_Load(object sender, EventArgs e)
        {

        }
        public void SetKhachHang(KhachHang kh)
        {
            if (kh != null)
            {
                using (var db = new QLPhongTroDataContext())
                {
                    var dsHopDong = (from h in db.HopDongs
                                     join p in db.PhongTros on h.MaPhong equals p.MaPhong
                                     join l in db.LoaiPhongTros on p.MaLoai equals l.MaLoai
                                     join k in db.KhachHangs on h.MaKH equals k.MaKH
                                     where h.MaKH == kh.MaKH
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
                                     }).ToList();

                    if (dsHopDong.Count > 0)
                    {
                        Random rnd = new Random();
                        var hopDong = dsHopDong[rnd.Next(dsHopDong.Count)];

                        txtMaHD.Text = hopDong.MaHopDong;
                        txtSophong.Text = hopDong.TenPhong;
                        txtTenKH.Text = hopDong.TenKH;

                        txtCoc.Text = hopDong.TienCoc?.ToString("N0", new CultureInfo("vi-VN")) ?? "0";
                        txtTienphong.Text = hopDong.TienPhong?.ToString("N0", new CultureInfo("vi-VN")) ?? "0";

                        Tungay.Value = hopDong.NgayBD ?? DateTime.Now;
                        Denngay.Value = hopDong.NgayKT ?? DateTime.Now;
                    }
                    else
                    {
                        txtMaHD.Text = "";
                        txtSophong.Text = "";
                        txtTenKH.Text = "";
                        txtCoc.Text = "";
                        txtTienphong.Text = "";
                        Tungay.Value = DateTime.Now;
                        Denngay.Value = DateTime.Now;
                    }
                }
            }
        }

        private void btnGiahan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text))
            {
                MessageBox.Show("Không tìm thấy mã hợp đồng để gia hạn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                var hd = db.HopDongs.FirstOrDefault(h => h.MaHopDong == txtMaHD.Text);

                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hợp đồng trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật dữ liệu
                hd.NgayBD = Tungay.Value;
                hd.NgayKT = Denngay.Value;

                if (decimal.TryParse(txtCoc.Text.Replace(".", "").Replace(",", ""), out decimal tienCoc))
                    hd.TienCoc = tienCoc;


                if (decimal.TryParse(txtTienphong.Text.Replace(".", "").Replace(",", ""), out decimal tienPhong))
                {
                }


                db.SaveChanges();

                MessageBox.Show("Gia hạn hợp đồng thành công!", "Thành công");
            }
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text;

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần hủy!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                var hd = db.HopDongs.FirstOrDefault(x => x.MaHopDong == maHD);

                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hợp đồng!");
                    return;
                }

                var confirm = MessageBox.Show("Bạn có chắc muốn hủy hợp đồng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                hd.TrangThai = "Hủy";

                var phong = db.PhongTros.FirstOrDefault(p => p.MaPhong == hd.MaPhong);
                if (phong != null)
                    phong.TrangThai = "TRỐNG";

                db.SaveChanges();
            }

            MessageBox.Show("Đã hủy hợp đồng thành công!");


            if (this.Tag is KhachHang kh) 
            {
                SetKhachHang(kh);
            }
        }
    }
}



