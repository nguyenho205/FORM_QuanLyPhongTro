using laptrinhNet;
using laptrinhNet.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laptrinhNet
{
    public partial class OTP : Form
    {
        public OTP()
        {
            InitializeComponent();
        }

        public string EmailKhachHang { get; set; }

        Random random = new Random();
        int otp;

        private void btnGuiOTP_Click(object sender, EventArgs e)
        {
            try
            {
                otp = random.Next(100000, 999999);

                var fromAddress = new MailAddress("pdbhop409@gmail.com"); //mail gửi  otp
                var toAddress = new MailAddress(txtEmail.ToString()); //mail nhận otp
                const string fromPassword = "ilaxbjwkapkiaxqq"; //mật khẩu mail gửi otp
                const string subject = "Mã OTP xác nhận";
                string body = otp.ToString();

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 200000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                MessageBox.Show("Mã OTP đã được gửi đến email của bạn.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXacthuc_Click(object sender, EventArgs e)
        {
            if (otp.ToString().Equals(txtOTP.Text))
            {
                // Lấy mã KH mới từ database
                string newMaKH = TaoMaKH_SQL();

                string matKhau = "123";

                MessageBox.Show(
                    $"Xác thực thành công!\n\nTên đăng nhập: {newMaKH}\nMật khẩu: {matKhau}",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Mã OTP không đúng. Vui lòng thử lại.");
            }
        }

        // ====== Tạo mã KH theo mã cuối trong SQL ========
        private string TaoMaKH_SQL()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var last = db.KhachHangs
                             .OrderByDescending(x => x.MaKH)
                             .Select(x => x.MaKH)
                             .FirstOrDefault();

                int number = 0;

                if (!string.IsNullOrEmpty(last) && last.Length >= 4)
                {
                    number = int.Parse(last.Substring(2)); // lấy phần số
                }

                number++;

                return "KH" + number.ToString("00"); // KH01, KH02…
            }
        }
    }
}