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
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace laptrinhNet.ControlKhachhang
{
    public partial class khangKhachhang : UserControl
    {
        public khangKhachhang()
        {
            InitializeComponent();
        }
        private void khangKhachhang_Load(object sender, EventArgs e)
        {
            txtMatkhau.UseSystemPasswordChar = true; // mặc định ẩn matkhau

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
                    txtEmail.Text = KhachDaChon.EmailKhachHang;
                    txtMatkhau.Text = KhachDaChon.MatKhau;

                    
                    tenBanDau = KhachDaChon.TenKH;
                    diaChiBanDau = KhachDaChon.DiaChiThuongTru;
                    sdtBanDau = KhachDaChon.SoDienThoai;
                    cccdBanDau = KhachDaChon.SoCMND;
                    emailBanDau = KhachDaChon.EmailKhachHang;
                    matKhauBanDau = KhachDaChon.MatKhau;

                    KhachHangChanged?.Invoke(KhachDaChon);
                }
            }
        }

        private string tenBanDau;
        private string diaChiBanDau;
        private string sdtBanDau;
        private string cccdBanDau;
        private string emailBanDau;
        private string matKhauBanDau;

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
                    txtEmail.Text = KhachDaChon.EmailKhachHang;
                    txtMatkhau.Text = KhachDaChon.MatKhau;

                    
                    tenBanDau = KhachDaChon.TenKH;
                    diaChiBanDau = KhachDaChon.DiaChiThuongTru;
                    sdtBanDau = KhachDaChon.SoDienThoai;
                    cccdBanDau = KhachDaChon.SoCMND;
                    emailBanDau = KhachDaChon.EmailKhachHang;
                    matKhauBanDau = KhachDaChon.MatKhau;

                    KhachHangChanged?.Invoke(KhachDaChon);
                }
            }
        }
        private void tbnSua_Click(object sender, EventArgs e)
        {
            if (KhachDaChon == null)
            {
                MessageBox.Show("Chưa chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin mới từ textbox
            string tenMoi = txtTen.Text.Trim();
            string diaChiMoi = txtDiachi.Text.Trim();
            string sdtMoi = txtSdt.Text.Trim();
            string cccdMoi = txtCCCD.Text.Trim();
            string emailMoi = txtEmail.Text.Trim();
            string matKhauMoi = txtMatkhau.Text.Trim();

            // Kiểm tra thay đổi khong
            bool infoChanged = tenMoi != tenBanDau ||
                               diaChiMoi != diaChiBanDau ||
                               sdtMoi != sdtBanDau ||
                               cccdMoi != cccdBanDau ||
                               emailMoi != emailBanDau ||
                               matKhauMoi != matKhauBanDau;

            if (!infoChanged)
            {
                MessageBox.Show("Thông tin khách hàng chưa thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Nếu có thay đổi, yêu cầu nhập mật khẩu hiện tại để xác thực
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập mật khẩu hiện tại để xác thực trước khi cập nhật thông tin:",
                "Xác thực mật khẩu", "");

            if (input != matKhauBanDau)
            {
                MessageBox.Show("Mật khẩu không đúng! Không thể cập nhật thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (matKhauMoi != matKhauBanDau)
            {
                if (string.IsNullOrEmpty(matKhauMoi))
                {
                    MessageBox.Show("Phải nhập mật khẩu mới để cập nhật mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string pattern = @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$";
                if (!Regex.IsMatch(matKhauMoi, pattern))
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 8 ký tự, bao gồm chữ và số, KHÔNG chứa ký tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Cập nhật thông tin vào DB
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
                        kh.EmailKhachHang = emailMoi;
                        kh.MatKhau = matKhauMoi;

                        db.SaveChanges();
                    }
                }


                tenBanDau = KhachDaChon.TenKH = tenMoi;
                diaChiBanDau = KhachDaChon.DiaChiThuongTru = diaChiMoi;
                sdtBanDau = KhachDaChon.SoDienThoai = sdtMoi;
                cccdBanDau = KhachDaChon.SoCMND = cccdMoi;
                emailBanDau = KhachDaChon.EmailKhachHang = emailMoi;
                matKhauBanDau = KhachDaChon.MatKhau = matKhauMoi;

                MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhachHangChanged?.Invoke(KhachDaChon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool isHandling = false;

        private void checkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (isHandling) return; //tránh lặp

            isHandling = true;

            if (KhachDaChon == null)
            {
                checkHienMK.Checked = false;
                MessageBox.Show("Chưa chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isHandling = false;
                return;
            }

            if (checkHienMK.Checked)
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu hiện tại để hiển thị:", "Xác thực mật khẩu", "");

                if (input == KhachDaChon.MatKhau)
                {
                    txtMatkhau.UseSystemPasswordChar = false;
                }
                else
                {
                    MessageBox.Show("Mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkHienMK.Checked = false;
                    txtMatkhau.UseSystemPasswordChar = true;
                }
            }
            else
            {
                txtMatkhau.UseSystemPasswordChar = true;
            }

            isHandling = false;
        }

    }
}
