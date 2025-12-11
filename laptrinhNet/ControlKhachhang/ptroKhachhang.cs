using laptrinhNet.Database;
using laptrinhNet.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet.ControlKhachHang
{
    public partial class ptroKhachhang : UserControl
    {
        public ptroKhachhang()
        {
            InitializeComponent();
        }
        private void Load_GirdView(List<string> trangThaickBox = null)
        {
            using (var db = new QLPhongTroDataContext())
            {
                var query = db.PhongTros.Include("LoaiPTDaTa").AsQueryable();

                if (trangThaickBox != null && trangThaickBox.Count > 0)
                {
                    query = query.Where(p => trangThaickBox.Contains(p.TrangThai));
                }

                var data = query
                    .Select(p => new
                    {
                        p.MaPhong,
                        p.TenPhong,
                        TenLoai = p.LoaiPTDaTa.TenLoai, // lấy tên loại từ navigation property
                        p.TrangThai,
                        p.GhiChu
                    })
                    .ToList();


                SetupGridColumns();
                dgvDanhSachPhong.DataSource = data;
            }
        }




        private void ptroKhachhang_Load(object sender, EventArgs e)
        {
            Load_GirdView();
            LoadComboBoxPhong();


            dgvDanhSachPhong.DefaultCellStyle.Font = new Font("Segoe UI", 12);///dulieu
            dgvDanhSachPhong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);//tên cột

            dgvDanhSachPhong.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDanhSachPhong.Columns["TrangThai"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvDanhSachPhong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvDanhSachPhong.CellClick += dataGridView1_CellClick;

            cboMaPhong.SelectedIndexChanged += cbMaphong_SelectedIndexChanged;

            chkChuaThue.CheckedChanged += FilterCheckBoxes_CheckedChanged;
            chkDaThue.CheckedChanged += FilterCheckBoxes_CheckedChanged;
            chkBaoTri.CheckedChanged += FilterCheckBoxes_CheckedChanged;

        }

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        
        //        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

        //        
        //        cbMaphong.Text = row.Cells["MAPHONG"].Value.ToString();
        //        txtSophong.Text = row.Cells["TENPHONG"].Value.ToString();
        //        txtGhiChu.Text = row.Cells["GHICHU"].Value.ToString();
        //    }
        //}

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDanhSachPhong.Rows[e.RowIndex];

            string maPhong = row.Cells["MaPhong"].Value.ToString();
            cboMaPhong.SelectedValue = maPhong;

            txtTenPhong.Text = row.Cells["TenPhong"].Value.ToString();

            using (var db = new QLPhongTroDataContext())
            {
                var phong = db.PhongTros.Include("LoaiPTDaTa").FirstOrDefault(p => p.MaPhong == maPhong);

                if (phong != null)
                {
                    txtTenPhong.Text = phong.TenPhong;
                    txtMoTa.Text = phong.GhiChu;
                    txtLoaiPhong.Text = phong.LoaiPTDaTa?.TenLoai ?? "";
                    var culture = new CultureInfo("vi-VN");
                    txtGiaPhong.Text = phong.LoaiPTDaTa != null && phong.LoaiPTDaTa.GiaPhong.HasValue? phong.LoaiPTDaTa.GiaPhong.Value.ToString("N0", culture): "";
                }
            }
        }



        //hien thi all phong tro len combobox
        private void LoadComboBoxPhong()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var listPhong = db.PhongTros.Select(p => new { p.MaPhong, p.TenPhong }).ToList();

                cboMaPhong.DataSource = listPhong;
                cboMaPhong.DisplayMember = "MaPhong";
                cboMaPhong.ValueMember = "MaPhong";

                cboMaPhong.SelectedIndex = -1;
            }
        }

        private void FilterCheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            List<string> ckbox = new List<string>();

            if (chkChuaThue.Checked) ckbox.Add("TRỐNG");
            if (chkDaThue.Checked) ckbox.Add("ĐANG THUÊ");
            if (chkBaoTri.Checked) ckbox.Add("Bảo trì");

            Load_GirdView(ckbox);
        }
        private void btnDangky_Click(object sender, EventArgs e)
        {
            string ten = txtTenNguoiThue.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập Tên và Số điện thoại!", "Lỗi");
                return;
            }

            if (string.IsNullOrEmpty(cboMaPhong.Text))
            {
                MessageBox.Show("Bạn chưa chọn phòng!", "Lỗi");
                return;
            }

            if (dtpTuNgay.Value.Date >= dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "Lỗi");
                return;
            }

            // Xác thực OTP
        //    OTP maxacthuc = new OTP();
        //    maxacthuc.EmailKhachHang = txtEmail.Text.Trim();
        //    this.Hide();
        //    var result = maxacthuc.ShowDialog();
        //    this.Show();

        //    if (result != DialogResult.OK)
        //    {
        //        MessageBox.Show("Bạn chưa xác thực OTP!");
        //        return;
        //    }

        //    try
        //    {
        //        using (var db = new QLPhongTroDataContext())
        //        {
        //            // 1. Lấy phòng và loại phòng
        //            var phong = db.PhongTros.Include("LoaiPTDaTa")
        //                                     .FirstOrDefault(p => p.MaPhong == cbMaphong.Text);
        //            if (phong == null)
        //            {
        //                MessageBox.Show("Không tìm thấy phòng đã chọn!", "Lỗi");
        //                return;
        //            }
        //            var loaiPhong = phong.LoaiPTDaTa;

        //            // 2. Tạo khách hàng mới
        //            string newMaKH = TaoMaKH(db);
        //            KhachHang kh = new KhachHang
        //            {
        //                MaKH = newMaKH,
        //                TenKH = ten,
        //                SoDienThoai = sdt,
        //                SoCMND = cccd,
        //                EmailKhachHang = email,
        //                DiaChiThuongTru = "Chưa cập nhật"
        //            };
        //            db.KhachHangs.Add(kh);

        //            // **Bắt buộc save khách hàng trước để tránh lỗi FK**
        //            db.SaveChanges();

        //            // 3. Tạo hợp đồng mới
        //            string newMaHD = TaoMaHD(db);
        //            HopDong hd = new HopDong
        //            {
        //                MaHopDong = newMaHD,
        //                NgayBD = Tungay.Value.Date,
        //                NgayKT = Denngay.Value.Date,
        //                TrangThai = "ĐANG THUÊ",
        //                MaKH = kh.MaKH, // chắc chắn khách hàng đã có trong DB
        //                MaPhong = cbMaphong.Text,
        //                TienCoc = loaiPhong?.GiaPhong ?? 0
        //            };
        //            db.HopDongs.Add(hd);

        //            // 4. Cập nhật trạng thái phòng
        //            phong.TrangThai = "ĐANG THUÊ";

        //            // Lưu tất cả thay đổi
        //            db.SaveChanges();
        //        }

        //        // Refresh GridView
        //        Load_GirdView();
        //        MessageBox.Show("Đăng ký thuê thành công!", "Thành công");
        //    }
        //    catch (Exception ex)
        //    {
        //        while (ex.InnerException != null)
        //            ex = ex.InnerException;

        //        MessageBox.Show("Lỗi thực tế:\n" + ex.Message);
        //    }
        }



        //try
        //{
        //    using (var db = new QLPhongTroDataContext())
        //    {
        //        //tạo kh mới dky
        //        string newMaKH = TaoMaKH(db);

        //        KhachHang kh = new KhachHang
        //        {
        //            MaKH = newMaKH,
        //            TenKH = ten,
        //            SoDienThoai = sdt,
        //            SoCMND = cccd,
        //            EmailKhachHang = email,
        //            DiaChiThuongTru = "Chưa cập nhật"
        //        };

        //        db.KhachHangs.Add(kh);
        //        db.SaveChanges();


        //        //tao5hop75 đồng
        //        string newMaHD = TaoMaHD(db);

        //        HopDong hd = new HopDong
        //        {
        //            MaHopDong = newMaHD,
        //            NgayBD = Tungay.Value.Date,
        //            NgayKT = Denngay.Value.Date,
        //            TrangThai = "ĐANG THUÊ",
        //            MaKH = newMaKH,
        //            MaPhong = cbMaphong.Text,
        //            TienCoc = 1
        //        };

        //        db.HopDongs.Add(hd);

        //        //update trạng thái phòng
        //        var phong = db.PhongTros.FirstOrDefault(p => p.MaPhong == cbMaphong.Text);
        //        if (phong != null)
        //            phong.TrangThai = "ĐANG THUÊ";

        //        db.SaveChanges();
        //    }

        //    MessageBox.Show("Đăng ký thuê thành công", "Thành công");
        //}

        ////báo lỗi
        //catch (Exception ex)
        //{
        //    Exception realError = ex;
        //    while (realError.InnerException != null)
        //        realError = realError.InnerException;

        //    MessageBox.Show("Lỗi thực tế:\n" + realError.Message);

        //ẩn cột gridview
        private void SetupGridColumns()
        {
            dgvDanhSachPhong.Columns.Clear();

            
            dgvDanhSachPhong.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaPhong",
                HeaderText = "Mã phòng",
                Name = "MaPhong"
            });

            
            dgvDanhSachPhong.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenPhong",
                HeaderText = "Tên phòng",
                Name = "TenPhong"
            });

            //ẩn
            dgvDanhSachPhong.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "GhiChu",
                HeaderText = "Ghi chú",
                Name = "GhiChu",
                Visible = false
            });

            dgvDanhSachPhong.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenLoai",
                
                Name = "TenLoai",
                Visible = false
            });
            
            dgvDanhSachPhong.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TrangThai",
                HeaderText = "Trạng thái",
                Name = "TrangThai",
            });
        }




        private string TaoMaKH(QLPhongTroDataContext db)
        {
            var last = db.KhachHangs
                         .OrderByDescending(x => x.MaKH)
                         .Select(x => x.MaKH)
                         .FirstOrDefault();

            int number = 0;

            if (!string.IsNullOrEmpty(last) && last.Length >= 4)
            {
                number = int.Parse(last.Substring(2));
            }

            number++;

            return "KH" + number.ToString("00");
        }

        private string TaoMaHD(QLPhongTroDataContext db)
        {
            var last = db.HopDongs
                         .OrderByDescending(x => x.MaHopDong)
                         .Select(x => x.MaHopDong)
                         .FirstOrDefault();

            int number = 0;

            if (!string.IsNullOrEmpty(last) && last.Length >= 4)
            {
                number = int.Parse(last.Substring(2));
            }

            number++;

            return "HD" + number.ToString("00");
        }




        private void cbMaphong_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboMaPhong.SelectedIndex < 0) return;

            string maPhong = cboMaPhong.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maPhong)) return;

            using (var db = new QLPhongTroDataContext())
            {
                var phong = db.PhongTros.FirstOrDefault(p => p.MaPhong == maPhong);
                if (phong != null)
                {
                    txtTenPhong.Text = phong.TenPhong;
                    txtMoTa.Text = phong.GhiChu;
                }
            }
        }
    }
}

