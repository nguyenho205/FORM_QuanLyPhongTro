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
    public partial class hdongAdmin : UserControl
    {
        public hdongAdmin()
        {
            InitializeComponent();
        }
        private void LoadDataHopDong()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var list = db.HopDongs.Select(hd => new HopDongDTO
                {
                    MAHOPDONG = hd.MaHopDong,
                    TENKH = hd.KhachHangData.TenKH, 
                    TENPHONG = hd.PhongTroData.TenPhong, 

                    NGAYBD = hd.NgayBD.HasValue ? hd.NgayBD.Value : DateTime.Now,
                    NGAYKT = hd.NgayKT.HasValue ? hd.NgayKT.Value : DateTime.Now,

                    TIENCOC = hd.TienCoc.HasValue ? hd.TienCoc.Value : 0,

                    TRANGTHAI = hd.TrangThai
                }).ToList();

                grid_HopDong.DataSource = list;
            }
        }
        private string TaoMaHopDongTuDong()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var lastHD = db.HopDongs.OrderByDescending(x => x.MaHopDong).FirstOrDefault();
                if (lastHD == null) return "HD01";

                string lastMa = lastHD.MaHopDong;
                string phanSo = lastMa.Substring(2);

                if (int.TryParse(phanSo, out int so))
                {
                    return "HD" + (so + 1).ToString("D2");
                }
                return "HDNew";
            }
        }
        private void LoadCboKhachHang()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var khachDangThue = db.HopDongs
                                      .Where(hd => hd.TrangThai == "Còn hạn")
                                      .Select(hd => hd.MaKH).ToList();

                var khachKhaDung = db.KhachHangs
                                     .Where(k => !khachDangThue.Contains(k.MaKH))
                                     .ToList();

                cbo_TenKH.DataSource = khachKhaDung;
                cbo_TenKH.DisplayMember = "TENKH";
                cbo_TenKH.ValueMember = "MAKH";
            }
        }

        // Load danh sách phòng đang TRỐNG
        private void LoadCboPhongTro()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var phongTrong = db.PhongTros.Where(p => p.TrangThai == "TRỐNG").ToList();

                cbo_TenPhong_HD.DataSource = phongTrong;
                cbo_TenPhong_HD.DisplayMember = "TenPhong";
                cbo_TenPhong_HD.ValueMember = "MAPHONG";
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void hdongAdmin_Load(object sender, EventArgs e)
        {
            LoadDataHopDong();
            LoadCboKhachHang();
            LoadCboPhongTro();
            ResetForm();
            GiaoDien.ApplyTheme(this);

            grid_HopDong.Columns["TIENCOC"].DefaultCellStyle.Format = "N0";
            grid_HopDong.Columns["TIENCOC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grid_HopDong.Columns["MAHOPDONG"].Width = 120;
            grid_HopDong.Columns["NGAYBD"].Width = 100;
            grid_HopDong.Columns["NGAYKT"].Width = 100;
            grid_HopDong.Columns["TIENCOC"].Width = 120;
            grid_HopDong.Columns["TRANGTHAI"].Width = 100;

            grid_HopDong.Columns["TENKH"].Width = 200;

            grid_HopDong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grid_HopDong.Columns["NGAYBD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_HopDong.Columns["NGAYKT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid_HopDong.Columns["MAHOPDONG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ResetForm()
        {
            txt_MaHD.Text = TaoMaHopDongTuDong();
            txt_MaHD.Enabled = false;

            dt_NgayBD_HD.Value = DateTime.Now;
            dt_NgayKT_HD.Value = DateTime.Now.AddMonths(6); // Mặc định thuê 6 tháng

            txt_TienCoc_HD.Text = "0";
            txt_TrangThai_HD.Text = "Còn hạn";
            txt_TrangThai_HD.Enabled = false; // Trạng thái tự động, không cho sửa tay

            cbo_TenKH.Enabled = true;
            cbo_TenPhong_HD.Enabled = true;
            dt_NgayBD_HD.Enabled = true;
        }

        private void btn_TaoHopDong_Click(object sender, EventArgs e)
        {
            if (dt_NgayKT_HD.Value.Date <= dt_NgayBD_HD.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu!");
                return;
            }

            if (cbo_TenKH.SelectedValue == null || cbo_TenPhong_HD.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn Khách hàng và Phòng trọ!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                HopDong hd = new HopDong();
                hd.MaHopDong = txt_MaHD.Text;
                hd.MaKH = cbo_TenKH.SelectedValue.ToString();
                hd.MaPhong = cbo_TenPhong_HD.SelectedValue.ToString();
                hd.NgayBD = dt_NgayBD_HD.Value;
                hd.NgayKT = dt_NgayKT_HD.Value;
                hd.TrangThai = (hd.NgayKT > DateTime.Now) ? "Còn hạn" : "Hết hạn";

                decimal tienCoc = 0;
                decimal.TryParse(txt_TienCoc_HD.Text, out tienCoc);
                hd.TienCoc = tienCoc;

                db.HopDongs.Add(hd);

                var phong = db.PhongTros.FirstOrDefault(p => p.MaPhong == hd.MaPhong);
                if (phong != null)
                {
                    phong.TrangThai = "Đã thuê";
                }

                db.SaveChanges();
                MessageBox.Show("Tạo hợp đồng thành công!");
                cbo_TenKH.SelectedValue = -1;
                cbo_TenPhong_HD.SelectedValue = -1;
                LoadDataHopDong();
                LoadCboKhachHang();
                LoadCboPhongTro();
                ResetForm();
            }
        }

        private void btn_GiaHanHopDong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần gia hạn!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                var hd = db.HopDongs.FirstOrDefault(x => x.MaHopDong == txt_MaHD.Text);

                if (hd == null)
                {
                    MessageBox.Show("Không tìm thấy hợp đồng!");
                    return;
                }

                // Kiểm tra logic ngày tháng
                if (dt_NgayKT_HD.Value.Date <= hd.NgayBD.Value.Date)
                {
                    MessageBox.Show("Ngày kết thúc mới phải lớn hơn ngày bắt đầu cũ!");
                    return;
                }

                // Cập nhật thông tin
                hd.NgayKT = dt_NgayKT_HD.Value;

                // Cập nhật tiền cọc nếu có thay đổi
                decimal tienCoc = 0;
                decimal.TryParse(txt_TienCoc_HD.Text, out tienCoc);
                hd.TienCoc = tienCoc;

                // Tự động cập nhật lại trạng thái
                hd.TrangThai = (hd.NgayKT > DateTime.Now) ? "Còn hạn" : "Hết hạn";

                db.SaveChanges();

                MessageBox.Show("Gia hạn hợp đồng thành công!");

                LoadDataHopDong();
                ResetForm(); // Mở lại các control để nhập mới
            }
        }

        private void grid_HopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_HuyHopDong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần hủy!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn hủy hợp đồng này? Phòng sẽ được chuyển về trạng thái TRỐNG.",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var db = new QLPhongTroDataContext())
                {
                    var hd = db.HopDongs.FirstOrDefault(x => x.MaHopDong == txt_MaHD.Text);

                    if (hd != null)
                    {
                        hd.TrangThai = "Hết hạn";
                        hd.NgayKT = DateTime.Now; 

                        // 2. QUAN TRỌNG: Trả lại trạng thái phòng là TRỐNG
                        var phong = db.PhongTros.FirstOrDefault(p => p.MaPhong == hd.MaPhong);
                        if (phong != null)
                        {
                            phong.TrangThai = "TRỐNG";
                        }

                        db.SaveChanges();
                        MessageBox.Show("Đã hủy hợp đồng và cập nhật trạng thái phòng!");

                        // 3. Load lại toàn bộ dữ liệu để cập nhật danh sách phòng trống/khách
                        LoadDataHopDong();
                        LoadCboKhachHang();
                        LoadCboPhongTro();
                        ResetForm();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grid_HopDong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = grid_HopDong.Rows[e.RowIndex];

                // 1. Đổ dữ liệu lên các Control
                txt_MaHD.Text = row.Cells["MAHOPDONG"].Value.ToString();
                txt_TrangThai_HD.Text = row.Cells["TRANGTHAI"].Value.ToString();
                cbo_TenKH.Text = row.Cells["TENKH"].Value.ToString();
                cbo_TenPhong_HD.Text = row.Cells["TENPHONG"].Value.ToString();

                dt_NgayBD_HD.Value = Convert.ToDateTime(row.Cells["NGAYBD"].Value);
                dt_NgayKT_HD.Value = Convert.ToDateTime(row.Cells["NGAYKT"].Value);

                if (row.Cells["TIENCOC"].Value != DBNull.Value) // Kiểm tra dữ liệu null
                {
                    decimal tienCoc = Convert.ToDecimal(row.Cells["TIENCOC"].Value);

                    txt_TienCoc_HD.Text = tienCoc.ToString("N0");
                }
                else
                {
                    txt_TienCoc_HD.Text = "0";
                }

                txt_MaHD.Enabled = false;
                cbo_TenKH.Enabled = false;
                cbo_TenPhong_HD.Enabled = false;
                dt_NgayBD_HD.Enabled = false;

                dt_NgayKT_HD.Enabled = true;
                txt_TienCoc_HD.Enabled = true;
            }
        }
    }
 }
