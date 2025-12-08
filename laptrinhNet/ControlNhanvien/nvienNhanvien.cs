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
    public partial class nvienNhanvien : UserControl
    {
        public nvienNhanvien()
        {
            InitializeComponent();
        }

        private void nvienNhanvien_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình giao diện: Chỉ cho xem, không cho sửa thông tin giao việc
            SetupGiaoDien();

            // 2. Tải danh sách công việc của riêng nhân viên này
            LoadDanhSachCongViec();
        }

        private void SetupGiaoDien()
        {
            txtTenCongViec.ReadOnly = true;
            txtMoTa.ReadOnly = true;        // Mô tả công việc từ quản lý, nhân viên chỉ đọc
            dtpNgayLam.Enabled = false;     // Ngày phân công cố định
        }
        // --- HÀM LOAD DANH SÁCH CÔNG VIỆC TỪ DB ---
        private void LoadDanhSachCongViec()
        {
            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    string currentMaNV = DangNhap.NguoiDungHienTai;

                    var listViec = from pc in db.PhanCongs
                                   join cv in db.CongViecs on pc.MaCV equals cv.MaCV
                                   where pc.MaNV == currentMaNV
                                   select new
                                   {
                                       TenViec = cv.TenCV,
                                       MoTa = cv.MoTaCongViec,
                                       NgayGiao = pc.NgayPhanCong
                                   };

                    dgvCongViec.DataSource = listViec.ToList();

                    // --- PHẦN MỚI: Cấu hình cột ---
                    if (dgvCongViec.Columns["TenViec"] != null) dgvCongViec.Columns["TenViec"].HeaderText = "Tên Công Việc";
                    if (dgvCongViec.Columns["NgayGiao"] != null) dgvCongViec.Columns["NgayGiao"].HeaderText = "Ngày Làm";
                    if (dgvCongViec.Columns["MoTa"] != null) dgvCongViec.Columns["MoTa"].Visible = false;

                    // --- PHẦN MỚI: Thêm cột Button "Xem" ---
                    // Kiểm tra nếu chưa có cột Button thì mới thêm (tránh thêm trùng khi load lại)
                    if (dgvCongViec.Columns["btnXem"] == null)
                    {
                        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                        btn.HeaderText = "Thao tác";
                        btn.Name = "btnXem";
                        btn.Text = "Xem chi tiết";
                        btn.UseColumnTextForButtonValue = true; // Hiển thị chữ "Xem chi tiết" lên nút
                        dgvCongViec.Columns.Add(btn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvCongViec_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                var row = senderGrid.Rows[e.RowIndex];

                // Đổ dữ liệu sang các ô bên phải
                txtTenCongViec.Text = row.Cells["TenViec"].Value?.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value?.ToString();

                if (row.Cells["NgayGiao"].Value != null)
                {
                    dtpNgayLam.Value = Convert.ToDateTime(row.Cells["NgayGiao"].Value);
                }
            }


        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenCongViec.Text))
            {
                MessageBox.Show("Vui lòng chọn một công việc để báo cáo!", "Chưa chọn việc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
