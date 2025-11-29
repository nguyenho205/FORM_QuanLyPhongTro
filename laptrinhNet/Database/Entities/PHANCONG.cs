using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("PHANCONG")]
    public class PHANCONG
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MAPHANCONG { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MANV { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MACV { get; set; }
        public DateTime? NGAYPHANCONG { get; set; }

        [ForeignKey("MANV")]
        public virtual NHANVIEN NhanVien { get; set; }
        [ForeignKey("MACV")]
        public virtual CONGVIEC CongViec { get; set; }
    }
}
