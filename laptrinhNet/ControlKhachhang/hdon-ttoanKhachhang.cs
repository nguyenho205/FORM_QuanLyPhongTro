using laptrinhNet.Database;
using laptrinhNet.Database.DTOs;
using laptrinhNet.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using iTextSharp.text;  
using iTextSharp.text.pdf; 
using System.IO;        
using System.Diagnostics;
namespace laptrinhNet.ControlKhachhang
{
    public partial class hdon_ttoanKhachhang : UserControl
    {
        string connectionString = @"Data Source=DESKTOP-IQCO6JU\SQLEXPRESS;Initial Catalog=QUANLY_PHONGTRO;User ID = sa;Password=123";
        public hdon_ttoanKhachhang()
        {
            InitializeComponent();
        }

        private void hdon_ttoanKhachhang_Load(object sender, EventArgs e)
        {
            string maKH = DangNhap.NguoiDungHienTai; // Lấy mã KH từ class Đăng Nhập (VD: KH02)

            if (!string.IsNullOrEmpty(maKH) && maKH.ToUpper().StartsWith("KH"))
            {
                // 1. Load danh sách hóa đơn vào ComboBox
                LoadComboBoxHoaDon(maKH);

                // 2. [CURSOR] Tính tổng số phòng đang thuê
                HienThiSoPhongDangThue(maKH);
            }

            // Cài đặt TextBox chỉ đọc
            txtTienDien.ReadOnly = true;
            txtTienNuoc.ReadOnly = true;
            txtTienDichVu.ReadOnly = true;
            txtTienPhong.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtSoPhongDangThue.ReadOnly = true;
        }


        private void LoadComboBoxHoaDon(string maKH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // --- SỬA LỖI Ở ĐÂY: Phải gọi đúng thủ tục lấy danh sách ---
                    SqlCommand cmd = new SqlCommand("sp_LayDS_HoaDon_TheoKH", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboMaHD.DataSource = dt;
                    cboMaHD.DisplayMember = "MAHD";
                    cboMaHD.ValueMember = "MAHD";

                    cboMaHD.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải danh sách hóa đơn: " + ex.Message);
                }
            }
        }

        private void HienThiSoPhongDangThue(string maKH)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DemPhongDangThue_Cursor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaKH", maKH);

                    // Khai báo tham số đầu ra (OUTPUT) để lấy kết quả từ Cursor SQL
                    SqlParameter outParam = new SqlParameter("@SoLuong", SqlDbType.Int);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery(); // Thực thi thủ tục

