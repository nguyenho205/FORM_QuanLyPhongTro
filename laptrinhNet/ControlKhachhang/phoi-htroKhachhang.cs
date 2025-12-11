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

            btnClean_Click(sender, e);
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
                // Nếu người dùng bỏ chọn checkbox hiện tại -> Tự động quay về "Tất cả"
                // Để tránh trường hợp không chọn cái nào cả
                checkAll.Checked = true;
            }

            isLoadingCheckbox = false; // Xong việc, mở lại cờ

            // Sau khi chỉnh xong checkbox, gọi hàm load dữ liệu
            LoadDanhSachPhanHoi();
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
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }
        private void btnGui_Click(object sender, EventArgs e)
        {
          if (string.IsNullOrEmpty(txtNoidung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung cần hỗ trợ!", "Thông báo");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO YEUCAUHOTRO (MAYEUCAU, MAKH, NGAYGUI, NOIDUNG, TRANGTHAI) 
                                     VALUES (@MaYC, @MaKH, GETDATE(), @NoiDung, N'Chưa xử lý')";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaYC", txtMaPhanHoi.Text);
                    cmd.Parameters.AddWithValue("@MaKH", maKhachHang);
                    cmd.Parameters.AddWithValue("@NoiDung", txtNoidung.Text);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Đã gửi yêu cầu thành công!", "Thông báo");
                        
                        
                       checkAll.Checked = true; 

                        btnClean_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            XuLyCheckbox(checkAll);
        }

        private void checkChuaXL_CheckedChanged(object sender, EventArgs e)
        {
            XuLyCheckbox(checkChuaXL);
        }

        private void checkDangXL_CheckedChanged(object sender, EventArgs e)
        {
            XuLyCheckbox(checkDangXL);
        }

        private void checkDaXL_CheckedChanged(object sender, EventArgs e)
        {
            XuLyCheckbox(checkDaXL);
        }
       
        
       

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtMaPhanHoi.Text = TaoMaYeuCauMoi(); // Sinh mã mới
            txtNoidung.Clear();

            
            LayThongTinKhachHang();

            txtNoidung.ReadOnly = false;
            btnGui.Enabled = true;

            txtNoidung.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Đổ dữ liệu từ dòng được chọn lên các ô
                txtMaPhanHoi.Text = row.Cells["MAYEUCAU"].Value.ToString();
                txtNoidung.Text = row.Cells["NOIDUNG"].Value.ToString();

                // Hiển thị thông tin người gửi (Lấy lại thông tin của user hiện tại cho đẹp)
                LayThongTinKhachHang();

         
                txtNoidung.ReadOnly = true;
                btnGui.Enabled = false; 
            }
        }
        private void LayThongTinKhachHang()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Lấy tên KH và Phòng đang thuê (Hợp đồng còn hạn)
                string query = @"SELECT K.TENKH, P.TENPHONG 
                                 FROM KHACHHANG K
                                 LEFT JOIN HOPDONG H ON K.MAKH = H.MAKH AND H.TRANGTHAI = N'Còn hạn'
                                 LEFT JOIN PHONGTRO P ON H.MAPHONG = P.MAPHONG
                                 WHERE K.MAKH = @MaKH";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKhachHang);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtTen.Text = dr["TENKH"].ToString();

                    txtSophong.Text = dr["TENPHONG"] != DBNull.Value ? dr["TENPHONG"].ToString() : "Chưa thuê";
                }
            }
        }
        private string TaoMaYeuCauMoi()
        {
            string maMoi = "YC001";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 MAYEUCAU FROM YEUCAUHOTRO ORDER BY MAYEUCAU DESC", conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string maCu = result.ToString();
                    // Cắt lấy số và tăng lên 1 (Ví dụ YC009 -> 9 + 1 = 10 -> YC010)
                    int so = int.Parse(maCu.Substring(2));
                    maMoi = "YC" + (so + 1).ToString("D3");
                }
            }
            return maMoi;
        }
    }
}
