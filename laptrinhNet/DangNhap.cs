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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            resetForm();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát trang không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        public void btnDangNhap_Click(object sender, EventArgs e)
        {
            //nếu txt trống và không chọn radio
            if ((string.IsNullOrWhiteSpace(txtDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text)) && !rdAdmin.Checked && !rdNhanVien.Checked && !rdNguoiThue.Checked)
            {
                labelErrorNull.Visible = true;
                labelRadio.Visible = true;
                labelErrorNull.BringToFront();

                // Ẩn labelDangky và labelError
                labelError.Visible = false;
                labelDangky.Visible = false;
                return; // dừng đăng nhập
            }
            else
            {
                labelRadio.Visible = false;
                labelError.Visible = false;
                labelErrorNull.Visible = false;
                labelDangky.Visible = true;
            }

            //textbox null
            if (string.IsNullOrWhiteSpace(txtDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                labelErrorNull.Visible = true;
                labelRadio.Visible = false;
                labelError.Visible = false;
                labelDangky.Visible = false;
                return;
            }


            //check radio
            if (!rdAdmin.Checked && !rdNhanVien.Checked && !rdNguoiThue.Checked)
            {
                labelRadio.Visible = true;
                labelError.Visible = false;
                labelErrorNull.Visible = false;
                labelDangky.Visible = false;
                return;
            }

            //check sai ten va mat khau
            if (txtDangNhap.Text == "sa" && txtMatKhau.Text == "123" && rdAdmin.Checked)
            {
                Admin menuAdmin = new Admin();
                this.Hide();
                menuAdmin.ShowDialog();
                this.Show();
                resetForm();
                return;
            }
            else if (txtDangNhap.Text == "sa" && txtMatKhau.Text == "123" && rdNhanVien.Checked)
            {
                FNhanVien menuNhanvien = new FNhanVien();
                this.Hide();
                menuNhanvien.ShowDialog();
                this.Show();
                resetForm();
                return;
            }
            else if (txtDangNhap.Text == "sa" && txtMatKhau.Text == "123" && rdNguoiThue.Checked)
            {
                FKhachHang menuKhachhang = new FKhachHang();
                this.Hide();
                menuKhachhang.ShowDialog();
                this.Show();
                resetForm();
                return;
            }

            labelError.Visible = true;
            labelDangky.Visible = false;
            labelError.BringToFront();
        }



        public void resetForm()
        {
            labelError.Visible = false;
            labelRadio.Visible = false;
            labelErrorNull.Visible = false;
            txtDangNhap.Clear();
            txtMatKhau.Clear();
            rdAdmin.Checked = false;
            rdNhanVien.Checked = false;
            rdNguoiThue.Checked = false;
            labelDangky.Visible = true;

        }

        private void txtDangNhap_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDangNhap.Text))
            {
                labelErrorNull.Visible = false;
                labelError.Visible = false;
                labelDangky.Visible = true;
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                labelError.Visible = false;
                labelErrorNull.Visible = false;
                labelDangky.Visible = true;
            }
        }

        private void rdNguoiThue_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNguoiThue.Checked)
            {
                labelRadio.Visible = false;
                labelDangky.Visible = true;
            }
        }

        private void rdNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNhanVien.Checked)
            {
                labelRadio.Visible = false;
                labelDangky.Visible = true;
            }
        }

        private void rdAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAdmin.Checked)
            {
                labelRadio.Visible = false;
                labelDangky.Visible = true;
            }
        }

        private void tbnDangKy_Click(object sender, EventArgs e)
        {
            DangKyKH dangky = new DangKyKH();
            this.Hide();
            dangky.ShowDialog();
            this.Show();
            resetForm();
            return;
        }
    }
}
