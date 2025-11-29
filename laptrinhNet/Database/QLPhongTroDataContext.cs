using laptrinhNet.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database
{
    public class QLPhongTroDataContext : DbContext
    {

        public QLPhongTroDataContext() : base("QUANLY_PHONGTRO_Connection")
        {
        }

        // Hoặc bạn có thể dùng cú pháp bạn đã cung cấp để truyền thẳng chuỗi kết nối:
        // public QLPhongTroDataContext() : base("Server=LAPTOP-1NE8K1LH\\SQLEXPRESS; Database=QUANLY_PHONGTRO; Integrated Security=true")
        // {
        // }


        // --- Khai báo DbSet cho tất cả các bảng ---
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<CONGVIEC> CONGVIEC { get; set; }
        public virtual DbSet<PHANCONG> PHANCONG { get; set; }
        public virtual DbSet<LOAI_PHONGTRO> LOAI_PHONGTRO { get; set; }
        public virtual DbSet<PHONGTRO> PHONGTRO { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANG { get; set; }
        public virtual DbSet<HOPDONG> HOPDONG { get; set; }
        public virtual DbSet<DICHVU> DICHVU { get; set; }
        public virtual DbSet<CT_DICHVU> CT_DICHVU { get; set; }
        public virtual DbSet<HOADON> HOADON { get; set; }
        public virtual DbSet<CT_HOADON> CT_HOADON { get; set; }
        public virtual DbSet<THANNHAN_THUETRO> THANNHAN_THUETRO { get; set; }
        public virtual DbSet<YEUCAUHOTRO> YEUCAUHOTRO { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Cấu hình Khóa Phức Hợp cho CT_DICHVU
            modelBuilder.Entity<CT_DICHVU>()
                .HasKey(cdv => new { cdv.MAHOPDONG, cdv.MADV });

            // Cấu hình Khóa Phức Hợp cho CT_HOADON
            modelBuilder.Entity<CT_HOADON>()
                .HasKey(cthd => new { cthd.MAHD, cthd.MADV });

            // Không cần cấu hình thêm cho các khóa ngoại đơn giản nếu bạn đã dùng [ForeignKey] trong Model.
            base.OnModelCreating(modelBuilder);
        }
    }
}