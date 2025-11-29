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
    public class NHANVIEN
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MANV { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string TENNHANVIEN { get; set; }
        public DateTime? NGAYSINH { get; set; }
        [Column(TypeName = "NVARCHAR(5)")]
        public string GIOITINH { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string DIACHI { get; set; }
        [Column(TypeName = "CHAR(10)")]
        public string SODT_NV { get; set; }
        [Column(TypeName = "CHAR(12)")]
        public string SOCMND_NHANVIEN { get; set; }
        [Column(TypeName = "CHAR(50)")]
        public string EMAIL { get; set; }
        public virtual ICollection<PHANCONG> PhanCongs { get; set; }
        public virtual ICollection<YEUCAUHOTRO> YeuCauHoTroes { get; set; }
    }
}
