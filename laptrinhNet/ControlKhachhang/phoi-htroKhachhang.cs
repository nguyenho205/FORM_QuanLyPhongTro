using laptrinhNet.Database;
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

namespace laptrinhNet.ControlKhachhang
{
    public partial class phoi_htroKhachhang : UserControl
    {

        private KhachHang khachHTai;

        public phoi_htroKhachhang()
        {
            InitializeComponent();
        }

        public void SetKhachHang(KhachHang kh)
        {
            if (kh != null)
            {
                khachHTai = kh;
                txtTen.Text = khachHTai.TenKH;


                using (var db = new QLPhongTroDataContext())
                {
                    var hopdong = db.HopDongs
                                    .Where(h => h.MaKH == khachHTai.MaKH)
                                    .OrderByDescending(h => h.MaHopDong)
                                    .FirstOrDefault();

                    if (hopdong != null)
                    {
                        txtSophong.Text = hopdong.MaPhong;
                    }
                    else
                    {
                        txtSophong.Text = "Chưa có phòng";
                    }
                }

                LoadMaPh();
                LoadDanhSachPhanHoi();
            }
        }

        private void LoadMaPh()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var lastYC = db.YeuCauHoTros
                               .OrderByDescending(y => y.MaYeuCau)
                               .FirstOrDefault();

                string newMa = "YC001";
                if (lastYC != null)
                {
                    int number = int.Parse(lastYC.MaYeuCau.Substring(2)) + 1;
                    newMa = "YC" + number.ToString("D3");
                }

                cbMaPH.Text = newMa;
            }
        }
        private void btnGui_Click(object sender, EventArgs e)
        {
            if (khachHTai == null)
            {
                MessageBox.Show("Chưa có khách hàng!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNoidung.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung yêu cầu!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                var yc = new YeuCauHoTro
                {
                    MaYeuCau = cbMaPH.Text,
                    MaKH = khachHTai.MaKH,
                    NgayGui = DateTime.Now,
                    NoiDung = txtNoidung.Text,
                    TrangThai = "Chưa xử lý",
                    MaNV_XuLy = null,
                    NgayXuLy = null,
                    PhanHoi = null
                };

                db.YeuCauHoTros.Add(yc);
                db.SaveChanges();
            }

            MessageBox.Show("Gửi yêu cầu thành công!");
            txtNoidung.Clear();

            LoadMaPh();            
            LoadDanhSachPhanHoi(); //load lập tức
        }


        private void LoadDanhSachPhanHoi()
        {
            if (khachHTai == null) return;

            using (var db = new QLPhongTroDataContext())
            {
                var query = db.YeuCauHoTros.Where(y => y.MaKH == khachHTai.MaKH);

                // Lọc theo checkbox
                if (!checkAll.Checked)
                {
                    List<string> trangThaiLoc = new List<string>();
                    if (checkChuaXL.Checked) trangThaiLoc.Add("Chưa xử lý");
                    if (checkDangXL.Checked) trangThaiLoc.Add("Đang xử lý");
                    if (checkDaXL.Checked) trangThaiLoc.Add("Đã xử lý");

                    if (trangThaiLoc.Count > 0)
                    {
                        query = query.Where(y => trangThaiLoc.Contains(y.TrangThai));
                    }
                    else
                    {

                        query = query.Where(y => false);
                    }
                }

                var dsYC = query
                            .Select(y => new
                            {
                                y.NgayGui,
                                y.NoiDung,
                                //y.TrangThai
                            })
                            .OrderBy(y => y.NgayGui)
                            .ToList();

                dataGridView1.DataSource = dsYC;

                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                dataGridView1.Columns["NoiDung"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns["NoiDung"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dataGridView1.Columns["NgayGui"].HeaderText = "Ngày gửi";
                dataGridView1.Columns["NoiDung"].HeaderText = "Nội dung";
                //dataGridView1.Columns["TrangThai"].HeaderText = "Trạng thái";
                dataGridView1.Columns["NgayGui"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhanHoi();
        }

        private void checkChuaXL_CheckedChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhanHoi();
        }

        private void checkDangXL_CheckedChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhanHoi();
        }

        private void checkDaXL_CheckedChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhanHoi();
        }
       
        
        private void phoi_htroKhachhang_Load(object sender, EventArgs e)
        {
            //mặc định là all
            checkAll.Checked = true;
        }
    }
}
