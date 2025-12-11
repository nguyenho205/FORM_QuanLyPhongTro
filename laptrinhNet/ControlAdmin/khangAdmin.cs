using laptrinhNet.Database;
using laptrinhNet.Database.DTOs;
using laptrinhNet.Database.Entities;
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
    public partial class khangAdmin : UserControl
    {
        public khangAdmin()
        {
            InitializeComponent();
        }

        private string TaoMaKhachHangTuDong()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var lastKH = db.KhachHangs.OrderByDescending(x => x.MaKH).FirstOrDefault();
                if (lastKH == null) return "KH01";

                string lastMa = lastKH.MaKH; // VD: KH09
                string phanSo = lastMa.Substring(2); // Lấy số 09

                if (int.TryParse(phanSo, out int so))
                {
                    return "KH" + (so + 1).ToString("D2"); // Trả về KH10
                }
                return "KHNew";
            }
        }



        private void khangAdmin_Load(object sender, EventArgs e)
        {
            LoadDataKhachHang();
            ResetForm(); // Để sinh mã tự động ban đầu
        }

        private void LoadDataKhachHang()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var list = db.KhachHangs.Select(kh => new KhachHangDTO
                {
                    MAKH = kh.MaKH,
                    TENKH = kh.TenKH,
                    SODIENTHOAI = kh.SoDienThoai,
                    SOCMND = kh.SoCMND, // Hoặc CMND tùy tên cột trong DB
                    EMAIL_KHACHHANG = kh.EmailKhachHang,
                    DIACHITHUONGTRU = kh.DiaChiThuongTru,
                }).ToList();

                grid_KhachHang.DataSource = list;
            }
        }

        private void ResetForm()
        {
            txt_TenKH.Text = "";
            txt_SDT.Text = "";
            txt_SoCCCD.Text = "";
            txt_Email.Text = "";
            txt_DiaChiThuongTru.Text = "";

            // Sinh mã mới và khóa ô mã
            txt_MaNV.Text = TaoMaKhachHangTuDong();
            txt_MaNV.Enabled = false;
        }

        private void grid_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = grid_KhachHang.Rows[e.RowIndex];

                txt_MaNV.Text = row.Cells["MAKH"].Value?.ToString();
                txt_TenKH.Text = row.Cells["TENKH"].Value?.ToString();
                txt_SDT.Text = row.Cells["SODIENTHOAI"].Value?.ToString();
                txt_SoCCCD.Text = row.Cells["SOCMND"].Value?.ToString();
                txt_Email.Text = row.Cells["EMAIL_KHACHHANG"].Value?.ToString();
                txt_DiaChiThuongTru.Text = row.Cells["DIACHITHUONGTRU"].Value?.ToString();
            }
        }     
        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            using (var db = new QLPhongTroDataContext())
            {
                // Kiểm tra trùng mã (an toàn)
                if (db.KhachHangs.Any(x => x.MaKH == txt_MaNV.Text))
                {
                    txt_MaNV.Text = TaoMaKhachHangTuDong();
                }

                KhachHang kh = new KhachHang();
                kh.MaKH = txt_MaNV.Text;
                kh.TenKH = txt_TenKH.Text;
                kh.SoDienThoai = txt_SDT.Text;
                kh.SoCMND = txt_SoCCCD.Text;
                kh.EmailKhachHang = txt_Email.Text;
                kh.DiaChiThuongTru = txt_DiaChiThuongTru.Text;

                db.KhachHangs.Add(kh);
                db.SaveChanges();

                MessageBox.Show("Thêm khách hàng thành công!");
                LoadDataKhachHang();
                ResetForm();
            }
        }

        private void btn_SuaNV_Click(object sender, EventArgs e)
        {
            using (var db = new QLPhongTroDataContext())
            {
                // Tìm khách hàng theo mã đang hiển thị
                var kh = db.KhachHangs.FirstOrDefault(x => x.MaKH == txt_MaNV.Text);

                if (kh == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng để sửa!");
                    return;
                }

                kh.TenKH = txt_TenKH.Text;
                kh.SoDienThoai = txt_SDT.Text;
                kh.SoCMND = txt_SoCCCD.Text;
                kh.EmailKhachHang = txt_Email.Text;
                kh.DiaChiThuongTru = txt_DiaChiThuongTru.Text;

                db.SaveChanges();
                MessageBox.Show("Cập nhật thông tin thành công!");
                LoadDataKhachHang();
                ResetForm();
            }
        }

        private void btn_XoaNV_Click(object sender, EventArgs e)
        {        
            // Kiểm tra chọn dòng
            if (grid_KhachHang.CurrentRow == null) return;

            string maKH = grid_KhachHang.CurrentRow.Cells["MAKH"].Value.ToString();

            if (MessageBox.Show($"Bạn có chắc muốn xóa khách {maKH}?", "Cảnh báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var db = new QLPhongTroDataContext())
                {
                    var kh = db.KhachHangs.FirstOrDefault(x => x.MaKH == maKH);

                    // Kiểm tra ràng buộc: Nếu khách đang thuê phòng hoặc có hợp đồng thì không được xóa
                    // (Bạn cần kiểm tra thêm bảng HopDong/ThuePhong ở đây nếu có)

                    if (kh != null)
                    {
                        try
                        {
                            db.KhachHangs.Remove(kh);
                            db.SaveChanges();
                            MessageBox.Show("Đã xóa khách hàng!");
                            LoadDataKhachHang();
                            ResetForm();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Không thể xóa khách hàng này vì đang có dữ liệu liên quan (Hợp đồng/Hóa đơn). Hãy dùng chức năng 'Khóa tài khoản'.");
                        }
                    }
                }
            }
        }
    }
}
