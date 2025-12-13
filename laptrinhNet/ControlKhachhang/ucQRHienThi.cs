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
    public partial class ucQRHienThi : UserControl
    {
        public event EventHandler ButtonBackClicked;
        string NganHang_ID = "MB";
        string SoTaiKhoan = "0375157947";   
        string TenChuTaiKhoan = "NGUYEN PHI HO";
        public ucQRHienThi(string maHD, decimal soTien)
        {
            InitializeComponent();
            LoadQR(maHD, soTien);
        }
        private void LoadQR(string maHD, decimal soTien)
        {
            try
            {
                
                lblThongTin.Text = $"Đang thanh toán HĐ: {maHD}\n" +
                                   $"Tổng tiền: {soTien.ToString("N0")} VNĐ\n" +
                                   $"Vui lòng quét mã bên dưới:";

                //// Cấu trúc API: https://img.vietqr.io/image/<BANK_ID>-<ACCOUNT_NO>-<TEMPLATE>.png?amount=<AMOUNT>&addInfo=<CONTENT>&accountName=<NAME>

                string noiDungChuyenKhoan = $"TT HOADON {maHD}"; 

                string url = $"https://img.vietqr.io/image/{NganHang_ID}-{SoTaiKhoan}-print.png?amount={soTien}&addInfo={noiDungChuyenKhoan}&accountName={TenChuTaiKhoan}";

                picQR.Load(url);
            }
            catch (Exception ex)
            {
                lblThongTin.Text = "Lỗi tải mã QR. Vui lòng kiểm tra kết nối mạng!";
            }
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            if (ButtonBackClicked != null)
            {
                ButtonBackClicked(this, EventArgs.Empty);
            }

        }

        private void picQR_Click(object sender, EventArgs e)
        {

        }
    }
}
