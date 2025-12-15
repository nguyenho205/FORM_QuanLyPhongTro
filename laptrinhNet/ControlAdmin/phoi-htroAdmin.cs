using laptrinhNet.Database;
using laptrinhNet.Database.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet.ControlAdmin
{
    public partial class phoi_htroAdmin : UserControl
    {
        public phoi_htroAdmin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }



        private void phoi_htroAdmin_Load(object sender, EventArgs e)
        {
            LoadComboBoxNhanVien();
            LoadComboBoxTrangThai();
            LoadDataPhanHoi(); // Mặc định load tất cả
            GiaoDien.ApplyTheme(this);
            // Mặc định chọn radio "Tất cả"
            chk_DaXuLy.Checked = true;
        }

        // 1. Load danh sách Nhân Viên vào ComboBox để Admin chọn
        private void LoadComboBoxNhanVien()
        {
            using (var db = new QLPhongTroDataContext())
            {
                cbo_NhanVienXuLy.DataSource = db.NhanViens.ToList();
                cbo_NhanVienXuLy.DisplayMember = "TenNhanVien";
                cbo_NhanVienXuLy.ValueMember = "MaNV";
                cbo_NhanVienXuLy.SelectedIndex = -1; // Chưa chọn ai
            }
        }

        // 2. Load các trạng thái (Chưa xử lý, Đang xử lý, Đã xử lý)
        private void LoadComboBoxTrangThai()
        {
            cbo_TrangThai.Items.Clear();
            cbo_TrangThai.Items.Add("Chưa xử lý");
            cbo_TrangThai.Items.Add("Đang xử lý");
            cbo_TrangThai.Items.Add("Đã xử lý");
        }

        // 3. Hàm Load dữ liệu lên GridView
        private void LoadDataPhanHoi(string filterTrangThai = "All")
        {
            using (var db = new QLPhongTroDataContext())
            {
                // Query cơ bản
                var query = from ph in db.YeuCauHoTros
                            join kh in db.KhachHangs on ph.MaKH equals kh.MaKH
                            // Join trái (Left Join) với Nhân viên vì có thể chưa có ai xử lý
                            join nv in db.NhanViens on ph.MaNV_XuLy equals nv.MaNV into nvGroup
                            from subNv in nvGroup.DefaultIfEmpty()

                                // Join trái với Phòng (nếu cần lấy số phòng)
                            join hd in db.HopDongs on kh.MaKH equals hd.MaKH into hdGroup
                            from subHd in hdGroup.DefaultIfEmpty()
                            join pt in db.PhongTros on subHd.MaPhong equals pt.MaPhong into ptGroup
                            from subPt in ptGroup.DefaultIfEmpty()

                            select new PhanHoiDTO
                            {
                                MaPH = ph.MaYeuCau,
                                TenNguoiGui = kh.TenKH,
                                SoPhong = subPt != null ? subPt.TenPhong : "Chưa thuê",
                                NoiDung = ph.NoiDung,
                                NgayGui = ph.NgayGui,
                                TrangThai = ph.TrangThai,
                                // Nếu chưa có NV thì hiện "Chưa phân công"
                                TenNhanVien = subNv != null ? subNv.TenNhanVien : "Chưa phân công",
                                PhanHoi = ph.PhanHoi
                            };

                // Lọc theo Radio Button
                if (filterTrangThai != "All")
                {
                    query = query.Where(x => x.TrangThai == filterTrangThai);
                }

                grid_PhanHoi.DataSource = query.ToList();
            }
        }

        private void grid_PhanHoi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maPH = grid_PhanHoi.Rows[e.RowIndex].Cells["MaPH"].Value?.ToString();

            // Lưu Mã PH vào TextBox (hoặc ComboBox) và khóa lại
            // Giả sử tên control là txt_MaPhanHoi
            // Nếu giao diện của bạn là ComboBox cho Mã PH thì gán SelectedValue
            txt_MaPhanHoi.Text = maPH;

            using (var db = new QLPhongTroDataContext())
            {
                var ph = db.YeuCauHoTros.FirstOrDefault(x => x.MaYeuCau == maPH);
                if (ph == null) return;

                // Đổ dữ liệu
                txt_NoiDung.Text = ph.NoiDung;
                txt_PhanHoi.Text = ph.PhanHoi;
                cbo_TrangThai.Text = ph.TrangThai;

                // Chọn nhân viên tương ứng trong ComboBox
                if (ph.MaNV_XuLy != null)
                    cbo_NhanVienXuLy.SelectedValue = ph.MaNV_XuLy;
                else
                    cbo_NhanVienXuLy.SelectedIndex = -1;

                // Lấy tên người gửi và số phòng (hiển thị, không lưu)
                var kh = db.KhachHangs.FirstOrDefault(k => k.MaKH == ph.MaKH);
                txt_TenNguoiGui.Text = kh?.TenKH;

                // (Logic lấy số phòng tương tự như query trên, hoặc lấy từ Grid)
                txt_SoPhong.Text = grid_PhanHoi.Rows[e.RowIndex].Cells["SoPhong"].Value?.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra chọn phản hồi chưa
            if (string.IsNullOrEmpty(txt_MaPhanHoi.Text)) // Hoặc check cbo MaPH
            {
                MessageBox.Show("Vui lòng chọn một phản hồi để xử lý!");
                return;
            }

            // Kiểm tra chọn nhân viên chưa
            if (cbo_NhanVienXuLy.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để giao việc!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                var ph = db.YeuCauHoTros.FirstOrDefault(x => x.MaYeuCau == txt_MaPhanHoi.Text);
                if (ph != null)
                {
                    // Cập nhật Nhân viên xử lý
                    ph.MaNV_XuLy = cbo_NhanVienXuLy.SelectedValue.ToString();

                    // Cập nhật trạng thái (Ví dụ chuyển sang Đang xử lý)
                    ph.TrangThai = cbo_TrangThai.Text;

                    // Cập nhật Ghi chú Admin
                    ph.PhanHoi = txt_PhanHoi.Text;

                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show($"Đã giao phản hồi {ph.MaYeuCau} cho nhân viên {cbo_NhanVienXuLy.Text}!");

                        // Load lại lưới để thấy thay đổi
                        LoadDataPhanHoi();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }

        private void chk_ChuaXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ChuaXuLy.Checked) LoadDataPhanHoi("Chưa xử lý");
            chkTatCa.Checked = false;
            chk_DangXuLy.Checked = false;
            chk_DaXuLy.Checked = false;
        }

        private void chk_DangXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DangXuLy.Checked) LoadDataPhanHoi("Đang xử lý");
            chk_ChuaXuLy.Checked = false;
            chk_DaXuLy.Checked = false;
            chkTatCa.Checked = false;
        }

        private void chk_DaXuLy_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_DaXuLy.Checked) LoadDataPhanHoi("Đã xử lý");
            chk_ChuaXuLy.Checked = false;
            chk_DangXuLy.Checked = false;
            chkTatCa.Checked = false;
        }

        private void chkTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTatCa.Checked) LoadDataPhanHoi("All");
            chk_ChuaXuLy.Checked = false;
            chk_DangXuLy.Checked = false;
            chk_DaXuLy.Checked = false;
        }


    }
}
