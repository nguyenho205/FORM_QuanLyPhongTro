using laptrinhNet.ControlKhachhang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        private void btnPhongTro_Click(object sender, EventArgs e)
        {
            ptroKhachhang1.Visible = true;
            ptroKhachhang1.BringToFront();
        }

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
            {
                ptroKhachhang1.Visible = false;
                khangKhachhang1.Visible = false;
                hdongKhachhang1.Visible = false;
                hdon_ttoanKhachhang1.Visible = false;
                tbao_nnhoKhachhang1.Visible = false;
                phoi_htroKhachhang1.Visible = false;

                btnPhongTro.PerformClick();
            }
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

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            tbao_nnhoKhachhang1.Visible = true;
            tbao_nnhoKhachhang1.BringToFront();
        }

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            phoi_htroKhachhang1.Visible = true;
            phoi_htroKhachhang1.BringToFront();
        }
    }
}
