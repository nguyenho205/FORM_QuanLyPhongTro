using laptrinhNet.ControlKhachhang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet
{
    [NotMapped]
    public partial class FKhachHang : Form
    {
        private string MaKH; // Biến lưu MaKH người dùng

        public FKhachHang()
        {
            InitializeComponent();
        }


        //private void btnPhongTro_Click(object sender, EventArgs e)
        //{
        //    ptroKhachhang1.Visible = true;
        //    ptroKhachhang1.BringToFront();
        //}

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            // Ẩn tất cả UserControl
            hdongKhachhang1.Visible = false;
            hdon_ttoanKhachhang1.Visible = false;
            phoi_htroKhachhang1.Visible = false;

            khangKhachhang1.Visible = true;
            khangKhachhang1.BringToFront();

        //    khangKhachhang1.khach += (khach) =>
        //    {
        //        if (khach != null)
        //        {

        //            hdongKhachhang1.SetKhachHang(khach);


        //            hdon_ttoanKhachhang1.SetKhachHang(khach);
        //        }
        //    };




        //    //Lay rd
        //    //khangKhachhang1.Load_RandomIn4();
        //    // Lấy kháchmacdinh
        //    //khangKhachhang1.Load_KhachHang("KH03");

        //    //;ay thong tin dua tren makh dang nhap
        //    khangKhachhang1.Load_KhachHang(MaKH);


        //    //Khách htai
        //    var kh = khangKhachhang1.KhachDaChon;
        //    if (kh != null)
        //    {
        //        hdongKhachhang1.SetKhachHang(kh);
        //        hdongKhachhang1.Visible = true;

        //        hdon_ttoanKhachhang1.SetKhachHang(kh);
        //        hdon_ttoanKhachhang1.Visible = true;

        //        phoi_htroKhachhang1.SetKhachHang(kh);
        //        phoi_htroKhachhang1.Visible = true;
        //    }

        }



        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            khangKhachhang1.Visible = true;
            khangKhachhang1.BringToFront();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            hdongKhachhang1.Visible = true;
            hdongKhachhang1.BringToFront();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            hdon_ttoanKhachhang1.Visible = true;
            hdon_ttoanKhachhang1.BringToFront();
        }

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            phoi_htroKhachhang1.Visible = true;
            phoi_htroKhachhang1.BringToFront();
        }

        private void khangKhachhang1_Load(object sender, EventArgs e)
        {

        }
    }
}
