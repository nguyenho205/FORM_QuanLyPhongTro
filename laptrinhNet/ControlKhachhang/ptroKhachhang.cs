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


namespace laptrinhNet.ControlKhachhang
{
    public partial class ptroKhachhang : UserControl
    {
        string connectionString = DangNhap.ConnectionStringHienTai;
        string maKH_HienTai = DangNhap.NguoiDungHienTai;

       
        DataTable dtPhong = new DataTable();
        public ptroKhachhang()
        {
            InitializeComponent();
        }
        private void ptroKhachhang_Load(object sender, EventArgs e)
        {
            LoadThongTinCaNhan();
            LoadDanhSachPhong();

            chkChuaThue.Checked = true;

            chkChuaThue.CheckedChanged += FilterCheckBoxes_CheckedChanged;
            //chkDaThue.CheckedChanged += FilterCheckBoxes_CheckedChanged;
            chkBaoTri.CheckedChanged += FilterCheckBoxes_CheckedChanged;

         
            dgvDanhSachPhong.CellClick += dgvDanhSachPhong_CellClick_1;

            ApplyFilter();
            btnDangKyThue.Enabled = false;
            GiaoDien.ApplyTheme(this);
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

            //if (chkDaThue.Checked)
            //{
                
            //    filters.Add("(TRANGTHAI = 'ĐANG THUÊ' OR TRANGTHAI = 'Đã thuê')");
            //}

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
            }
        }
        private void btnDangky_Click(object sender, EventArgs e)
        {

            
        }

        

        private void dgvDanhSachPhong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDanhSachPhong.Rows.Count) return;

            try
            {
                DataGridViewRow row = dgvDanhSachPhong.Rows[e.RowIndex];

                object valTrangThai = row.Cells["TRANGTHAI"].Value;
                string trangThai = (valTrangThai != null && valTrangThai != DBNull.Value) ? valTrangThai.ToString() : "TRỐNG";

                bool khongDuocThue = trangThai.Equals("Đã thuê", StringComparison.OrdinalIgnoreCase) ||
                                     trangThai.Equals("ĐANG THUÊ", StringComparison.OrdinalIgnoreCase) ||
                                     trangThai.Equals("Bảo trì", StringComparison.OrdinalIgnoreCase);

                if (khongDuocThue)
                {
                    btnDangKyThue.Enabled = false;
                    btnDangKyThue.Text = "Phòng bận";
                    btnDangKyThue.BackColor = Color.Gray;
                    ClearInfo();
                    return;
                }
                else
                {
                    btnDangKyThue.Enabled = true;
                    btnDangKyThue.Text = "Đăng ký thuê";
                    btnDangKyThue.BackColor = Color.DodgerBlue;


                    if (dgvDanhSachPhong.Columns.Contains("MAPHONG"))
                        txtMaPhong.Text = row.Cells["MAPHONG"].Value?.ToString() ?? "";


                    if (dgvDanhSachPhong.Columns.Contains("TENLOAI"))
                        txtLoaiPhong.Text = row.Cells["TENLOAI"].Value?.ToString() ?? "";

                    if (dgvDanhSachPhong.Columns.Contains("GIAPHONG"))
                    {
                        object valGia = row.Cells["GIAPHONG"].Value;
                        if (valGia != null && decimal.TryParse(valGia.ToString(), out decimal gia))
                            txtGiaPhong.Text = gia.ToString("N0");
                        else
                            txtGiaPhong.Text = "0";
                    }

                    if (dgvDanhSachPhong.Columns.Contains("GHICHU"))
                        txtMoTa.Text = row.Cells["GHICHU"].Value?.ToString() ?? "";


                    if (dgvDanhSachPhong.Columns.Contains("TENPHONG"))
                    {

                        object valTenPhong = row.Cells["TENPHONG"].Value;


                        txtTenPhong.Text = (valTenPhong != null) ? valTenPhong.ToString() : "";
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        private void ClearInfo()
        {
            txtMaPhong.Text = "";
            txtLoaiPhong.Text = "";
            txtGiaPhong.Text = "";
            txtMoTa.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangKyThue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn một phòng Trống từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Random rd = new Random();
            string maYC = "YC" + rd.Next(100, 999).ToString();


            string noiDungYC = string.Format(
                "Yêu cầu thuê phòng: {0}\n" +
                "- Loại: {1}\n" +
                "- Giá: {2} VNĐ\n" +
                "- Thời gian thuê: {3} đến {4}\n" +
                "- Ghi chú phòng: {5}\n" +
                "- SĐT Liên hệ: {6}",
                txtMaPhong.Text,
                txtLoaiPhong.Text,
                txtGiaPhong.Text,
                dtpNgayThue.Value.ToString("dd/MM/yyyy"),
                dtpNgayKetThuc.Value.ToString("dd/MM/yyyy"),
                txtMoTa.Text,
                txtSDT.Text
            );


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
                    cmd.Parameters.AddWithValue("@NoiDung", noiDungYC);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Gửi yêu cầu thành công!\nMã yêu cầu: " + maYC, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtMaPhong.Text = "";
                        txtLoaiPhong.Text = "";
                        txtGiaPhong.Text = "";
                        txtMoTa.Text = "";

                        btnDangKyThue.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Không thể gửi yêu cầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                catch (Exception ex)
                {
                }
            }
        }

    }
}

