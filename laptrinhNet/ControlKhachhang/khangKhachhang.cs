using System;
using System.Collections.Generic;
using laptrinhNet.Database;
using laptrinhNet.Database.Entities;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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


        private void khangKhachhang_Load(object sender, EventArgs e)
        {
            LoadThongTinCaNhan();
            LoadThongTinHopDong();
            txtMaKh.Enabled=false;
            txtSoNguoiO.Enabled = false;
        }
        public void LoadThongTinHopDong()
        {
            string connectionString = DangNhap.ConnectionStringHienTai;
            string maKH = DangNhap.NguoiDungHienTai;

            if (string.IsNullOrEmpty(connectionString)) return;

            // Truy vấn lấy thông tin Hợp đồng + Tên Phòng + Giá Phòng
            string query = @"
                SELECT 
                    HD.MAHOPDONG,
                    HD.NGAYBD,
                    HD.NGAYKT,
                    HD.TIENCOC,
                    PT.TENPHONG,
                    LP.GIAPHONG,
                    LP.TENLOAI
                FROM HOPDONG HD
                JOIN PHONGTRO PT ON HD.MAPHONG = PT.MAPHONG
                JOIN LOAI_PHONGTRO LP ON PT.MALOAI = LP.MALOAI
                WHERE HD.MAKH = @MaKH AND HD.TRANGTHAI = N'Còn hạn'";
            // Lưu ý: Chỉ lấy hợp đồng CÒN HẠN

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        // Định dạng tiền tệ (Ví dụ: 1,000,000 VNĐ)
                        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                        string giaPhong = double.Parse(row["GIAPHONG"].ToString()).ToString("#,###", cul.NumberFormat);
                        string tienCoc = double.Parse(row["TIENCOC"].ToString()).ToString("#,###", cul.NumberFormat);

                        // Format ngày tháng (dd/MM/yyyy)
                        string ngayBD = DateTime.Parse(row["NGAYBD"].ToString()).ToString("dd/MM/yyyy");
                        string ngayKT = DateTime.Parse(row["NGAYKT"].ToString()).ToString("dd/MM/yyyy");

                        // Tạo chuỗi thông tin để hiển thị lên Label
                        string thongTin =
                            $"Mã HĐ: {row["MAHOPDONG"]}\n\n" +
                            $"Phòng: {row["TENPHONG"]} ({row["TENLOAI"]})\n\n" +
                            $"Giá phòng: {giaPhong} VNĐ\n\n" +
                            $"Tiền cọc: {tienCoc} VNĐ\n\n" +
                            $"Ngày bắt đầu: {ngayBD}\n\n" +
                            $"Ngày kết thúc: {ngayKT}";

                        // Gán vào Label nằm trên Panel xanh
                        lblChiTietHopDong.Text = thongTin;
                    }
                    else
                    {
                        lblChiTietHopDong.Text = "Khách hàng chưa có hợp đồng thuê phòng \nhoặc hợp đồng đã hết hạn.";
                    }
                }
                catch (Exception ex)
                {
                    lblChiTietHopDong.Text = "Lỗi tải hợp đồng.";
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        public void LoadThongTinCaNhan()
        {
            // 1. Lấy chuỗi kết nối và Mã khách hàng từ form Đăng Nhập
            string connectionString = DangNhap.ConnectionStringHienTai;
            string maKH = DangNhap.NguoiDungHienTai; // Lấy mã KH (Ví dụ: KH01)

            // Kiểm tra an toàn
            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(maKH)) return;

            // 2. CÂU TRUY VẤN KẾT HỢP (JOIN) CÁC BẢNG
            // Mục đích: Lấy thông tin khách + Số người đang ở từ bảng Phòng trọ
            string query = @"
                SELECT 
                    KH.MAKH, 
                    KH.TENKH, 
                    KH.SODIENTHOAI, 
                    KH.SOCMND, 
                    KH.DIACHITHUONGTRU, 
                    PT.SONGUOIHIENTAI
                FROM KHACHHANG KH
                LEFT JOIN HOPDONG HD ON KH.MAKH = HD.MAKH AND HD.TRANGTHAI = N'Còn hạn'
                LEFT JOIN PHONGTRO PT ON HD.MAPHONG = PT.MAPHONG
                WHERE KH.MAKH = @MaKH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKH", maKH); // Truyền tham số để bảo mật

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 3. Hiển thị dữ liệu lên các TextBox
                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        // Ánh xạ dữ liệu từ CSDL sang TextBox
                        txtMaKh.Text = row["MAKH"].ToString();
                        txtTenKh.Text = row["TENKH"].ToString();
                        txtSDT.Text = row["SODIENTHOAI"].ToString();
                        txtCCCD.Text = row["SOCMND"].ToString();          // Mapping SOCMND -> txtCCCD
                        txtQueQuan.Text = row["DIACHITHUONGTRU"].ToString(); // Mapping DIACHITHUONGTRU -> txtQueQuan

                        // Xử lý trường Số người ở (Có thể null nếu khách chưa thuê phòng nào)
                        if (row["SONGUOIHIENTAI"] != DBNull.Value)
                        {
                            txtSoNguoiO.Text = row["SONGUOIHIENTAI"].ToString();
                        }
                        else
                        {
                            txtSoNguoiO.Text = "Chưa thuê";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải thông tin cá nhân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string connectionString = DangNhap.ConnectionStringHienTai;
            string maKH = DangNhap.NguoiDungHienTai; // Lấy mã KH từ biến toàn cục (KH01)

            // Lấy dữ liệu mới từ giao diện
            string tenMoi = txtTenKh.Text.Trim();
            string sdtMoi = txtSDT.Text.Trim();
            string cccdMoi = txtCCCD.Text.Trim();
            string diaChiMoi = txtQueQuan.Text.Trim();

            // 2. KIỂM TRA DỮ LIỆU ĐẦU VÀO (Validation)
            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(tenMoi) || string.IsNullOrEmpty(sdtMoi) || string.IsNullOrEmpty(cccdMoi))
            {
                MessageBox.Show("Vui lòng không để trống Tên, Số điện thoại hoặc CCCD!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ràng buộc SQL (Trong SQL bạn đã set CHECK độ dài)
            // Nếu không kiểm tra ở đây, SQL sẽ báo lỗi Exception rất dài dòng
            if (sdtMoi.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đúng 10 số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cccdMoi.Length != 12)
            {
                MessageBox.Show("CCCD/CMND phải đúng 12 số!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. THỰC HIỆN CÂU LỆNH UPDATE
            // Lưu ý: Không được Update MAKH và SONGUOIHIENTAI
            string query = @"UPDATE KHACHHANG 
                     SET TENKH = @Ten, 
                         SODIENTHOAI = @Sdt, 
                         SOCMND = @Cccd, 
                         DIACHITHUONGTRU = @DiaChi 
                     WHERE MAKH = @MaKH";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Gán tham số an toàn
                    cmd.Parameters.AddWithValue("@Ten", tenMoi);
                    cmd.Parameters.AddWithValue("@Sdt", sdtMoi);
                    cmd.Parameters.AddWithValue("@Cccd", cccdMoi);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChiMoi);
                    cmd.Parameters.AddWithValue("@MaKH", maKH); // Điều kiện WHERE

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Load lại dữ liệu để đảm bảo hiển thị đúng nhất từ DB
                        LoadThongTinCaNhan();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    // Bắt các lỗi từ SQL (ví dụ: trùng SĐT, trùng CCCD nếu bạn có set UNIQUE)
                    if (ex.Message.Contains("UNIQUE") || ex.Number == 2627)
                    {
                        MessageBox.Show("Số điện thoại hoặc CCCD này đã được sử dụng bởi người khác!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message);
                }
            }
        }

    }
}
