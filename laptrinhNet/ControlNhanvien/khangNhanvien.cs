using laptrinhNet.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet.ControlNhanvien
{
    public partial class khangNhanvien : UserControl
    {
        public khangNhanvien()
        {
            InitializeComponent();
        }

        private void khangNhanvien_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình giao diện
            SetupGiaoDien();

            // 2. Tải danh sách khách hàng
            LoadDanhSachKhachHang();
            GiaoDien.ApplyTheme(this);
        }

        private void SetupGiaoDien()
        {
            // Mã khách hàng là khóa chính, không cho sửa
            txtMaKH.ReadOnly = true;
        }

        // --- HÀM 1: Tải danh sách khách hàng ---
        private void LoadDanhSachKhachHang()
        {
            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    // Lấy các cột cần thiết
                    var listKH = from kh in db.KhachHangs
                                 select new
                                 {
                                     MaKH = kh.MaKH,
                                     TenKH = kh.TenKH,
                                     CCCD = kh.SoCMND,         // Mapping với cột SOCMND trong SQL
                                     SDT = kh.SoDienThoai,     // Mapping với cột SODIENTHOAI
                                     Email = kh.EmailKhachHang, // Mapping với cột EMAIL_KHACHHANG
                                     DiaChi = kh.DiaChiThuongTru // Mapping với cột DIACHITHUONGTRU
                                 };

                    dgvKhachHang.DataSource = listKH.ToList();

                    // Đặt tên cột tiếng Việt cho đẹp
                    if (dgvKhachHang.Columns["MaKH"] != null) dgvKhachHang.Columns["MaKH"].HeaderText = "Mã KH";
                    if (dgvKhachHang.Columns["TenKH"] != null) dgvKhachHang.Columns["TenKH"].HeaderText = "Họ Tên";
                    if (dgvKhachHang.Columns["CCCD"] != null) dgvKhachHang.Columns["CCCD"].HeaderText = "CCCD/CMND";
                    if (dgvKhachHang.Columns["SDT"] != null) dgvKhachHang.Columns["SDT"].HeaderText = "SĐT";
                    if (dgvKhachHang.Columns["Email"] != null) dgvKhachHang.Columns["Email"].HeaderText = "Email";
                    if (dgvKhachHang.Columns["DiaChi"] != null) dgvKhachHang.Columns["DiaChi"].HeaderText = "Địa Chỉ Thường Trú";
                    dgvKhachHang.Columns["DiaChi"].Width = 250;
                    dgvKhachHang.Columns["TenKH"].Width = 150;
                    dgvKhachHang.Columns["CCCD"].Width = 150;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvKhachHang_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                // Đổ dữ liệu vào các ô
                txtMaKH.Text = row.Cells["MaKH"].Value?.ToString();
                txtTenKH.Text = row.Cells["TenKH"].Value?.ToString();
                txtCCCD.Text = row.Cells["CCCD"].Value?.ToString();
                txtSDT.Text = row.Cells["SDT"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                rtbDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn khách chưa
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nhập liệu cơ bản
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    // 1. Tìm khách hàng theo Mã
                    var kh = db.KhachHangs.FirstOrDefault(x => x.MaKH == txtMaKH.Text);

                    if (kh != null)
                    {
                        // 2. Cập nhật thông tin mới
                        kh.TenKH = txtTenKH.Text.Trim();
                        kh.SoCMND = txtCCCD.Text.Trim();
                        kh.SoDienThoai = txtSDT.Text.Trim();
                        kh.EmailKhachHang = txtEmail.Text.Trim();
                        kh.DiaChiThuongTru = rtbDiaChi.Text.Trim();

                        // 3. Lưu xuống CSDL
                        db.SaveChanges();

                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Tải lại danh sách
                        LoadDanhSachKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khách hàng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
