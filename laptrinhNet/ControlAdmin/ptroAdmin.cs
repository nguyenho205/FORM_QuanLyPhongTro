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
            //using (var db = new QLPhongTroDataContext())
            //{
            //    var ds = db.LoaiPhongTros.Select(t => t.MaLoai).ToList();
            //    cbo_MaLoai_PT.DataSource = ds;
            //    var data = db.PhongTros.ToList()
            //        .Select(sv => new PhongTro
            //        {
            //            MaPhong = sv.MaPhong,
            //            TenPhong = sv.TenPhong,
            //            TenLoai = sv.TenLoai,
            //            TrangThai = sv.TrangThai,
            //            SoNguoiHienTai = sv.SoNguoiHienTai,
            //            GhiChu = sv.GhiChu,


            //        })
            //        .ToList();
            //    grid_PhongTro.DataSource = data;

            //}
            LoadData();

        }

        // ============================================
        // 1) LOAD DỮ LIỆU
        // ============================================
        private void LoadData()
        {
            using (var db = new QLPhongTroDataContext())
            {
                // Load combobox
                cbo_TenLoai_PT.DataSource = db.LoaiPhongTros.ToList();

                cbo_TenLoai_PT.ValueMember = "MALOAI";

                cbo_TrangThai_PT.DataSource = new string[] { "ĐANG THUÊ", "TRỐNG" };

                // Lọc dữ liệu

                var list = db.PhongTros
                    .ToList()
                    .Select(sv => new PhongTroDTO
                    {
                       MAPHONG = sv.MaPhong,
                        TENPHONG = sv.TenPhong,
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
                cbo_TenLoai_PT.Text = row.Cells["MALOAI"].Value.ToString();
                cbo_TrangThai_PT.Text = row.Cells["TRANGTHAI"].Value.ToString();

                // Mẹo: Nên khóa txtMaPhong lại để người dùng không sửa Khóa Chính (Primary Key)
                txt_MaPhong_PT.Enabled = false;
            }
        }



        //// ============================================
        //// 3) SỬA
        //// ============================================
        //private void btn_Sua_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txt_MaPhong_PT.Text))
        //    {
        //        MessageBox.Show("Chưa chọn phòng để sửa!");
        //        return;
        //    }

        //    using (var db = new QLPhongTroDataContext())
        //    {
        //        var pt = db.PhongTros.FirstOrDefault(p => p.MaPhong == txt_MaPhong_PT.Text);

        //        if (pt == null)
        //        {
        //            MessageBox.Show("Không tìm thấy phòng!");
        //            return;
        //        }

        //        pt.TenPhong = txt_SoPhong.Text;
        //        pt.MaLoai = cbo_TenLoai_PT.SelectedValue.ToString();
        //        pt.TrangThai = cbo_TrangThai_PT.Text;

        //        if (int.TryParse(txt_SoNGHienTai.Text, out int soNg))
        //            pt.SoNguoiHienTai = soNg;

        //        db.SubmitChanges();

        //        MessageBox.Show("Cập nhật thành công!");
        //        LoadData();
        //    }
        //}

        //// ============================================
        //// 4) XÓA
        //// ============================================
        //private void btn_Xoa_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txt_MaPhong_PT.Text))
        //    {
        //        MessageBox.Show("Chưa chọn phòng để xóa!");
        //        return;
        //    }

        //    if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?",
        //        "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
        //        return;

        //    using (var db = new QLPhongTroDataContext())
        //    {
        //        var pt = db.PhongTros.FirstOrDefault(p => p.MaPhong == txt_MaPhong_PT.Text);

        //        if (pt == null)
        //        {
        //            MessageBox.Show("Không tìm thấy phòng!");
        //            return;
        //        }

        //        db.PhongTros.DeleteOnSubmit(pt);
        //        db.SubmitChanges();

        //        MessageBox.Show("Xóa thành công!");
        //        LoadData();
        //    }
        //}

        // ============================================
        // 5) CLICK GRIDVIEW
        // ============================================

        //private void btn_ThemPhong_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txt_MaPhong_PT.Text))
        //    {
        //        MessageBox.Show("Vui lòng nhập mã phòng!");
        //        return;
        //    }

        //    using (var db = new QLPhongTroDataContext())
        //    {
        //        if (db.PhongTros.Any(p => p.MaPhong == txt_MaPhong_PT.Text))
        //        {
        //            MessageBox.Show("Mã phòng đã tồn tại!");
        //            return;
        //        }

        //        var pt = new PhongTro
        //        {
        //            MaPhong = txt_MaPhong_PT.Text,
        //            TenPhong = txt_SoPhong.Text,
        //            MaLoai = cbo_TenLoai_PT.SelectedValue.ToString(),
        //            TrangThai = cbo_TrangThai_PT.Text,
        //            SoNguoiHienTai = int.Parse(txt_SoNGHienTai.Text)
        //        };

        //        db.PhongTros.Add(pt);
        //        db.SaveChanges();

        //        MessageBox.Show("Thêm thành công!");
        //        LoadData();
        //    }
        //}

        //private void grid_PhongTro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0) return;

        //    var row = grid_PhongTro.Rows[e.RowIndex];

        //    txt_MaPhong_PT.Text = row.Cells["MaPhong"].Value?.ToString();
        //    txt_SoPhong.Text = row.Cells["TenPhong"].Value?.ToString();
        //    cbo_TrangThai_PT.Text = row.Cells["TrangThai"].Value?.ToString();
        //    cbo_TenLoai_PT.SelectedValue = row.Cells["MaLoai"].Value?.ToString();
        //    txt_SoNGHienTai.Text = row.Cells["SoNguoiHienTai"].Value?.ToString();
        //}
    }
}
