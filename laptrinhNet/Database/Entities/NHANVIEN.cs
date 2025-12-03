using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("NHANVIEN")]
    public class NhanVien
    {
        [Column("MANV"), Key]
        public string MaNV { get; set; }

        [Column("TENNHANVIEN")]
        public string TenNhanVien { get; set; }

        [Column("NGAYSINH")]
        public DateTime? NgaySinh { get; set; }

        [Column("GIOITINH")]
        public string GioiTinh { get; set; }

        [Column("DIACHI")]
        public string DiaChi { get; set; }

        [Column("SODT_NV")]
        public string SoDT_NV { get; set; }

        [Column("SOCMND_NHANVIEN")]
        public string SoCMND_NhanVien { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }
    }
}
