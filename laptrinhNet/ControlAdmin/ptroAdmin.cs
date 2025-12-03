using laptrinhNet.Database;
using laptrinhNet.Database.DTOs;
using laptrinhNet.Database.Entities; // Giả định đây là namespace chứa PHONGTRO và LOAI_PHONGTRO
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
    // Cần đảm bảo các Control như grid_PhongTro, chk_DaThue, btn_Them, v.v. đã được khai báo
    // trong file ptroAdmin.Designer.cs
    public partial class ptroAdmin : UserControl
    {
        public ptroAdmin()
        {
            InitializeComponent();
        }

        private void ptroAdmin_Load(object sender, EventArgs e)
        {
            // Thiết lập trạng thái ban đầu và tải dữ liệu
            chk_DaThue.Checked = true;
            chk_ChuaThue.Checked = true;

            // Gán sự kiện CellClick cho DataGridView
            grid_PhongTro.CellClick += grid_PhongTro_CellClick;

            LoadData(); // Tải dữ liệu lần đầu tiên
        }

        // --- 1. TẢI VÀ LỌC DỮ LIỆU (READ & FILTER) ---
        public void LoadData()
        {
            // 1. Xác định trạng thái cần lấy
            List<string> trangThaiCanLay = new List<string>();
            if (chk_DaThue.Checked)
            {
                trangThaiCanLay.Add("Đã Thuê"); // Giả định chuỗi trạng thái trong DB
            }
            if (chk_ChuaThue.Checked)
            {
                trangThaiCanLay.Add("Chưa Thuê"); // Giả định chuỗi trạng thái trong DB
            }

            using (var db = new QLPhongTroDataContext())
            {
                // 2. Tải dữ liệu cho ComboBox (Loại Phòng)
                cbo_TenLoai_PT.DataSource = db.LoaiPhongTros.ToList();
                cbo_TenLoai_PT.DisplayMember = "TenLoai";
                cbo_TenLoai_PT.ValueMember = "MaLoai";

                // 3. Truy vấn dữ liệu cho DataGridView (sử dụng DTO và lọc)
                var query = from p in db.PhongTros
                            join l in db.LoaiPhongTros on p.MaLoai equals l.MaLoai
                            where trangThaiCanLay.Contains(p.TrangThai) // Áp dụng lọc
                            select new PhongTroDTO
                            {
                                MAPHONG = p.MaPhong,
                                TENPHONG = p.TenPhong,
                                MALOAI = l.TenLoai,
                                TRANGTHAI = p.TrangThai,
                                SONGUOIHIENTAI = p.SoNguoiHienTai
                            };

                grid_PhongTro.DataSource = query.ToList();
            }
        }

        // Kích hoạt LoadData khi checkbox thay đổi
        private void chk_DaThue_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chk_ChuaThue_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        // --- 2. THÊM (CREATE) ---
        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaPhong_PT.Text) || cbo_TenLoai_PT.SelectedValue == null)

            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã Phòng và chọn Loại Phòng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                if (db.PhongTros.Any(p => p.MaPhong == txt_MaPhong_PT.Text))
                {
                    MessageBox.Show("Mã Phòng đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PhongTro pt = new PhongTro()
                {
                    MaPhong = txt_MaPhong_PT.Text,
                    TenPhong = txt_SoPhong.Text,
                    MaLoai = cbo_TenLoai_PT.SelectedValue.ToString(),
                    TrangThai = cbo_TrangThai_PT.Text,
                    SoNguoiHienTai = int.Parse(txt_SoNGHienTai.Text),
                    // ... các trường khác
                };

                db.PhongTros.Add(pt);
                db.SaveChanges();

                MessageBox.Show("Thêm phòng trọ thành công!");
                LoadData();
            }
        }

        // --- 3. SỬA (UPDATE) ---
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaPhong_PT.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã Phòng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                var pt = db.PhongTros.FirstOrDefault(p => p.MaPhong == txt_MaPhong_PT.Text);

                if (pt == null)
                {
                    MessageBox.Show("Không tìm thấy Phòng Trọ có mã này để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật các trường
                if (txt_SoPhong.Text.Length > 0)
                {
                    pt.TenPhong = txt_SoPhong.Text;
                }
                if (cbo_TenLoai_PT.SelectedValue != null)
                {
                    pt.MaLoai = cbo_TenLoai_PT.SelectedValue.ToString();
                }
                if (cbo_TrangThai_PT.Text.Length > 0)
                {
                    pt.TrangThai = cbo_TrangThai_PT.Text;
                }
                if (txt_SoNGHienTai.Text.Length > 0)
                {
                    pt.SoNguoiHienTai = int.Parse(txt_SoNGHienTai.Text);
                }

                db.SaveChanges();
                MessageBox.Show("Cập nhật phòng trọ thành công!");
                LoadData();
            }
        }

        // --- 4. XÓA (DELETE) ---
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaPhong_PT.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã Phòng cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Phòng Trọ này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                var pt = db.PhongTros.FirstOrDefault(p => p.MaPhong == txt_MaPhong_PT.Text);

                if (pt == null)
                {
                    MessageBox.Show("Không tìm thấy Phòng Trọ có mã này để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                db.PhongTros.Remove(pt);
                db.SaveChanges();

                MessageBox.Show("Xóa phòng trọ thành công!");
                LoadData();
            }
        }

        // --- 5. SỰ KIỆN CHỌN HÀNG (DATAGRIDVIEW CELL CLICK) ---
        private void grid_PhongTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grid_PhongTro.Rows[e.RowIndex];

                txt_MaPhong_PT.Text = row.Cells["MaPhong"].Value?.ToString();
                txt_SoPhong.Text = row.Cells["Tenphong"].Value?.ToString();

                cbo_TrangThai_PT.Text = row.Cells["TrangThai"].Value?.ToString();
                cbo_TenLoai_PT.Text = row.Cells["LoaiPhong"].Value?.ToString();

                txt_SoNGHienTai.Text = row.Cells["Số_Người"].Value?.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            // Không cần code xử lý tại đây
        }

        private void grid_PhongTro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}