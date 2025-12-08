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
    public partial class btnBaoCaoSuCo : UserControl
    {
        public btnBaoCaoSuCo()
        {
            InitializeComponent();
        }

        private void ptroNhanvien_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình giao diện
            SetupGiaoDien();

            // 2. Tải danh sách phòng
            LoadDanhSachPhong();
        }

        private void SetupGiaoDien()
        {
            txtMaPhong.ReadOnly = true;
        }


        private void LoadDanhSachPhong()
        {
            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    // Lấy danh sách phòng
                    var listPhong = from p in db.PhongTros
                                    select new
                                    {
                                        MaPhong = p.MaPhong,
                                        TenPhong = p.TenPhong,
                                        TrangThai = p.TrangThai,
                                        GhiChu = p.GhiChu
                                    };

                    dgvPhong.DataSource = listPhong.ToList();

                    // Đặt tên cột tiếng Việt
                    if (dgvPhong.Columns["MaPhong"] != null) dgvPhong.Columns["MaPhong"].HeaderText = "Mã";
                    if (dgvPhong.Columns["TenPhong"] != null) dgvPhong.Columns["TenPhong"].HeaderText = "Tên Phòng";
                    if (dgvPhong.Columns["TrangThai"] != null) dgvPhong.Columns["TrangThai"].HeaderText = "Tình Trạng";
                    if (dgvPhong.Columns["GhiChu"] != null) dgvPhong.Columns["GhiChu"].Visible = false; // Ẩn ghi chú ở bảng chính cho gọn
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message);
            }
        }


        private void LoadLichSuBaoCao(string maPhong)
        {
            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    // Tìm hợp đồng còn hạn của phòng này
                    var hopDong = db.HopDongs.FirstOrDefault(hd => hd.MaPhong == maPhong && hd.TrangThai == "Còn hạn");

                    if (hopDong != null)
                    {
                        // Nếu có người đang thuê, tìm các yêu cầu hỗ trợ của họ
                        var lichSu = from yc in db.YeuCauHoTros
                                     where yc.MaKH == hopDong.MaKH
                                     select new
                                     {
                                         NgayGui = yc.NgayGui,
                                         NoiDung = yc.NoiDung,
                                         TrangThai = yc.TrangThai
                                     };

                        dgvLichSu.DataSource = lichSu.ToList();
                    }
                    else
                    {
                        dgvLichSu.DataSource = null;
                    }
                }
            }
            catch { }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text)) return;

            try
            {
                using (var db = new QLPhongTroDataContext(DangNhap.ConnectionStringHienTai))
                {
                    // Tìm phòng cần sửa
                    var phong = db.PhongTros.SingleOrDefault(p => p.MaPhong == txtMaPhong.Text);

                    if (phong != null)
                    {
                        // --- CẬP NHẬT: Lấy giá trị từ TextBox ---
                        phong.TrangThai = txtTT.Text;
                        phong.GhiChu = txtGhiChu.Text;

                        // Lưu xuống DB
                        db.SaveChanges();

                        MessageBox.Show("Cập nhật tình trạng phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại danh sách để thấy thay đổi
                        LoadDanhSachPhong();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Nút "Báo cáo sự cố": Tự động đổi trạng thái thành "ĐANG SỬA"
            if (string.IsNullOrEmpty(txtMaPhong.Text)) return;

            // --- CẬP NHẬT: Gán giá trị vào TextBox ---
            txtTT.Text = "ĐANG SỬA";

            // Ghi thêm thời gian vào ghi chú cũ
            string ghiChuCu = txtGhiChu.Text;
            txtGhiChu.Text = $"[Sự cố {DateTime.Now:dd/MM}] " + ghiChuCu;

            // Gọi luôn hàm cập nhật để lưu
            btnCapNhat_Click(sender, e);
        }

        private void dgvPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];

                // 1. Đổ dữ liệu lên các ô nhập
                string maPhong = row.Cells["MaPhong"].Value?.ToString();
                txtMaPhong.Text = maPhong;

                // --- CẬP NHẬT: Dùng TextBox thay vì ComboBox ---
                txtTT.Text = row.Cells["TrangThai"].Value?.ToString();

                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();

                // 2. Tải lịch sử báo cáo (Yêu cầu hỗ trợ) của phòng này
                LoadLichSuBaoCao(maPhong);
            }
        }
    }
}