                    // Lấy kết quả
                    txtSoPhongDangThue.Text = outParam.Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tính số phòng: " + ex.Message);
                }
            }
        }
        private void cboMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaHD.SelectedValue == null) return;

            string maHD = cboMaHD.SelectedValue.ToString();

            // Gọi 2 hàm để hiển thị dữ liệu
            HienThiChiTietTungLoai(maHD);
            HienThiTongTien_Cursor(maHD);
        }
        private void HienThiChiTietTungLoai(string maHD)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_LayChiTiet_Tien_TungLoai", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaHD", maHD);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            System.Globalization.CultureInfo cul = new System.Globalization.CultureInfo("vi-VN");

                            // 1. Hiển thị Tiền
                            txtTienDien.Text = decimal.Parse(reader["TienDien"].ToString()).ToString("N0", cul);
                            txtTienNuoc.Text = decimal.Parse(reader["TienNuoc"].ToString()).ToString("N0", cul);
                            txtTienDichVu.Text = decimal.Parse(reader["DichVuKhac"].ToString()).ToString("N0", cul);
                            txtTienPhong.Text = decimal.Parse(reader["TienPhong"].ToString()).ToString("N0", cul);

                            // 2. Hiển thị Số lượng dùng
                            if (reader["DienDaDung"] != DBNull.Value)
                                txtDienDaDung.Text = reader["DienDaDung"].ToString();

                            if (reader["NuocDaDung"] != DBNull.Value)
                                txtNuocDaDung.Text = reader["NuocDaDung"].ToString();

                            // 3. Hiển thị Ghi chú và Trạng thái (Dùng TextBox)
                            if (reader["GHICHU"] != DBNull.Value)
                                txtGhiChu.Text = reader["GHICHU"].ToString();

                            if (reader["TRANGTHAITHANHTOAN"] != DBNull.Value)
                                txtTrangThai.Text = reader["TRANGTHAITHANHTOAN"].ToString(); // Đã sửa thành TextBox

                            // 4. Hiển thị Ngày
                            if (reader["NGAYLAP"] != DBNull.Value)
                                dtpNgayLap.Value = Convert.ToDateTime(reader["NGAYLAP"]);

                            if (reader["HANTHANHTOAN"] != DBNull.Value)
                                dtpHanThanhToan.Value = Convert.ToDateTime(reader["HANTHANHTOAN"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi hiển thị chi tiết: " + ex.Message);
                }
            }


        }
        private void HienThiTongTien_Cursor(string maHD)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_TinhTongTien_Cursor", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaHD", maHD);

                    // Tham số OUTPUT nhận kết quả từ Cursor
                    SqlParameter outParam = new SqlParameter("@TongTien", SqlDbType.Money);
                    outParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParam);

                    cmd.ExecuteNonQuery();

                    System.Globalization.CultureInfo cul = new System.Globalization.CultureInfo("vi-VN");
                    if (outParam.Value != DBNull.Value)
                    {
                        txtTongTien.Text = decimal.Parse(outParam.Value.ToString()).ToString("N0", cul);
                    }
                    else
                    {
                        txtTongTien.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tính tổng tiền: " + ex.Message);
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (cboMaHD.SelectedIndex == -1 || string.IsNullOrEmpty(txtTongTien.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
               
                string tempPath = Path.Combine(Path.GetTempPath(), "HoaDon_Preview.pdf");

                XuatHoaDonPDF(tempPath);

              
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    FileName = tempPath,
                    UseShellExecute = true 
                };
                p.Start();

           
                DialogResult result = MessageBox.Show(
                    "Hóa đơn đã được tạo và mở để xem trước.\nBạn có muốn LƯU file này vào máy tính không?",
                    "Xác nhận lưu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                   
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "PDF Files|*.pdf";
                    sfd.FileName = "HoaDon_" + cboMaHD.SelectedValue.ToString() + ".pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.Copy(tempPath, sfd.FileName, true);
                        MessageBox.Show("Đã lưu hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void XuatHoaDonPDF(string path)
        {
            // 1. Tạo tài liệu khổ A4, căn lề
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.Create));

            pdfDoc.Open(); // Bắt đầu viết

            // 2. Cài đặt Font chữ tiếng Việt (Rất quan trọng để không bị lỗi font)
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            // Tạo các style font
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.BOLD, BaseColor.BLUE);
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font textFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font boldFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font italicFont = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.ITALIC);

            // 3. Header: Thông tin nhà trọ
            PdfPTable tblHeader = new PdfPTable(1);
            tblHeader.WidthPercentage = 100;

            PdfPCell cellHeader = new PdfPCell(new Phrase("HỆ THỐNG QUẢN LÝ PHÒNG TRỌ", headerFont));
            cellHeader.Border = 0;
            cellHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tblHeader.AddCell(cellHeader);

            cellHeader = new PdfPCell(new Phrase("Địa chỉ: TP. Hồ Chí Minh - Hotline: 0909.123.456", textFont));
            cellHeader.Border = 0;
            cellHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tblHeader.AddCell(cellHeader);

            tblHeader.SpacingAfter = 20;
            pdfDoc.Add(tblHeader);

            // 4. Tiêu đề Hóa đơn
            Paragraph title = new Paragraph("HÓA ĐƠN TIỀN TRỌ", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10;
            pdfDoc.Add(title);

            // 5. Thông tin chung
            PdfPTable tblInfo = new PdfPTable(2);
            tblInfo.WidthPercentage = 100;
            tblInfo.SetWidths(new float[] { 1f, 1f });

            // Lấy dữ liệu từ các control trên màn hình
            AddCellNoBorder(tblInfo, $"Mã hóa đơn: {cboMaHD.SelectedValue}", textFont);
            AddCellNoBorder(tblInfo, $"Ngày lập: {dtpNgayLap.Value.ToString("dd/MM/yyyy")}", textFont);
            AddCellNoBorder(tblInfo, $"Khách hàng: {DangNhap.NguoiDungHienTai}", textFont);
            AddCellNoBorder(tblInfo, $"Hạn thanh toán: {dtpHanThanhToan.Value.ToString("dd/MM/yyyy")}", textFont);

            tblInfo.SpacingAfter = 20;
            pdfDoc.Add(tblInfo);

            // 6. Bảng chi tiết tiền (Table chính)
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 3f, 1.5f, 2f, 2.5f }); // Tỉ lệ chiều rộng cột

            // Header bảng
            AddCellHeader(table, "Khoản mục", headerFont);
            AddCellHeader(table, "Chỉ số/SL", headerFont);
            AddCellHeader(table, "Ghi chú", headerFont);
            AddCellHeader(table, "Thành tiền (VNĐ)", headerFont);

            // Dòng 1: Tiền Phòng
            AddCellRow(table, "Tiền thuê phòng", "1 tháng", "", txtTienPhong.Text, textFont);
            // Dòng 2: Tiền Điện
            AddCellRow(table, "Tiền Điện", $"{txtDienDaDung.Text}", "Theo đồng hồ", txtTienDien.Text, textFont);
            // Dòng 3: Tiền Nước
            AddCellRow(table, "Tiền Nước", $"{txtNuocDaDung.Text}", "Theo đồng hồ", txtTienNuoc.Text, textFont);
            // Dòng 4: Dịch vụ
            AddCellRow(table, "Dịch vụ khác", "1", txtGhiChu.Text, txtTienDichVu.Text, textFont);

            pdfDoc.Add(table);

            // 7. Tổng tiền
            Paragraph pTongTien = new Paragraph($"TỔNG CỘNG THANH TOÁN: {txtTongTien.Text} VNĐ", boldFont);
            pTongTien.Alignment = Element.ALIGN_RIGHT;
            pTongTien.SpacingBefore = 10;
            pTongTien.SpacingAfter = 30;
            pdfDoc.Add(pTongTien);

            // 8. Chữ ký (Footer)
            PdfPTable tblFooter = new PdfPTable(2);
            tblFooter.WidthPercentage = 100;

            PdfPCell cellFooter1 = new PdfPCell(new Phrase("Người lập phiếu", boldFont));
            cellFooter1.Border = 0;
            cellFooter1.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cellFooter2 = new PdfPCell(new Phrase("Người thuê phòng", boldFont));
            cellFooter2.Border = 0;
            cellFooter2.HorizontalAlignment = Element.ALIGN_CENTER;

            tblFooter.AddCell(cellFooter1);
            tblFooter.AddCell(cellFooter2);

            // Dòng ghi chú ký tên
            PdfPCell cellKyTen = new PdfPCell(new Phrase("(Ký, ghi rõ họ tên)", italicFont));
            cellKyTen.Border = 0;
            cellKyTen.HorizontalAlignment = Element.ALIGN_CENTER;
            cellKyTen.PaddingTop = 5;

            tblFooter.AddCell(cellKyTen);
            tblFooter.AddCell(cellKyTen);

            pdfDoc.Add(tblFooter);

            // Đóng tài liệu
            pdfDoc.Close();
            writer.Close();
        }

        // --- CÁC HÀM HỖ TRỢ ĐỊNH DẠNG TABLE ---

        // Thêm ô không viền (cho phần thông tin chung)
        private void AddCellNoBorder(PdfPTable table, string text, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.Border = 0;
            cell.Padding = 5;
            table.AddCell(cell);
        }

        // Thêm Header bảng (có màu nền)
        private void AddCellHeader(PdfPTable table, string text, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.Padding = 6;
            table.AddCell(cell);
        }

        // Thêm dòng dữ liệu vào bảng
        private void AddCellRow(PdfPTable table, string col1, string col2, string col3, string col4, iTextSharp.text.Font font)
        {
            table.AddCell(new PdfPCell(new Phrase(col1, font)) { Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase(col2, font)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
            table.AddCell(new PdfPCell(new Phrase(col3, font)) { Padding = 5 });
            PdfPCell cellTien = new PdfPCell(new Phrase(col4, font));
            cellTien.HorizontalAlignment = Element.ALIGN_RIGHT; // Căn phải số tiền
            cellTien.Padding = 5;
            table.AddCell(cellTien);
        }
    }
}


