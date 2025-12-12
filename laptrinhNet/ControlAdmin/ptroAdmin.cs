using laptrinhNet.Database;
using laptrinhNet.Database.DTOs;
using laptrinhNet.Database.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace laptrinhNet.ControlAdmin
{
    public partial class ptroAdmin : UserControl
    {
        public ptroAdmin()
        {
            InitializeComponent();
        }

        private void ptroAdmin_Load(object sender, EventArgs e)
        {

            LoadData();

        }

        // ============================================
        // 1) LOAD DỮ LIỆU
        // ============================================
        private void LoadData()
        {
            using (var db = new QLPhongTroDataContext())
            {

                cbo_TrangThai_PT.DataSource = new string[] { "ĐANG THUÊ", "TRỐNG" };
                var ds = db.LoaiPhongTros.Select(t => t.MaLoai).ToList();
                cbo_TenLoai_PT.DataSource = ds;
                // Lọc dữ liệu

                var list = db.PhongTros
                    .ToList()
                    .Select(sv => new PhongTroDTO
                    {
                       MAPHONG = sv.MaPhong,
                        TENPHONG = sv.TenPhong,
                        MALOAI = sv.MaLoai,
                        TENLOAI = sv.LoaiPTDaTa.TenLoai,
                        TRANGTHAI = sv.TrangThai,
                        SONGUOIHIENTAI = sv.SoNguoiHienTai,
                        GHICHU = sv.GhiChu,
                    })
                    .ToList();
                grid_PhongTro.DataSource = list;
            }
        }

        private void chk_DaThue_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void chk_ChuaThue_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_ThemPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaPhong_PT.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phòng!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_SoPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_SoNGHienTai.Text))
            {
                MessageBox.Show("Vui lòng nhập số người của phòng!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                if (db.PhongTros.Any(p => p.MaPhong == txt_MaPhong_PT.Text))
                {
                    MessageBox.Show("Mã phòng đã tồn tại!");
                    return;
                }

                var pt = new PhongTro
                {
                    MaPhong = txt_MaPhong_PT.Text,
                    TenPhong = txt_SoPhong.Text,
                    MaLoai = cbo_TenLoai_PT.SelectedValue.ToString(),
                    TrangThai = cbo_TrangThai_PT.SelectedValue.ToString(),
                    SoNguoiHienTai = int.Parse(txt_SoNGHienTai.Text),
                    GhiChu = txt_GhiChu_PT.Text
                };

                db.PhongTros.Add(pt);

                db.SaveChanges();

                MessageBox.Show("Thêm phòng thành công!");
                LoadData();
            }
        }

        private void btn_SuaPhong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaPhong_PT.Text))
            {
                MessageBox.Show("Chưa chọn phòng để sửa!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                var pt = db.PhongTros.FirstOrDefault(p => p.MaPhong == txt_MaPhong_PT.Text);

                if (pt == null)
                {
                    MessageBox.Show("Không tìm thấy phòng!");
                    return;
                }

                pt.TenPhong = txt_SoPhong.Text;
                pt.MaLoai = cbo_TenLoai_PT.SelectedValue.ToString();
                pt.TrangThai = cbo_TrangThai_PT.Text;

                if (int.TryParse(txt_SoNGHienTai.Text, out int soNg))
                    pt.SoNguoiHienTai = soNg;

                db.SaveChanges();

                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
        }

        private void grid_PhongTro_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = grid_PhongTro.Rows[e.RowIndex];

                // Gán giá trị từ Grid lên các điều khiển (Controls)
                // Lưu ý: Thay tên biến (txt..., cbo...) đúng với tên trong project của bạn

                txt_MaPhong_PT.Text = row.Cells["MAPHONG"].Value.ToString(); // Khóa chính
                txt_SoPhong.Text = row.Cells["TENPHONG"].Value.ToString();
                txt_SoNGHienTai.Text = Convert.ToString(row.Cells["SONGUOIHIENTAI"].Value);
                // Xử lý ComboBox (Cần gán đúng Text hoặc Value)
                cbo_TenLoai_PT.Text = Convert.ToString(row.Cells["MALOAI"].Value);

                // Sửa luôn dòng bên dưới (để tránh lỗi tương tự nếu Trạng thái bị null)
                cbo_TrangThai_PT.Text = Convert.ToString(row.Cells["TRANGTHAI"].Value);
                txt_GhiChu_PT.Text = row.Cells["GHICHU"].Value.ToString();

                // Mẹo: Nên khóa txtMaPhong lại để người dùng không sửa Khóa Chính (Primary Key)
                txt_MaPhong_PT.Enabled = false;
                cbo_TenLoai_PT.Enabled = false;
            }
        }

        private void btn_XoaPhong_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng có đang chọn dòng nào trên Grid không
            if (grid_PhongTro.CurrentRow == null || grid_PhongTro.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng click chọn phòng cần xóa trên bảng!", "Thông báo");
                return;
            }

            // 2. Lấy Mã phòng trực tiếp từ dòng đang chọn
            // Lưu ý: "MAPHONG" phải trùng với DataPropertyName hoặc Name của cột trên Grid
            string maPhongCanXoa = grid_PhongTro.CurrentRow.Cells["MAPHONG"].Value.ToString();

            // 3. Hỏi xác nhận trước khi xóa
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phòng có mã: {maPhongCanXoa}?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var db = new QLPhongTroDataContext())
                {
                    // Tìm phòng trong CSDL dựa theo mã vừa lấy từ Grid
                    var pt = db.PhongTros.FirstOrDefault(p => p.MaPhong == maPhongCanXoa);

                    if (pt != null)
                    {
                        // Thực hiện xóa
                        // Nếu bạn dùng Entity Framework:
                        db.PhongTros.Remove(pt);
                        db.SaveChanges();

                        /* * LƯU Ý: Nếu bạn dùng LINQ to SQL (đuôi file .dbml) thì dùng lệnh này:
                         * db.PhongTros.DeleteOnSubmit(pt);
                         * db.SubmitChanges();
                         */

                        MessageBox.Show("Xóa thành công!");

                        // Load lại dữ liệu lên Grid
                        LoadData();

                        // (Tùy chọn) Xóa trắng các ô nhập liệu sau khi xóa
                        // txt_MaPhong_PT.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phòng này trong CSDL.");
                        LoadData(); // Load lại để cập nhật danh sách mới nhất
                    }
                }
            }
        }

        private void btn_LamMoi_PT_Click(object sender, EventArgs e)
        {
            txt_MaPhong_PT.Text = "";
            txt_SoPhong.Text = "";
            txt_SoNGHienTai.Text = "";
            txt_GhiChu_PT.Text = "";

            // 2. Đưa ComboBox về trạng thái mặc định (chưa chọn gì hoặc chọn dòng đầu tiên)
            if (cbo_TenLoai_PT.Items.Count > 0)
                cbo_TenLoai_PT.SelectedIndex = -1; // -1 là không chọn gì cả

            if (cbo_TrangThai_PT.Items.Count > 0)
                cbo_TrangThai_PT.SelectedIndex = -1;

            // 3. Mở khóa lại các điều khiển đã bị khóa ở sự kiện CellClick
            // (Để người dùng có thể nhập Mã phòng mới khi muốn Thêm)
            txt_MaPhong_PT.Enabled = true;
            cbo_TenLoai_PT.Enabled = true;

            // 4. Load lại dữ liệu từ CSDL lên Grid để đảm bảo dữ liệu mới nhất
            LoadData();

            // (Tùy chọn) Đặt con trỏ chuột vào ô Mã phòng để nhập liệu nhanh
            txt_MaPhong_PT.Focus();
       
        }
    }
}
