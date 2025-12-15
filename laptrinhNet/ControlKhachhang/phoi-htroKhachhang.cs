using laptrinhNet.Database;
using laptrinhNet.Database.Entities;
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

namespace laptrinhNet.ControlKhachhang
{
    public partial class phoi_htroKhachhang : UserControl
    {

        string connectionString = DangNhap.ConnectionStringHienTai;
        string maKhachHang = DangNhap.NguoiDungHienTai;
        bool isLoadingCheckbox = false;

        public phoi_htroKhachhang()
        {
            InitializeComponent();
        }


        private void phoi_htroKhachhang_Load(object sender, EventArgs e)
        {

            checkAll.Checked = true;

            btnClean_Click_1(sender, e);
            GiaoDien.ApplyTheme(this);
            txtMaPhanHoi.Enabled = false;
            // 1. Bật tính năng tự động chỉnh chiều cao của dòng (Row)
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // 2. Chọn cột cần xuống dòng (Ví dụ cột "NoiDung" hoặc index cột)
            // Lưu ý: Thay "NoiDung" bằng tên thật (Name) của cột trong code bạn
            dataGridView1.Columns["NOIDUNG"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // (Tùy chọn) Đặt chiều rộng cố định cho cột đó để nó không bị co giãn lung tung
            dataGridView1.Columns["NOIDUNG"].Width = 300;

        }
        private void XuLyCheckbox(CheckBox chkDuocChon)
        {
            if (isLoadingCheckbox) return;
            isLoadingCheckbox = true; // Bắt đầu xử lý, chặn các sự kiện khác

            // Logic: Chỉ cho phép chọn 1 checkbox tại 1 thời điểm (giống RadioButton)
            if (chkDuocChon.Checked)
            {
                // Nếu cái này được chọn, bỏ chọn các cái khác
                if (chkDuocChon != checkAll) checkAll.Checked = false;
                if (chkDuocChon != checkChuaXL) checkChuaXL.Checked = false;
                if (chkDuocChon != checkDangXL) checkDangXL.Checked = false;
                if (chkDuocChon != checkDaXL) checkDaXL.Checked = false;
            }
            else
            {
                checkAll.Checked = true;
            }

            isLoadingCheckbox = false; // Xong việc, mở lại cờ

            LoadDanhSachPhanHoi();
            txtMaPhanHoi.Enabled = false;
            txtTen.Enabled = false;
        }
        private void LoadDanhSachPhanHoi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Câu truy vấn gốc (Lấy phản hồi của KH đang đăng nhập)
                    string query = @"
                        SELECT MAYEUCAU, NGAYGUI, NOIDUNG, TRANGTHAI, PHANHOI 
                        FROM YEUCAUHOTRO 
                        WHERE MAKH = @MaKH ";

                    // Ghép thêm điều kiện lọc theo Checkbox
                    if (checkChuaXL.Checked)
                    {
                        query += " AND TRANGTHAI = N'Chưa xử lý'";
                    }
                    else if (checkDangXL.Checked)
                    {
                        query += " AND TRANGTHAI = N'Đang xử lý'";
                    }
                    else if (checkDaXL.Checked)
                    {
                        query += " AND TRANGTHAI = N'Đã xử lý'";
                    }
                    // Nếu chkTatCa.Checked thì không cần cộng thêm gì cả (lấy hết)

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKH", maKhachHang);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void btnGui_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNoidung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem khách có chọn phòng không (nếu có ComboBox)
            string phongDuocChon = "";
            if (cboPhong.Items.Count > 0 && cboPhong.SelectedValue != null)
            {
                // Lấy tên phòng từ ComboBox để lưu chú thích (hoặc lấy ValueMember là MAPHONG nếu DB có cột MAPHONG)
                // Ở đây mình giả sử DB chưa có cột MAPHONG, nên mình sẽ nối tên phòng vào nội dung cho dễ quản lý.
                phongDuocChon = "[" + cboPhong.Text + "] ";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string maMoi = TaoMaYeuCauMoi(conn);

                    // Ghép tên phòng vào nội dung gửi đi: "[Phòng 101] Bóng đèn bị cháy"
                    string noiDungGui = phongDuocChon + txtNoidung.Text.Trim();

                    string query = @"INSERT INTO YEUCAUHOTRO (MAYEUCAU, MAKH, NGAYGUI, NOIDUNG, TRANGTHAI) 
                                     VALUES (@MaYC, @MaKH, GETDATE(), @NoiDung, N'Chưa xử lý')";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaYC", maMoi);
                        cmd.Parameters.AddWithValue("@MaKH", maKhachHang);
                        cmd.Parameters.AddWithValue("@NoiDung", noiDungGui);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Gửi yêu cầu thành công!", "Thông báo");
                            btnClean_Click_1(sender, e);
                            checkAll.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private string TaoMaYeuCauMoi(SqlConnection conn)
        {
            string maMoi = "YC001";
            string query = "SELECT TOP 1 MAYEUCAU FROM YEUCAUHOTRO ORDER BY MAYEUCAU DESC";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string maCu = result.ToString();
                    if (maCu.Length > 2 && int.TryParse(maCu.Substring(2), out int so))
                    {
                        maMoi = "YC" + (so + 1).ToString("D3");
                    }
                }
            }
            return maMoi;
        }
        private void checkAll_CheckedChanged_1(object sender, EventArgs e)
        {
            XuLyCheckbox(checkAll);
            checkChuaXL.Checked = false;
            checkDangXL.Checked = false;
            checkDaXL.Checked = false;
        }

