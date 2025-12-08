using laptrinhNet.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet
{
    public partial class DangNhap : Form
    {
        public static string ConnectionStringHienTai = "";
        public static string NguoiDungHienTai = "";
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

            txtDangNhap.Clear();
            txtMatKhau.Clear();

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


            //checkRadio();

            //// Nếu chưa chọn radio thì không tiếp tục xử lý đăng nhập
            //if (!rdNhanVien.Checked && !rdNguoiThue.Checked && !rdAdmin.Checked)
            //{
            //    // Không đăng nhập được nếu chưa chọn chức vụ
            //    return;
            //}

            //if (txtDangNhap.Text == "sa" && txtMatKhau.Text == "123" && rdAdmin.Checked)
            //{
            //    labelError.Visible = false;
            //    //Hien trang menu khi bam dang nhap
            //    //BamDang nhap hien menu thi dang nhap bien mat
            //    Admin menuAdmin = new Admin();
            //    this.Hide();
            //    menuAdmin.ShowDialog();
            //    this.Show();
            //    resetForm();

            //}
            //if (txtDangNhap.Text=="sa" && txtMatKhau.Text=="123" && rdNhanVien.Checked)
            //{
            //    labelError.Visible = false;
            //    //Hien trang menu khi bam dang nhap
            //    //BamDang nhap hien menu thi dang nhap bien mat
            //    FNhanVien menuNhanvien = new FNhanVien();
            //    this.Hide();
            //    menuNhanvien.ShowDialog();
            //    this.Show();
            //    resetForm();
            //}
            //if (txtDangNhap.Text == "sa" && txtMatKhau.Text == "123" && rdNguoiThue.Checked)
            //{
            //    labelError.Visible = false;
            //    //Hien trang menu khi bam dang nhap
            //    //BamDang nhap hien menu thi dang nhap bien mat
            //    FKhachHang menuKhachhang = new FKhachHang();
            //    this.Hide();
            //    menuKhachhang.ShowDialog();
            //    this.Show();
            //    resetForm();
            //}

            //labelError.Visible = true;


            string tenDangNhap = txtDangNhap.Text.Trim(); // Tên TextBox nhập user
            string matKhau = txtMatKhau.Text.Trim();         // Tên TextBox nhập pass

            // Kiểm tra nhập liệu
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Tạo chuỗi kết nối động dựa trên User nhập vào
            // Thay "TEN_MAY_TINH" bằng tên Server của bạn (ví dụ: .\SQLEXPRESS hoặc tên máy)
            string serverName = @"DESKTOP-IQCO6JU\SQLEXPRESS"; // <--- SỬA TÊN SERVER CỦA BẠN Ở ĐÂY
            string databaseName = "QUANLY_PHONGTRO";

            string connectionString = $"Data Source={serverName};Initial Catalog={databaseName};User ID={tenDangNhap};Password={matKhau};TrustServerCertificate=True;";

            // 2. Thử kết nối để xác thực
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // --> Nếu chạy qua dòng này nghĩa là Đăng nhập thành công

                    // Lưu lại thông tin để dùng cho các Form khác
                    ConnectionStringHienTai = connectionString;
                    NguoiDungHienTai = tenDangNhap;

                    // 3. Phân quyền mở Form dựa trên tên đăng nhập
                    PhanQuyenVaMoForm(tenDangNhap);
                }
                catch (SqlException)
                {
                    // Lỗi kết nối (thường là sai User hoặc Pass)
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PhanQuyenVaMoForm(string username)
        {
            this.Hide(); // Ẩn form đăng nhập
            Form formCanMo = null;

            // Chuyển về chữ hoa để so sánh cho chính xác
            string u = username.ToUpper();

            // LOGIC PHÂN QUYỀN CỦA BẠN:
            if (u == "NV01")
            {
                // User 1 (NV01) là Admin -> Qua trang Admin
                formCanMo = new Admin();
            }
            else if (u.StartsWith("NV"))
            {
                // Các User bắt đầu bằng NV (NV02, NV03...) -> Qua trang Nhân Viên
                formCanMo = new FNhanVien();
            }
            else if (u.StartsWith("KH"))
            {
                // Các User bắt đầu bằng KH (KH01, KH02...) -> Qua trang Khách Hàng
                formCanMo = new FKhachHang();
            }
            else
            {
                MessageBox.Show("Tài khoản này không có quyền truy cập ứng dụng!", "Cảnh báo");
                this.Show();
                return;
            }

            // Mở form và xử lý khi form đó đóng lại
            if (formCanMo != null)
            {
                formCanMo.ShowDialog();
                this.Show(); // Hiện lại form đăng nhập khi form con tắt
                txtMatKhau.Clear(); // Xóa mật khẩu cũ cho an toàn
            }

        }
        public void checkRadio()
        {
            //if (!rdNhanVien.Checked && !rdNguoiThue.Checked && !rdAdmin.Checked)
            //{
            //    labelRadio.Visible = true;
            //}
            //else
            //{ labelRadio.Visible = false; }

        }



        public void resetForm()
        {

            //labelError.Visible = false;
            //txtDangNhap.Clear();
            //txtMatKhau.Clear();
            //rdAdmin.Checked = false;
            //rdNhanVien.Checked = false;
            //rdNguoiThue.Checked = false;

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
