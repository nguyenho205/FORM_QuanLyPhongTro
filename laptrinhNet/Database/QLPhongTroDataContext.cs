using System.Data.Entity;
using System.Windows.Forms; // Cần thiết cho Control, Form, ToolStrip, ToolStripMenuItem
using System.Drawing; // Cần thiết cho Image
using System.Drawing.Printing; // Cần thiết nếu có các lớp liên quan đến in ấn
using laptrinhNet.Database.Entities; // <-- SỬA: Namespace chứa các lớp thực thể của bạn
namespace laptrinhNet.Database // <-- SỬA: Namespace của bạn
{
    public class QLPhongTroDataContext : DbContext
    {
        // 1. Constructor: Cấu hình chuỗi kết nối
        public QLPhongTroDataContext()
            : base("Data Source=LAPTOP-1NE8K1LH\\SQLEXPRESS;Initial Catalog=QUANLY_PHONGTRO;Integrated Security=True")
        {
        }

        // 2. Khai báo danh sách các bảng (DbSet)
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<PhanCong> PhanCongs { get; set; }

        public virtual DbSet<LoaiPhongTro> LoaiPhongTros { get; set; }
        public virtual DbSet<PhongTro> PhongTros { get; set; }

        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }

        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<CT_DichVu> CT_DichVus { get; set; }

        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<CT_HoaDon> CT_HoaDons { get; set; }

        public virtual DbSet<ThanNhan> ThanNhans { get; set; }
        public virtual DbSet<YeuCauHoTro> YeuCauHoTros { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Cần đảm bảo rằng các lớp này đã được bỏ qua (Ignore)
            modelBuilder.Ignore<Control>(); // Lỗi cũ (tốt nhất là giữ lại)
            modelBuilder.Ignore<Image>();
            modelBuilder.Ignore<ImageList>(); // Lỗi cũ (tốt nhất là giữ lại)
            modelBuilder.Ignore<ToolStripItem>(); // Lỗi cũ (tốt nhất là giữ lại)

            // Các lỗi mới nhất:
            modelBuilder.Ignore<ToolStripMenuItem>();
            modelBuilder.Ignore<ToolStrip>();
            modelBuilder.Ignore<Form>();
            modelBuilder.Ignore<ContextMenuStrip>();
            modelBuilder.Ignore<MenuStrip>();

            // Nếu bạn gặp lại các lỗi cũ, hãy thêm lại:
            // modelBuilder.Ignore<PrintDocument>(); 
            // modelBuilder.Ignore<PageSettings>();
            // modelBuilder.Ignore<NumericUpDownAcceleration>();

            base.OnModelCreating(modelBuilder);
        }
    }
}