        private void checkChuaXL_CheckedChanged_1(object sender, EventArgs e)
        {
            XuLyCheckbox(checkChuaXL);
            checkAll.Checked = false;
            checkDangXL.Checked = false;
            checkDaXL.Checked = false;
        }

        private void checkDangXL_CheckedChanged_1(object sender, EventArgs e)
        {
            XuLyCheckbox(checkDangXL);
            checkAll.Checked = false;
            checkChuaXL.Checked = false;
            checkDaXL.Checked = false;
        }

        private void checkDaXL_CheckedChanged_1(object sender, EventArgs e)
        {
            XuLyCheckbox(checkDaXL);
            checkAll.Checked = false;
            checkChuaXL.Checked = false;
            checkDangXL.Checked = false;
        }
       
        
       

        private void btnClean_Click_1(object sender, EventArgs e)
        {
            txtMaPhanHoi.Text = "(Tự động sinh)";
            txtNoidung.Clear();

            // Load lại thông tin khách và danh sách phòng vào ComboBox
            LayThongTinKhachHang();

            txtNoidung.ReadOnly = false;
            btnGui.Enabled = true;
            cboPhong.Enabled = true; // Cho phép chọn phòng
            txtNoidung.Focus();
            LoadDanhSachPhanHoi();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtMaPhanHoi.Text = row.Cells["MAYEUCAU"].Value.ToString();
                txtNoidung.Text = row.Cells["NOIDUNG"].Value.ToString();

           
                LayThongTinKhachHang();

                txtNoidung.ReadOnly = true;
                cboPhong.Enabled = false; 
                btnGui.Enabled = false;
            }
        }
        private void LayThongTinKhachHang()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Lấy Tên Khách Hàng
                    string queryTen = "SELECT TENKH FROM KHACHHANG WHERE MAKH = @MaKH";
                    using (SqlCommand cmd = new SqlCommand(queryTen, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", maKhachHang);
                        object tenObj = cmd.ExecuteScalar();
                        if (tenObj != null) txtTen.Text = tenObj.ToString();
                    }

                    // 2. Lấy Danh Sách Phòng mà khách này đang thuê (Hợp đồng còn hạn)
                    string queryPhong = @"SELECT P.MAPHONG, P.TENPHONG
                                          FROM HOPDONG H
                                          JOIN PHONGTRO P ON H.MAPHONG = P.MAPHONG
                                          WHERE H.MAKH = @MaKH AND H.TRANGTHAI = N'Còn hạn'";

                    using (SqlCommand cmd = new SqlCommand(queryPhong, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKH", maKhachHang);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Đổ dữ liệu vào ComboBox (cboPhong)
                        cboPhong.DataSource = dt;
                        cboPhong.DisplayMember = "TENPHONG"; // Hiển thị tên phòng (VD: Phòng 101)
                        cboPhong.ValueMember = "MAPHONG";    // Giá trị ẩn là Mã phòng (VD: P01)

                        // Nếu không thuê phòng nào
                        if (dt.Rows.Count == 0)
                        {
                            cboPhong.DataSource = null;
                            cboPhong.Items.Clear();
                            cboPhong.Items.Add("Chưa thuê phòng");
                            cboPhong.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Có thể log lỗi
            }
        }


    }
}
