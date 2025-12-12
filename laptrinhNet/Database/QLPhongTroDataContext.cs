using System.Data.Entity;
using System.Windows.Forms; 
using System.Drawing; 
using System.Drawing.Printing; 
using laptrinhNet.Database.Entities; 
namespace laptrinhNet.Database 
{
    public class QLPhongTroDataContext : DbContext
    {
        public QLPhongTroDataContext()

            : base("Data Source=DESKTOP-IQCO6JU\\SQLEXPRESS;Initial Catalog=QUANLY_PHONGTRO;Integrated Security=True")
// =======
//             : base("Data Source=WIN-LML4B3VMKIT;Initial Catalog=QUANLY_PHONGTRO;Integrated Security=True")
// >>>>>>> master

        {
        }

        public QLPhongTroDataContext(string connectionString) : base(connectionString)

        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        // 2. Khai báo danh sách các bảng (DbSet)
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<CongViec> CongViecs { get; set; }
        public DbSet<PhanCong> PhanCongs { get; set; }

        public DbSet<LoaiPhongTro> LoaiPhongTros { get; set; }
        public DbSet<PhongTro> PhongTros { get; set; }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }

        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<CT_DichVu> CT_DichVus { get; set; }

        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<CT_HoaDon> CT_HoaDons { get; set; }

        public DbSet<ThanNhan> ThanNhans { get; set; }
        public DbSet<YeuCauHoTro> YeuCauHoTros { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Ignore<System.Windows.Forms.Control>();
            modelBuilder.Ignore<System.Drawing.Image>();
            modelBuilder.Ignore<System.Windows.Forms.ImageList>();
            modelBuilder.Ignore<System.Windows.Forms.ToolStripItem>();
            modelBuilder.Ignore<System.Windows.Forms.ToolStripMenuItem>();
            modelBuilder.Ignore<System.Windows.Forms.ToolStrip>();
            modelBuilder.Ignore<System.Windows.Forms.Form>();
            modelBuilder.Ignore<System.Windows.Forms.ContextMenuStrip>();
            modelBuilder.Ignore<System.Windows.Forms.MenuStrip>();

            //khao kép
            modelBuilder.Entity<CT_HoaDon>()
                .HasKey(c => new { c.MaHD, c.MaDV });

            modelBuilder.Entity<CT_DichVu>()
                .HasKey(c => new { c.MaHopDong, c.MaDV });

            base.OnModelCreating(modelBuilder);
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // Cần đảm bảo rằng các lớp này đã được bỏ qua (Ignore)
        //    modelBuilder.Ignore<Control>(); // Lỗi cũ (tốt nhất là giữ lại)
        //    modelBuilder.Ignore<Image>();
        //    modelBuilder.Ignore<ImageList>(); // Lỗi cũ (tốt nhất là giữ lại)
        //    modelBuilder.Ignore<ToolStripItem>(); // Lỗi cũ (tốt nhất là giữ lại)

        //    // Các lỗi mới nhất:
        //    modelBuilder.Ignore<ToolStripMenuItem>();
        //    modelBuilder.Ignore<ToolStrip>();
        //    modelBuilder.Ignore<Form>();
        //    modelBuilder.Ignore<ContextMenuStrip>();
        //    modelBuilder.Ignore<MenuStrip>();

        //    // Nếu bạn gặp lại các lỗi cũ, hãy thêm lại:
        //    // modelBuilder.Ignore<PrintDocument>(); 
        //    // modelBuilder.Ignore<PageSettings>();
        //    // modelBuilder.Ignore<NumericUpDownAcceleration>();

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}