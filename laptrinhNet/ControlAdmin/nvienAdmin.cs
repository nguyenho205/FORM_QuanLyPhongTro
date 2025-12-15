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
    public partial class nvienAdmin : UserControl
    {
        public nvienAdmin()
        {
            InitializeComponent();
        }
        // Hàm này trả về chuỗi Mã NV mới
        private string TaoMaNhanVienTuDong()
        {
            using (var db = new QLPhongTroDataContext())
            {
                // 1. Lấy mã nhân viên cuối cùng trong bảng (Sắp xếp giảm dần để lấy cái lớn nhất)
                var lastNV = db.NhanViens.OrderByDescending(nv => nv.MaNV).FirstOrDefault();

                if (lastNV == null)
                {
                    return "NV01"; // Nếu bảng chưa có ai thì bắt đầu từ NV01
                }

                // 2. Tách số ra khỏi chuỗi (Ví dụ "NV20" -> lấy số 20)
                string lastMa = lastNV.MaNV;
                string phanSo = lastMa.Substring(2); // Cắt bỏ chữ "NV" đi
                int soHienTai = 0;

                if (int.TryParse(phanSo, out soHienTai))
                {
                    // 3. Tăng lên 1 và ghép lại
                    int soMoi = soHienTai + 1;

                    // Format để số luôn đẹp (nếu muốn NV01, NV02... thì dùng "D2", còn NV1, NV20 thì dùng ToString thường)
                    return "NV" + soMoi.ToString();
                }

                return "NVError"; // Xử lý lỗi nếu format sai
            }
        }

        private void nvienAdmin_Load(object sender, EventArgs e)
        {       
            GiaoDien.ApplyTheme(this); // Áp dụng giao diện đẹp
            // 1. Cấu hình ComboBox Giới tính (Chỉ có Nam/Nữ)
            cbo_GioiTinh.Items.Clear();
            cbo_GioiTinh.Items.Add("Nam");
            cbo_GioiTinh.Items.Add("Nữ");
            cbo_GioiTinh.SelectedIndex = 0; // Mặc định chọn Nam

            // 2. Load dữ liệu lên Grid
            LoadDataNV();

            // 3. Xử lý Mã nhân viên tự động
            txt_MaNV.Text = TaoMaNhanVienTuDong();
            txt_MaNV.Enabled = false; // KHÓA LẠI không cho nhập tay

            ///LOAD CỦA PHÂN CÔNG
            using (var db = new QLPhongTroDataContext())
            {
                // 1. Load ComboBox Nhân viên
                cbo_TenNV.DataSource = db.NhanViens.ToList();
                cbo_TenNV.DisplayMember = "TENNHANVIEN"; 
                cbo_TenNV.ValueMember = "MaNV";    

                // 2. Load ComboBox Công việc
                cbo_TenCV.DataSource = db.CongViecs.ToList();
                cbo_TenCV.DisplayMember = "TENCV"; 
                cbo_TenCV.ValueMember = "MaCV";    
            }

            // 3. Load Grid và sinh mã
            LoadDataPhanCong();
            txt_MaPC.Text = TaoMaPhanCongTuDong();
            txt_MaPC.Enabled = false; // Khóa không cho sửa mã
        }
        private void LoadDataPhanCong()
        {
            using (var db = new QLPhongTroDataContext())
            {
                // Kỹ thuật Join bảng qua Khóa ngoại (Navigation Properties)
                var list = db.PhanCongs.Select(pc => new PhanCongDTO
                {
                    MAPC = pc.MaPhanCong,

                    // Lấy tên thông qua khóa ngoại
                    // (Lưu ý: Nếu db chưa map quan hệ thì phải dùng lệnh join, 
                    // nhưng thường LINQ to SQL tự có pc.NhanVien)
                    TENNHANVIEN = pc.NhanVienDaTa.TenNhanVien,
                    TENCONGVIEC = pc.CongViecDaTa.TenCV,

                    NGAYPHANCONG = pc.NgayPhanCong ?? DateTime.Now
                }).ToList();

                dataGridView1.DataSource = list;
            }
        }
        private void LoadDataNV()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var list = db.NhanViens.Select(nv => new NhanVienDTO
                {
                    MANV = nv.MaNV,
                    TENNHANVIEN = nv.TenNhanVien,
                    NGAYSINH = nv.NgaySinh,
                    GIOITINH = nv.GioiTinh,
                    DIACHI = nv.DiaChi,
                    SODT_NV = nv.SoDT_NV,
                    SOCMND_NHANVIEN = nv.SoCMND_NhanVien,
                    EMAIL = nv.Email
                }).ToList();

                gridNhanVien.DataSource = list;
            }
        }
        private void ResetForm()
        {
            txt_TenNV.Text = "";
            txt_DiaChi.Text = "";
            txt_SoDT.Text = "";
            txt_CCCD.Text = "";
            txt_Email.Text = "";
            cbo_GioiTinh.SelectedIndex = 0;
            dtPick_NhanVien.Value = DateTime.Now;

            // Quan trọng: Sinh mã mới cho lần thêm tiếp theo
            txt_MaNV.Text = TaoMaNhanVienTuDong();
            txt_MaNV.Enabled = false; // Luôn khóa không cho nhập tay
        }
        private void btn_ThemNV_Click(object sender, EventArgs e)
        {
            using (var db = new QLPhongTroDataContext())
            {
                // Kiểm tra xem mã này đã tồn tại chưa (đề phòng trường hợp mở form lâu quá người khác đã thêm rồi)
                if (db.NhanViens.Any(x => x.MaNV == txt_MaNV.Text))
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại, hệ thống sẽ cập nhật mã mới.");
                    txt_MaNV.Text = TaoMaNhanVienTuDong(); // Load lại mã mới nhất
                }

                NhanVien nv = new NhanVien();
                nv.MaNV = txt_MaNV.Text; // Lấy mã từ textbox (đã tự động sinh)
                nv.TenNhanVien = txt_TenNV.Text;
                nv.NgaySinh = dtPick_NhanVien.Value;
                nv.GioiTinh = cbo_GioiTinh.Text; // Lấy text "Nam" hoặc "Nữ"
                nv.DiaChi = txt_DiaChi.Text;
                nv.SoDT_NV = txt_SoDT.Text;
                nv.SoCMND_NhanVien = txt_CCCD.Text;
                nv.Email = txt_Email.Text;

                db.NhanViens.Add(nv);
                db.SaveChanges();

                MessageBox.Show("Thêm nhân viên thành công!");
                LoadDataNV();

                // Reset lại form để thêm người tiếp theo
                ResetForm();
            }
        }

        private void btn_SuaNV_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dòng nào đang được chọn trên Grid không
            if (gridNhanVien.CurrentRow == null || gridNhanVien.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng click chọn nhân viên cần sửa trên bảng!", "Thông báo");
                return;
            }

            // 2. Lấy Mã NV trực tiếp từ dòng đang chọn trên Grid (Chắc ăn nhất)
            string maNVCanSua = gridNhanVien.CurrentRow.Cells["MANV"].Value.ToString();

            using (var db = new QLPhongTroDataContext())
            {
                // 3. Tìm nhân viên trong DB dựa vào mã vừa lấy
                var nv = db.NhanViens.FirstOrDefault(x => x.MaNV == maNVCanSua);

                if (nv == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên này trong CSDL!");
                    return;
                }

                // 4. Cập nhật thông tin MỚI từ các ô nhập liệu (Trừ MaNV giữ nguyên)
                nv.TenNhanVien = txt_TenNV.Text;
                nv.GioiTinh = cbo_GioiTinh.Text;
                nv.NgaySinh = dtPick_NhanVien.Value;
                nv.DiaChi = txt_DiaChi.Text;
                nv.SoDT_NV = txt_SoDT.Text;
                nv.SoCMND_NhanVien = txt_CCCD.Text;
                nv.Email = txt_Email.Text;

                // 5. Lưu xuống DB
                db.SaveChanges();

                MessageBox.Show($"Đã cập nhật thông tin cho nhân viên {maNVCanSua}!");

                // 6. Load lại lưới và Reset form để sẵn sàng thêm mới
                LoadDataNV();
                ResetForm();
            }
        }

        private void btn_XoaNV_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra chọn dòng
            if (gridNhanVien.CurrentRow == null || gridNhanVien.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
                return;
            }

            // 2. Lấy Mã NV từ Grid
            string maNVCanXoa = gridNhanVien.CurrentRow.Cells["MANV"].Value.ToString();

            // 3. Hỏi xác nhận
            if (MessageBox.Show($"Bạn có chắc muốn xóa nhân viên {maNVCanXoa} không?",
                                "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (var db = new QLPhongTroDataContext())
                {
                    var nv = db.NhanViens.FirstOrDefault(x => x.MaNV == maNVCanXoa);

                    if (nv != null)
                    {
                        db.NhanViens.Remove(nv);
                        db.SaveChanges();

                        MessageBox.Show("Đã xóa thành công!");
                        LoadDataNV();
                        ResetForm(); // Quay về chế độ thêm mới (NV21...)
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không tìm thấy nhân viên trong CSDL.");
                    }
                }
            }
        }
 
        //cÁC CHỨC NĂNG CỦA PHÂN CÔNG
        private string TaoMaPhanCongTuDong()
        {
            using (var db = new QLPhongTroDataContext())
            {
                var lastPC = db.PhanCongs.OrderByDescending(x => x.MaPhanCong).FirstOrDefault();
                if (lastPC == null) return "PC01";

                string lastMa = lastPC.MaPhanCong; // Ví dụ: PC05
                string phanSo = lastMa.Substring(2); // Lấy "05"

                if (int.TryParse(phanSo, out int so))
                {
                    int soMoi = so + 1;
                    return "PC" + soMoi.ToString("D2"); // Trả về PC06
                }
                return "PCError";
            }
        }
        private void btn_xoapc_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem có dòng nào đang được chọn không
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng click chọn dòng phân công cần xóa trên bảng!", "Thông báo");
                return;
            }

            // 2. Lấy Mã Phân Công từ dòng đang chọn trên Grid
            // Lưu ý: Tên cột "MaPhanCong" phải trùng với tên thuộc tính trong Class DTO hoặc tên cột DB
            string maPCCanXoa = dataGridView1.CurrentRow.Cells["MAPC"].Value.ToString();

            // 3. Hỏi xác nhận trước khi xóa (Rất quan trọng để tránh xóa nhầm)
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phân công mã {maPCCanXoa} không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (var db = new QLPhongTroDataContext())
                {
                    // 4. Tìm đối tượng cần xóa trong CSDL
                    var pc = db.PhanCongs.FirstOrDefault(x => x.MaPhanCong == maPCCanXoa);

                    if (pc != null)
                    {
                        // Thực hiện xóa
                        db.PhanCongs.Remove(pc);
                        db.SaveChanges();

                        MessageBox.Show("Đã xóa phân công thành công!");

                        // 5. Cập nhật lại giao diện
                        LoadDataPhanCong(); // Load lại Grid

                        // Reset lại form về trạng thái thêm mới (Sinh mã PC tiếp theo)
                        txt_MaPC.Text = TaoMaPhanCongTuDong();

                         cbo_TenNV.SelectedIndex = -1;
                        cbo_TenCV.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: Không tìm thấy dữ liệu.");
                        LoadDataPhanCong(); // Load lại để đồng bộ dữ liệu
                    }
                }
            }
        }
        

        private void btn_PhanCong_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (cbo_TenNV.SelectedValue == null || cbo_TenCV.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Nhân viên và Công việc!");
                return;
            }

            using (var db = new QLPhongTroDataContext())
            {
                // Kiểm tra trùng mã (cho chắc chắn)
                if (db.PhanCongs.Any(x => x.MaPhanCong == txt_MaPC.Text))
                {
                    txt_MaPC.Text = TaoMaPhanCongTuDong(); // Sinh lại nếu trùng
                }

                PhanCong pc = new PhanCong();

                // 1. Mã tự tăng
                pc.MaPhanCong = txt_MaPC.Text;

                // 2. Lấy ValueMember (Mã) từ ComboBox
                pc.MaNV = cbo_TenNV.SelectedValue.ToString();
                pc.MaCV = cbo_TenCV.SelectedValue.ToString();

                // 3. Lấy thời gian hiện tại
                pc.NgayPhanCong = DateTime.Now;
                // Lưu vào DB
                db.PhanCongs.Add(pc); // Hoặc db.PhanCongs.Add(pc) nếu dùng EF
                db.SaveChanges();

                MessageBox.Show("Phân công thành công!");
                LoadDataPhanCong();

                // Reset để thêm tiếp
                txt_MaPC.Text = TaoMaPhanCongTuDong();
            }
        }

        private void grid_PhanCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];

                txt_MaPC.Text = row.Cells["MAPC"].Value.ToString();

                // DataGridView đang hiện Tên (VD: "Nguyễn Văn A")
                // ComboBox cũng đang hiện Tên -> Gán Text là khớp
                cbo_TenNV.Text = row.Cells["TENNHANVIEN"].Value.ToString();
                cbo_TenCV.Text = row.Cells["TENCONGVIEC"].Value.ToString();
            }
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            // 1. Reset text fields for Employee (Nhan Vien)
            txt_TenNV.Text = "";
            txt_DiaChi.Text = "";
            txt_SoDT.Text = "";
            txt_CCCD.Text = "";
            txt_Email.Text = "";

            // Reset DatePicker to current date
            dtPick_NhanVien.Value = DateTime.Now;

            // Reset Employee Gender ComboBox
            if (cbo_GioiTinh.Items.Count > 0)
                cbo_GioiTinh.SelectedIndex = 0; // Default to first item (e.g., "Nam")

            // 2. Reset fields for Assignment (Phan Cong)
            cbo_TenNV.SelectedIndex = -1; // Deselect Employee
            cbo_TenCV.SelectedIndex = -1; // Deselect Job

            // 3. Reload Data Grids to show latest data from DB
            LoadDataNV();
            LoadDataPhanCong();

            // 4. GENERATE NEW AUTO-INCREMENT IDs
            // This ensures the ID fields show the next available ID (e.g., NV06, PC06)
            // instead of the ID of a row the user might have just clicked.
            txt_MaNV.Text = TaoMaNhanVienTuDong();
            txt_MaPC.Text = TaoMaPhanCongTuDong();

            // 5. Ensure ID fields remain read-only (optional safety measure)
            txt_MaNV.Enabled = false;
            txt_MaPC.Enabled = false;
        }

        private void gridNhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridNhanVien.Rows[e.RowIndex];

                // 1. Đổ Mã NV lên ô textbox (Dù bị khóa nhưng code vẫn gán giá trị được!)
                // Đây là bước quan trọng để nút Sửa biết đang sửa ai
                txt_MaNV.Text = row.Cells["MaNV"].Value?.ToString();

                // 2. Đổ các thông tin còn lại cho người dùng sửa
                txt_TenNV.Text = row.Cells["TENNHANVIEN"].Value?.ToString();
                txt_DiaChi.Text = row.Cells["DIACHI"].Value?.ToString();
                txt_SoDT.Text = row.Cells["SODT_NV"].Value?.ToString();
                txt_CCCD.Text = row.Cells["SOCMND_NHANVIEN"].Value?.ToString();
                txt_Email.Text = row.Cells["EMAIL"].Value?.ToString();

                // Xử lý ComboBox và DatePicker
                cbo_GioiTinh.Text = row.Cells["GIOITINH"].Value?.ToString();
                if (row.Cells["NGAYSINH"].Value != null)
                {
                    dtPick_NhanVien.Value = Convert.ToDateTime(row.Cells["NGAYSINH"].Value);
                }
            }
        }
    }
}
