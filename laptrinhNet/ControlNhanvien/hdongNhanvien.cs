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
using static System.Collections.Specialized.BitVector32;

namespace laptrinhNet.ControlNhanvien
{
    public partial class hdongNhanvien : UserControl
    {
        public hdongNhanvien()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void hdongNhanvien_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình giao diện (Khóa nhập liệu)
            SetupGiaoDien();

            // 2. Tải danh sách hợp đồng
            LoadDanhSachHopDong();
        }

        private void SetupGiaoDien()
        {
            // Chỉ cho xem, không cho sửa
            txtMaHopDong.ReadOnly = true;
            txtTenKhachHang.ReadOnly = true;
            txtTrangThai.ReadOnly = true;
            txtMaPhong.Enabled = false; // Nếu là TextBox thì dùng ReadOnly = true

            // Xử lý ô Trạng thái (Nếu bạn đặt tên là txtTrangThai)
            if (txtTrangThai != null) txtTrangThai.ReadOnly = true;

            dtpTuNgay.Enabled = false;
            dtpDenNgay.Enabled = false;

            btnGuiHopDong.Text = "Tải lại danh sách";
        }

        private void LoadDanhSachHopDong()
        {
            try
            {
                // QUAN TRỌNG: Truyền Session.ConnectionString vào đây
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    var listHD = from hd in db.HopDongs
                                 join kh in db.KhachHangs on hd.MaKH equals kh.MaKH
                                 join pt in db.PhongTros on hd.MaPhong equals pt.MaPhong
                                 select new
                                 {
                                     MaHD = hd.MaHopDong,
                                     TenPhong = pt.TenPhong,  // Hiển thị tên phòng cho dễ nhìn
                                     TenKhach = kh.TenKH,     // Hiển thị tên khách
                                     NgayBD = hd.NgayBD,
                                     NgayKT = hd.NgayKT,
                                     TienCoc = hd.TienCoc,
                                     TrangThai = hd.TrangThai
                                 };

                    // Gán dữ liệu vào DataGridView
                    dgvHopDong.DataSource = listHD.ToList();

                    // Đặt tên cột tiếng Việt cho đẹp (Tùy chọn)
                    if (dgvHopDong.Columns["MaHD"] != null) dgvHopDong.Columns["MaHD"].HeaderText = "Mã HĐ";
                    if (dgvHopDong.Columns["TenPhong"] != null) dgvHopDong.Columns["TenPhong"].HeaderText = "Phòng";
                    if (dgvHopDong.Columns["TenKhach"] != null) dgvHopDong.Columns["TenKhach"].HeaderText = "Khách Hàng";
                    if (dgvHopDong.Columns["TienCoc"] != null) dgvHopDong.Columns["TienCoc"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dgvHopDong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];

                // Lấy giá trị an toàn (tránh lỗi null)
                txtMaHopDong.Text = row.Cells["MaHD"].Value?.ToString();
                txtTenKhachHang.Text = row.Cells["TenKhach"].Value?.ToString();
                txtMaPhong.Text = row.Cells["TenPhong"].Value?.ToString();

                // Gán ô Trạng Thái (Hãy đảm bảo bạn có TextBox tên là txtTrangThai trên form)
                if (txtTrangThai != null)
                {
                    txtTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();
                }

                // Xử lý Ngày tháng (Cần kiểm tra null trước khi gán)
                if (row.Cells["NgayBD"].Value != null)
                    dtpTuNgay.Value = Convert.ToDateTime(row.Cells["NgayBD"].Value);

                if (row.Cells["NgayKT"].Value != null)
                    dtpDenNgay.Value = Convert.ToDateTime(row.Cells["NgayKT"].Value);

                // Xử lý Tiền cọc (Format số đẹp)
                if (row.Cells["TienCoc"].Value != null)
                {
                    decimal tien = Convert.ToDecimal(row.Cells["TienCoc"].Value);
                    txtTienCoc.Text = tien.ToString("N0");
                }
            }
        }

        private void btnGuiHopDong_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu cơ bản
            LoadDanhSachHopDong();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpTungay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void hdongNhanvien_Load_1(object sender, EventArgs e)
        {
            // 1. Cấu hình giao diện (Khóa nhập liệu)
            SetupGiaoDien();

            // 2. Tải danh sách hợp đồng
            LoadDanhSachHopDong();
        }

        private void dgvHopDong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHopDong.Rows[e.RowIndex];

                // Lấy giá trị an toàn (tránh lỗi null)
                txtMaHopDong.Text = row.Cells["MaHD"].Value?.ToString();
                txtTenKhachHang.Text = row.Cells["TenKhach"].Value?.ToString();
                txtMaPhong.Text = row.Cells["TenPhong"].Value?.ToString();

                // Gán ô Trạng Thái (Hãy đảm bảo bạn có TextBox tên là txtTrangThai trên form)
                if (txtTrangThai != null)
                {
                    txtTrangThai.Text = row.Cells["TrangThai"].Value?.ToString();
                }

                // Xử lý Ngày tháng (Cần kiểm tra null trước khi gán)
                if (row.Cells["NgayBD"].Value != null)
                    dtpTuNgay.Value = Convert.ToDateTime(row.Cells["NgayBD"].Value);

                if (row.Cells["NgayKT"].Value != null)
                    dtpDenNgay.Value = Convert.ToDateTime(row.Cells["NgayKT"].Value);

                // Xử lý Tiền cọc (Format số đẹp)
                if (row.Cells["TienCoc"].Value != null)
                {
                    decimal tien = Convert.ToDecimal(row.Cells["TienCoc"].Value);
                    txtTienCoc.Text = tien.ToString("N0");
                }
            }
        }
    }
}
