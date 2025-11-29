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
            labelError.Visible = false;
            labelRadio.Visible = false;
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát trang không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            checkRadio();

            // Nếu chưa chọn radio thì không tiếp tục xử lý đăng nhập
            if (!rdNhanVien.Checked && !rdNguoiThue.Checked && !rdAdmin.Checked)
            {
                // Không đăng nhập được nếu chưa chọn chức vụ
                return;
            }

            if (txtDangNhap.Text == "sa" && txtMatKhau.Text == "123" && rdAdmin.Checked)
            {
                labelError.Visible = false;
                //Hien trang menu khi bam dang nhap
                //BamDang nhap hien menu thi dang nhap bien mat
                Admin menuAdmin = new Admin();
                this.Hide();
                menuAdmin.ShowDialog();
                this.Show();
                resetForm();

            }
            if (txtDangNhap.Text=="sa" && txtMatKhau.Text=="123" && rdNhanVien.Checked)
            {
                labelError.Visible = false;
                //Hien trang menu khi bam dang nhap
                //BamDang nhap hien menu thi dang nhap bien mat
                NhanVien menuNhanvien = new NhanVien();
                this.Hide();
                menuNhanvien.ShowDialog();
                this.Show();
                resetForm();
            }
            if (txtDangNhap.Text == "sa" && txtMatKhau.Text == "123" && rdNguoiThue.Checked)
            {
                labelError.Visible = false;
                //Hien trang menu khi bam dang nhap
                //BamDang nhap hien menu thi dang nhap bien mat
                KhachHang menuKhachhang = new KhachHang();
                this.Hide();
                menuKhachhang.ShowDialog();
                this.Show();
                resetForm();
            }

            labelError.Visible = true;

        }
        public void checkRadio()
        {
            if (!rdNhanVien.Checked && !rdNguoiThue.Checked && !rdAdmin.Checked)
            {
                labelRadio.Visible = true;
            }
            else
            { labelRadio.Visible = false; }
        }

        public void resetForm()
        {
            labelError.Visible = false;
            txtDangNhap.Clear();
            txtMatKhau.Clear();
            rdAdmin.Checked = false;
            rdNhanVien.Checked = false;
            rdNguoiThue.Checked = false;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
