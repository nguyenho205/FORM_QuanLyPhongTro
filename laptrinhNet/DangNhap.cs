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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDangNhap.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rdAdmin.Checked && !rdNhanVien.Checked && !rdNguoiThue.Checked)
            {
                MessageBox.Show("Vui lòng chọn vai trò đăng nhập (Admin, Nhân viên hoặc Người thuê)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Tạo chuỗi kết nối động
            string serverName = "WIN-LML4B3VMKIT"; // Tên máy chủ của bạn
            string dbName = "QUANLY_PHONGTRO";
            string userId = txtDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            // Cấu trúc chuỗi kết nối chuẩn SQL Server Authentication
            string connectionString = $"Data Source={serverName};Initial Catalog={dbName};User ID={userId};Password={password};MultipleActiveResultSets=True;TrustServerCertificate=True";

            try
            {
                // 3. Thử mở kết nối để kiểm tra User/Pass
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open(); // Nếu sai pass, dòng này sẽ văng lỗi xuống catch

                    // --- KIỂM TRA LOGIC VAI TRÒ (Tránh chọn nhầm) ---

                    // Logic: Mã NV bắt đầu bằng "NV", Khách bằng "KH"
                    // Bạn có thể sửa logic này tùy theo quy tắc đặt tên user của bạn

                    if (rdNhanVien.Checked && !userId.ToUpper().StartsWith("NV"))
                    {
                        MessageBox.Show("Tài khoản này không phải là Nhân Viên!", "Sai vai trò", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (rdNguoiThue.Checked && !userId.ToUpper().StartsWith("KH"))
                    {
                        MessageBox.Show("Tài khoản này không phải là Khách Hàng!", "Sai vai trò", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 4. Đăng nhập thành công -> LƯU SESSION
                    Session.ConnectionString = connectionString;
                    Session.Username = userId;

                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Mở Form tương ứng theo vai trò
                    this.Hide(); // Ẩn form đăng nhập

                    if (rdAdmin.Checked)
                    {
                        // Mở form Admin
                        Admin frmAdmin = new Admin();
                        frmAdmin.ShowDialog();
                    }
                    else if (rdNhanVien.Checked)
                    {
                        // Mở form Nhân viên (FNhanVien)
                        FNhanVien frmNV = new FNhanVien();
                        frmNV.ShowDialog();
                    }
                    else if (rdNguoiThue.Checked)
                    {
                        // Mở form Khách hàng (FKhachHang)
                        FKhachHang frmKH = new FKhachHang();
                        frmKH.ShowDialog();
                    }

                    // Khi form chính tắt, hiện lại form đăng nhập (hoặc đóng luôn tùy bạn)
                    this.Show();
                    txtMatKhau.Clear(); // Xóa pass đi cho an toàn
                }
            }
            catch (SqlException ex)
            {
                // Bắt lỗi SQL (Sai pass, không có quyền, server tắt...)
                if (ex.Number == 18456) // Lỗi sai User/Pass
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phát sinh: " + ex.Message);
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

        }
    }
}
