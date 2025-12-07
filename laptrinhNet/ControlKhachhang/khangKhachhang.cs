using System;
using System.Collections.Generic;
using laptrinhNet.Database;
using laptrinhNet.Database.Entities;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet.ControlKhachhang
{
    public partial class khangKhachhang : UserControl
    {
        public khangKhachhang()
        {
            InitializeComponent();
        }

        public KhachHang KhachDaChon { get; private set; }

        public event Action<KhachHang> KhachHangChanged;

        public void Load_RandomIn4()
        {
            using (var db = new QLPhongTroDataContext())
            {
                KhachDaChon = db.KhachHangs
                                .OrderBy(c => Guid.NewGuid())
                                .FirstOrDefault();

                if (KhachDaChon != null)
                {
                    txtMa.Text = KhachDaChon.MaKH;
                    txtTen.Text = KhachDaChon.TenKH;
                    txtDiachi.Text = KhachDaChon.DiaChiThuongTru;
                    txtSdt.Text = KhachDaChon.SoDienThoai;
                    txtCCCD.Text = KhachDaChon.SoCMND;

                    KhachHangChanged?.Invoke(KhachDaChon);
                }
            }
        }

        public void Load_KhachHang(string maKH)
        {
            using (var db = new QLPhongTroDataContext())
            {
                KhachDaChon = db.KhachHangs
                .AsNoTracking()
                .FirstOrDefault(c => c.MaKH == maKH);


                if (KhachDaChon != null)
                {
                    txtMa.Text = KhachDaChon.MaKH;
                    txtTen.Text = KhachDaChon.TenKH;
                    txtDiachi.Text = KhachDaChon.DiaChiThuongTru;
                    txtSdt.Text = KhachDaChon.SoDienThoai;
                    txtCCCD.Text = KhachDaChon.SoCMND;

                    KhachHangChanged?.Invoke(KhachDaChon);
                }
            }
        }


        private void khangKhachhang_Load(object sender, EventArgs e)
        {
            
        }

        private void tbnSua_Click(object sender, EventArgs e)
        {

            string tenMoi = txtTen.Text.Trim();
            string diaChiMoi = txtDiachi.Text.Trim();
            string sdtMoi = txtSdt.Text.Trim();
            string cccdMoi = txtCCCD.Text.Trim();

            if (string.IsNullOrEmpty(tenMoi) || string.IsNullOrEmpty(sdtMoi))
            {
                MessageBox.Show("Tên và Số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new QLPhongTroDataContext())
                {

                    var kh = db.KhachHangs.FirstOrDefault(k => k.MaKH == KhachDaChon.MaKH);
                    if (kh != null)
                    {
                        kh.TenKH = tenMoi;
                        kh.DiaChiThuongTru = diaChiMoi;
                        kh.SoDienThoai = sdtMoi;
                        kh.SoCMND = cccdMoi;

                        db.SaveChanges(); // lưu vào DB
                    }
                }

                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại đối tượng KhachDaChon
                KhachDaChon.TenKH = tenMoi;
                KhachDaChon.DiaChiThuongTru = diaChiMoi;
                KhachDaChon.SoDienThoai = sdtMoi;
                KhachDaChon.SoCMND = cccdMoi;

                KhachHangChanged?.Invoke(KhachDaChon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
