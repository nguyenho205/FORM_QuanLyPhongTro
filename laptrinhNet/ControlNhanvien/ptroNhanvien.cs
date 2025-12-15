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
    public partial class ptroNhanvien : UserControl
    {
        public ptroNhanvien()
        {
            InitializeComponent();
        }

        private void ptroNhanvien_Load(object sender, EventArgs e)
        {
            SetupGiaoDien();
            LoadDanhSachPhong();
            GiaoDien.ApplyTheme(this);

            dgvNguoiO.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


 
        }

        private void SetupGiaoDien()
        {
            txtMaPhong.ReadOnly = true;
            // Nếu dùng TextBox cho tình trạng thì nên cẩn thận, tốt nhất là ComboBox
            // --- CẤU HÌNH COMBOBOX TÌNH TRẠNG ---
            cbbTinhTrang.Items.Clear();
            // Thêm các trạng thái chuẩn theo Database của bạn
            cbbTinhTrang.Items.Add("TRỐNG");
            cbbTinhTrang.Items.Add("ĐANG THUÊ");
            cbbTinhTrang.Items.Add("ĐANG SỬA");

            // Mặc định chọn cái đầu tiên để không bị trống
            cbbTinhTrang.SelectedIndex = 0;
        }

        // --- 1. TẢI DANH SÁCH PHÒNG ---
        private void LoadDanhSachPhong()
        {
            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    var listPhong = from p in db.PhongTros
                                    join l in db.LoaiPhongTros on p.MaLoai equals l.MaLoai
                                    select new
                                    {
                                        MaPhong = p.MaPhong,
                                        TenPhong = p.TenPhong,
                                        TenLoai = l.TenLoai,
                                        Gia = l.GiaPhong,
                                        TrangThai = p.TrangThai,
                                        GhiChu = p.GhiChu
                                    };

                    dgvPhong.DataSource = listPhong.ToList();

                    // Đặt tên cột
                    if (dgvPhong.Columns["MaPhong"] != null) dgvPhong.Columns["MaPhong"].HeaderText = "Mã";
                    if (dgvPhong.Columns["TenPhong"] != null) dgvPhong.Columns["TenPhong"].HeaderText = "Phòng";
                    if (dgvPhong.Columns["TenLoai"] != null) dgvPhong.Columns["TenLoai"].HeaderText = "Loại";
                    if (dgvPhong.Columns["Gia"] != null) dgvPhong.Columns["Gia"].DefaultCellStyle.Format = "N0";

                    // Ẩn cột Ghi chú dài dòng
                    if (dgvPhong.Columns["GhiChu"] != null) dgvPhong.Columns["GhiChu"].Visible = false;

                    // Tô màu trạng thái (Optional)
                    ToMauTrangThai();
                }
            }
            catch (Exception ex)
            {
            }
        }

        // Hàm tô màu dòng cho dễ nhìn
        private void ToMauTrangThai()
        {
            foreach (DataGridViewRow row in dgvPhong.Rows)
            {
                string tt = row.Cells["TrangThai"].Value?.ToString();
                if (tt == "ĐANG THUÊ") row.DefaultCellStyle.BackColor = Color.LightGreen;
                else if (tt == "ĐANG SỬA") row.DefaultCellStyle.BackColor = Color.LightYellow;
                else row.DefaultCellStyle.BackColor = Color.White; // TRỐNG
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];

                string maPhong = row.Cells["MaPhong"].Value?.ToString();
                txtMaPhong.Text = maPhong;
                cbbTinhTrang.Text = row.Cells["TrangThai"].Value?.ToString();
                rtbGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();

                // Load danh sách người đang ở bên bảng phải
                LoadNguoiDangO(maPhong);
            }
        }

        private void LoadNguoiDangO(string maPhong)
        {
            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    // Truy vấn ngược từ Hợp Đồng -> Khách Hàng
                    var listKhach = from hd in db.HopDongs
                                    join kh in db.KhachHangs on hd.MaKH equals kh.MaKH
                                    where hd.MaPhong == maPhong && hd.TrangThai == "Còn hạn" // Chỉ lấy hợp đồng còn hạn
                                    select new
                                    {
                                        TenKH = kh.TenKH,
                                        SDT = kh.SoDienThoai,
                                        NgayVao = hd.NgayBD
                                    };

                    dgvNguoiO.DataSource = listKhach.ToList();

                    if (dgvNguoiO.Columns["TenKH"] != null) dgvNguoiO.Columns["TenKH"].HeaderText = "Tên khách hàng";
                    if (dgvNguoiO.Columns["SDT"] != null) dgvNguoiO.Columns["SDT"].HeaderText = "SĐT";
                    if (dgvNguoiO.Columns["NgayVao"] != null) dgvNguoiO.Columns["NgayVao"].HeaderText = "Ngày vào ở";
                    dgvNguoiO.Columns["TenKH"].Width = 200;
                    dgvNguoiO.Columns["NgayVao"].Width = 130;
                }
            }
            catch { /* Bỏ qua lỗi nhỏ nếu không có khách */ }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text)) return;

            // Dùng InputBox nhỏ hoặc chỉ đơn giản là focus vào ô Ghi chú để nhập
            // Ở đây tôi làm cách tự động chèn template ngày tháng cho tiện
            string tag = $"[{DateTime.Now.ToString("dd/MM")} Sự cố]: ";

            // Thêm dòng mới vào ô Ghi chú
            if (!string.IsNullOrEmpty(rtbGhiChu.Text))
                rtbGhiChu.AppendText(Environment.NewLine); // Xuống dòng

            rtbGhiChu.AppendText(tag);
            rtbGhiChu.Focus(); // Đưa con trỏ chuột vào để nhân viên gõ tiếp nội dung
            rtbGhiChu.SelectionStart = rtbGhiChu.Text.Length; // Nhảy xuống cuối
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    var phong = db.PhongTros.FirstOrDefault(p => p.MaPhong == txtMaPhong.Text);
                    if (phong != null)
                    {
                        // Cập nhật tình trạng và ghi chú
                        phong.TrangThai = cbbTinhTrang.Text.Trim(); // VD: "ĐANG SỬA"
                        phong.GhiChu = rtbGhiChu.Text;

                        db.SaveChanges();
                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDanhSachPhong(); // Tải lại để thấy màu sắc thay đổi
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
