using laptrinhNet.ControlAdmin;
using laptrinhNet.ControlNhanvien;
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
    public partial class FNhanVien : Form
    {
        public FNhanVien()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close(); //Gọi formClosing
        }

        private void NhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            ptroNhanvien1.Visible = false;
            nvienNhanvien1.Visible = false;
            khangNhanvien1.Visible = false;
            hdongNhanvien1.Visible = false;
            hdon_ttoanNhanvien1.Visible = false;
            phoi_htroNhanvien1.Visible = false;

            btnPhongTro.PerformClick();
        }

        private void btnPhongTro_Click(object sender, EventArgs e)
        {
            ptroNhanvien1.Visible = true;
            ptroNhanvien1.BringToFront();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            nvienNhanvien1.Visible=true;
            nvienNhanvien1.BringToFront();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            khangNhanvien1.Visible = true;
            khangNhanvien1.BringToFront();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            hdongNhanvien1.Visible = true;
            hdongNhanvien1.BringToFront();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            hdon_ttoanNhanvien1.Visible = true;
            hdon_ttoanNhanvien1.BringToFront();
        }



        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            phoi_htroNhanvien1.Visible = true;
            phoi_htroNhanvien1.BringToFront();
        }

        private void khangNhanvien1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
