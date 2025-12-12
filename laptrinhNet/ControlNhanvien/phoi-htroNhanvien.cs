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

namespace laptrinhNet.ControlNhanvien
{
    public partial class phoi_htroNhanvien : UserControl
    {
        
        public phoi_htroNhanvien()
        {
            InitializeComponent();
        }

        private void phoi_htroNhanvien_Load(object sender, EventArgs e)
        {
            SetupGiaoDien();
            LoadDanhSachYeuCau();
        }


        private void SetupGiaoDien()
        {
            txtMaYeuCau.ReadOnly = true;
            txtNoiDung.ReadOnly = true;
            // Xóa trắng
            txtMaYeuCau.Text = "";
            txtNoiDung.Text = "";
            rtbPhanHoi.Text = "";
        }

        private void LoadDanhSachYeuCau()
        {
            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    // 1. Lấy Mã Nhân Viên đang đăng nhập
                    string maNVHienTai = DangNhap.NguoiDungHienTai;

                    var list = from yc in db.YeuCauHoTros
                               join kh in db.KhachHangs on yc.MaKH equals kh.MaKH
                               // 2. THÊM ĐIỀU KIỆN LỌC TẠI ĐÂY:
                               // Chỉ lấy những dòng mà cột MaNV trong bảng YeuCauHoTro trùng với MaNV đang đăng nhập
                               where yc.MaNV_XuLy == maNVHienTai

                               // Sắp xếp: Chưa xử lý -> Đang xử lý -> Đã xử lý, sau đó đến ngày mới nhất
                               orderby (yc.TrangThai == "Chưa xử lý" ? 1 :
                                       (yc.TrangThai == "Đang xử lý" ? 2 : 3)),
                                       yc.NgayGui descending
                               select new
                               {
                                   MaYC = yc.MaYeuCau,
                                   TenKhach = kh.TenKH,
                                   NoiDung = yc.NoiDung,
                                   TrangThai = yc.TrangThai,
                                   NgayGui = yc.NgayGui,
                                   PhanHoi = yc.PhanHoi
                               };

                    dgvYeuCau.DataSource = list.ToList();

                    // Đặt tên cột hiển thị
                    if (dgvYeuCau.Columns["MaYC"] != null) dgvYeuCau.Columns["MaYC"].HeaderText = "Mã YC";
                    if (dgvYeuCau.Columns["TenKhach"] != null) dgvYeuCau.Columns["TenKhach"].HeaderText = "Khách Hàng";
                    if (dgvYeuCau.Columns["NoiDung"] != null) dgvYeuCau.Columns["NoiDung"].HeaderText = "Nội dung";
                    if (dgvYeuCau.Columns["TrangThai"] != null) dgvYeuCau.Columns["TrangThai"].HeaderText = "Trạng thái";
                    if (dgvYeuCau.Columns["NgayGui"] != null) dgvYeuCau.Columns["NgayGui"].HeaderText = "Ngày gửi";

                    // Ẩn cột Phản hồi nếu không muốn hiện trên lưới (vì đã hiện ở TextBox bên dưới)
                    if (dgvYeuCau.Columns["PhanHoi"] != null) dgvYeuCau.Columns["PhanHoi"].Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void dgvYeuCau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvYeuCau.Rows[e.RowIndex];
                txtMaYeuCau.Text = row.Cells["MaYC"].Value?.ToString();
                txtNoiDung.Text = row.Cells["NoiDung"].Value?.ToString();
                rtbPhanHoi.Text = row.Cells["PhanHoi"].Value?.ToString();

                // Nếu đã xử lý rồi thì có thể cảnh báo hoặc khóa nút (tùy chọn)
                string trangThai = row.Cells["TrangThai"].Value?.ToString();
                // btnGuiPhanHoi.Enabled = (trangThai != "Đã xử lý"); 
            }
        }

        private void rtbPhanHoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuiPhanHoi_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (string.IsNullOrEmpty(txtMaYeuCau.Text))
            {
                MessageBox.Show("Vui lòng chọn yêu cầu cần trả lời!", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(rtbPhanHoi.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập nội dung phản hồi!", "Thiếu nội dung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Chuẩn bị tham số
            string maYC = txtMaYeuCau.Text;
            string noiDungTraLOi = rtbPhanHoi.Text.Trim();
            // Lấy mã nhân viên từ biến toàn cục form Đăng nhập
            string maNV = DangNhap.NguoiDungHienTai;

            // 3. Gọi Stored Procedure
            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    // Tạo danh sách tham số SQL
                    var pMaYC = new SqlParameter("@MAYEUCAU", maYC);
                    var pMaNV = new SqlParameter("@MANV", maNV);
                    var pNoiDung = new SqlParameter("@NOIDUNGPHANHOI", noiDungTraLOi);

                    // ExecuteSqlCommand dùng để chạy câu lệnh UPDATE, INSERT, DELETE hoặc SP không trả về dữ liệu
                    int rowsAffected = db.Database.ExecuteSqlCommand(
                        "EXEC SP_NHANVIEN_TRALOI_HOTRO @MAYEUCAU, @MANV, @NOIDUNGPHANHOI",
                        pMaYC, pMaNV, pNoiDung);

                    // 4. Thông báo và tải lại
                    MessageBox.Show("Đã gửi phản hồi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset form
                    txtMaYeuCau.Text = "";
                    txtNoiDung.Text = "";
                    rtbPhanHoi.Text = "";

                    // Tải lại danh sách để thấy trạng thái cập nhật
                    LoadDanhSachYeuCau();
                }
            }
            //catch (SqlException sqlEx)
            //{
            //    // Bắt lỗi từ chính SP trả về (RAISERROR)
            //    MessageBox.Show("Lỗi SQL: " + sqlEx.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            catch (Exception ex)
            {
            }
        }
    }

}
