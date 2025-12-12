using laptrinhNet.Database;
using laptrinhNet.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using laptrinhNet.Database;

namespace laptrinhNet.ControlKhachhang
{
    public partial class ptroKhachhang : UserControl
    {
        string connectionString = DangNhap.ConnectionStringHienTai;
        string maKH_HienTai = DangNhap.NguoiDungHienTai;

        // 1. KHAI BÁO DATATABLE TOÀN CỤC ĐỂ LƯU DỮ LIỆU
        DataTable dtPhong = new DataTable();
        public ptroKhachhang()
        {
            InitializeComponent();
        }
        private void ptroKhachhang_Load(object sender, EventArgs e)
        {
            LoadThongTinCaNhan();
            LoadDanhSachPhong();

            // Mặc định chọn xem phòng trống
            chkChuaThue.Checked = true;

            // Đăng ký sự kiện CheckBox
            chkChuaThue.CheckedChanged += FilterCheckBoxes_CheckedChanged;
            chkDaThue.CheckedChanged += FilterCheckBoxes_CheckedChanged;
            chkBaoTri.CheckedChanged += FilterCheckBoxes_CheckedChanged;

            // --- QUAN TRỌNG: ĐĂNG KÝ SỰ KIỆN CLICK CHO DATAGRIDVIEW ---
            // Nếu thiếu dòng này, click vào bảng sẽ không có tác dụng gì cả
            dgvDanhSachPhong.CellClick += dgvDanhSachPhong_CellClick;

            // Áp dụng bộ lọc ngay khi mở
            ApplyFilter();
            btnDangKyThue.Enabled = false;
        }


        private void LoadThongTinCaNhan()
        {
            if (string.IsNullOrEmpty(maKH_HienTai)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TENKH, SOCMND, SODIENTHOAI, EMAIL_KHACHHANG FROM KHACHHANG WHERE MAKH = @MaKH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKH", maKH_HienTai);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtTenNguoiDangKy.Text = reader["TENKH"].ToString();
                        txtCCCD.Text = reader["SOCMND"].ToString();
                        txtSDT.Text = reader["SODIENTHOAI"].ToString();
                        txtEmail.Text = reader["EMAIL_KHACHHANG"].ToString();

                        // Khóa các ô này lại để không cho sửa (nếu muốn)
                        txtTenNguoiDangKy.ReadOnly = true;
                        txtCCCD.ReadOnly = true;
                        txtSDT.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        txtTenNguoiDangKy.Enabled = false;
                        txtCCCD.Enabled = false;
                        txtSDT.Enabled = false;
                        txtEmail.Enabled = false;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lấy thông tin cá nhân: " + ex.Message);
                }
            }
        }

 
        private void LoadDanhSachPhong()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        SELECT P.MAPHONG, P.TENPHONG, L.TENLOAI, L.GIAPHONG, P.TRANGTHAI, P.GHICHU 
                        FROM PHONGTRO P 
                        JOIN LOAI_PHONGTRO L ON P.MALOAI = L.MALOAI";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    
                    dtPhong.Clear();
                    da.Fill(dtPhong);

