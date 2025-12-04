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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close(); //Gọi formClosing
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            ptroAdmin1.Visible = false;
            nvienAdmin1.Visible = false;
            khangAdmin1.Visible = false;
            hdongAdmin1.Visible = false;
            hdon_ttoanAdmin1.Visible = false;
            tke_bcaoAdmin1.Visible = false;
            tbao_nnhoAdmin1.Visible = false;
            phoi_htroAdmin1.Visible = false;

            btnPhongTro.PerformClick();
        }

        private void btnPhongTro_Click(object sender, EventArgs e)
        {
            ptroAdmin1.Visible = true;
            ptroAdmin1.BringToFront();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            nvienAdmin1.Visible = true;
            nvienAdmin1.BringToFront();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            khangAdmin1.Visible= true;
            khangAdmin1.BringToFront();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            hdongAdmin1.Visible= true;
            hdongAdmin1.BringToFront();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            hdon_ttoanAdmin1.Visible= true;
            hdon_ttoanAdmin1.BringToFront();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            tke_bcaoAdmin1.Visible= true;
            tke_bcaoAdmin1.BringToFront();
        }

        private void btnThongBao_Click(object sender, EventArgs e)
        {
            tbao_nnhoAdmin1.Visible = true;
            tbao_nnhoAdmin1.BringToFront();
        }

        private void btnPhanHoi_Click(object sender, EventArgs e)
        {
            phoi_htroAdmin1.Visible = true;
            phoi_htroAdmin1.BringToFront();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void phoi_htroAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
