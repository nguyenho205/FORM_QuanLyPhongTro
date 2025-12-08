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
                dataGridView1.DataSource = data;
            }
        }




        private void ptroKhachhang_Load(object sender, EventArgs e)
        {
            Load_GirdView();
            LoadComboBoxPhong();


            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);///dulieu
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);//tên cột

            dataGridView1.Columns["TrangThai"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["TrangThai"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataGridView1.CellClick += dataGridView1_CellClick;

            cbMaphong.SelectedIndexChanged += cbMaphong_SelectedIndexChanged;

            checkChuathue.CheckedChanged += FilterCheckBoxes_CheckedChanged;
            checkDathue.CheckedChanged += FilterCheckBoxes_CheckedChanged;
            checkBaotri.CheckedChanged += FilterCheckBoxes_CheckedChanged;

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

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            string maPhong = row.Cells["MaPhong"].Value.ToString();
            cbMaphong.SelectedValue = maPhong;

            txtSophong.Text = row.Cells["TenPhong"].Value.ToString();

            using (var db = new QLPhongTroDataContext())
            {
                var phong = db.PhongTros.Include("LoaiPTDaTa").FirstOrDefault(p => p.MaPhong == maPhong);

                if (phong != null)
                {
                    txtSophong.Text = phong.TenPhong;
                    txtGhiChu.Text = phong.GhiChu;
                    txtTenLoai.Text = phong.LoaiPTDaTa?.TenLoai ?? "";
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

                cbMaphong.DataSource = listPhong;
                cbMaphong.DisplayMember = "MaPhong";
                cbMaphong.ValueMember = "MaPhong";

                cbMaphong.SelectedIndex = -1;
            }
        }

        private void FilterCheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            List<string> ckbox = new List<string>();

            if (checkChuathue.Checked) ckbox.Add("TRỐNG");
            if (checkDathue.Checked) ckbox.Add("ĐANG THUÊ");
            if (checkBaotri.Checked) ckbox.Add("Bảo trì");

            Load_GirdView(ckbox);
        }
        private void btnDangky_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text.Trim();
            string sdt = txtSdt.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập Tên và Số điện thoại!", "Lỗi");
                return;
            }

            if (string.IsNullOrEmpty(cbMaphong.Text))
            {
                MessageBox.Show("Bạn chưa chọn phòng!", "Lỗi");
                return;
            }

            if (Tungay.Value.Date >= Denngay.Value.Date)
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
            dataGridView1.Columns.Clear();

            
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaPhong",
                HeaderText = "Mã phòng",
                Name = "MaPhong"
            });

            
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenPhong",
                HeaderText = "Tên phòng",
                Name = "TenPhong"
            });

            //ẩn
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "GhiChu",
                HeaderText = "Ghi chú",
                Name = "GhiChu",
                Visible = false
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenLoai",
                
                Name = "TenLoai",
                Visible = false
            });
            
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
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

            if (cbMaphong.SelectedIndex < 0) return;

            string maPhong = cbMaphong.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maPhong)) return;

            using (var db = new QLPhongTroDataContext())
            {
                var phong = db.PhongTros.FirstOrDefault(p => p.MaPhong == maPhong);
                if (phong != null)
                {
                    txtSophong.Text = phong.TenPhong;
                    txtGhiChu.Text = phong.GhiChu;
                }
            }
        }
    }
}