                    dgvDanhSachPhong.DataSource = dtPhong;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load danh sách phòng: " + ex.Message);
                }
            }
        }

        private void FilterCheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            if (dtPhong == null || dtPhong.Rows.Count == 0) return;

            List<string> filters = new List<string>();

    

            if (chkChuaThue.Checked)
            {
                filters.Add("(TRANGTHAI = 'TRỐNG' OR TRANGTHAI IS NULL)");
            }

            if (chkDaThue.Checked)
            {
                
                filters.Add("(TRANGTHAI = 'ĐANG THUÊ' OR TRANGTHAI = 'Đã thuê')");
            }

            if (chkBaoTri.Checked)
            {
                filters.Add("TRANGTHAI = 'Bảo trì'");
            }

            try
            {
                if (filters.Count > 0)
                {
                    string filterExpression = string.Join(" OR ", filters);
                    dtPhong.DefaultView.RowFilter = filterExpression;
                }
                else
                {
                    
                    dtPhong.DefaultView.RowFilter = "1 = 0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void btnDangky_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn một phòng Trống từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. TẠO MÃ YÊU CẦU NGẮN (FIX LỖI "String or binary data would be truncated")
            // Database chỉ cho 5 ký tự -> Dùng "YC" + 3 số ngẫu nhiên (Ví dụ: YC159)
            Random rd = new Random();
            string maYC = "YC" + rd.Next(100, 999).ToString();

            // 3. TẠO NỘI DUNG YÊU CẦU
            // Gộp tất cả thông tin phòng vào đây vì bảng YEUCAUHOTRO không có cột Mã Phòng
            string noiDungYC = string.Format(
                "Yêu cầu thuê phòng: {0}\n" +
                "- Loại: {1}\n" +
                "- Giá: {2} VNĐ\n" +
                "- Thời gian thuê: {3} đến {4}\n" +
                "- Ghi chú phòng: {5}\n" +
                "- SĐT Liên hệ: {6}",
                txtMaPhong.Text,                                // 0
                txtLoaiPhong.Text,                              // 1
                txtGiaPhong.Text,                               // 2
                dtpNgayThue.Value.ToString("dd/MM/yyyy"),       // 3
                dtpNgayKetThuc.Value.ToString("dd/MM/yyyy"),    // 4
                txtMoTa.Text,                                   // 5
                txtSDT.Text                                     // 6
            );

            // 4. GỬI DỮ LIỆU XUỐNG SQL
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                INSERT INTO YEUCAUHOTRO (MAYEUCAU, MAKH, NGAYGUI, NOIDUNG, TRANGTHAI, PHANHOI) 
                VALUES (@MaYC, @MaKH, GETDATE(), @NoiDung, N'Chưa xử lý', N'Chờ nhân viên xác nhận')";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaYC", maYC);
                    cmd.Parameters.AddWithValue("@MaKH", maKH_HienTai);
                    cmd.Parameters.AddWithValue("@NoiDung", noiDungYC); // Nội dung đã gộp ở trên

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Gửi yêu cầu thành công!\nMã yêu cầu: " + maYC, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset các ô nhập liệu sau khi gửi xong
                        txtMaPhong.Text = "";
                        txtLoaiPhong.Text = "";
                        txtGiaPhong.Text = "";
                        txtMoTa.Text = "";

                        // Tắt nút đăng ký để tránh bấm nhầm 2 lần
                        btnDangKyThue.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không thể gửi yêu cầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Bắt riêng lỗi trùng khóa chính (nếu xui xẻo random trúng mã cũ)
                    if (sqlEx.Number == 2627)
                    {
                        MessageBox.Show("Lỗi trùng mã yêu cầu, vui lòng thử lại lần nữa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                }
            }
        }

        

        private void dgvDanhSachPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDanhSachPhong.Rows.Count) return;

            try
            {
                DataGridViewRow row = dgvDanhSachPhong.Rows[e.RowIndex];

                // 2. Lấy trạng thái an toàn
                object valTrangThai = row.Cells["TRANGTHAI"].Value;
                string trangThai = "TRỐNG";

                if (valTrangThai != null && valTrangThai != DBNull.Value)
                {
                    trangThai = valTrangThai.ToString();
                }

                // 3. Kiểm tra điều kiện KHÔNG CHO THUÊ
                bool khongDuocThue = trangThai.Equals("Đã thuê", StringComparison.OrdinalIgnoreCase) ||
                                     trangThai.Equals("ĐANG THUÊ", StringComparison.OrdinalIgnoreCase) ||
                                     trangThai.Equals("Bảo trì", StringComparison.OrdinalIgnoreCase);

                if (khongDuocThue)
                {
                    // --- TẮT NÚT ĐĂNG KÝ ---
                    btnDangKyThue.Enabled = false;
                    // Đổi màu nút cho người dùng dễ nhận biết (tùy chọn)
                    btnDangKyThue.BackColor = Color.Gray;
                    btnDangKyThue.Text = "Phòng bận";

                    // Xóa thông tin phòng bên phải
                    ClearInfo();
                }
                else
                {
                    // --- BẬT NÚT ĐĂNG KÝ (Trường hợp phòng TRỐNG) ---
                    btnDangKyThue.Enabled = true;
                    btnDangKyThue.BackColor = Color.DodgerBlue; // Hoặc màu gốc của bạn
                    btnDangKyThue.Text = "Đăng ký thuê";

                    // Đổ dữ liệu vào textbox
                    object valMa = row.Cells["MAPHONG"].Value;
                    txtMaPhong.Text = (valMa != null && valMa != DBNull.Value) ? valMa.ToString() : "";

                    object valLoai = row.Cells["TENLOAI"].Value;
                    txtLoaiPhong.Text = (valLoai != null && valLoai != DBNull.Value) ? valLoai.ToString() : "";

                    object valGia = row.Cells["GIAPHONG"].Value;
                    if (valGia != null && valGia != DBNull.Value && decimal.TryParse(valGia.ToString(), out decimal gia))
                    {
                        txtGiaPhong.Text = gia.ToString("N0");
                    }
                    else
                    {
                        txtGiaPhong.Text = "0";
                    }

                    object valGhiChu = row.Cells["GHICHU"].Value;
                    txtMoTa.Text = (valGhiChu != null && valGhiChu != DBNull.Value) ? valGhiChu.ToString() : "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi: " + ex.Message);
            }
        }
        private void ClearInfo()
        {
            txtMaPhong.Text = "";
            txtLoaiPhong.Text = "";
            txtGiaPhong.Text = "";
            txtMoTa.Text = "";
        }

    }
}

