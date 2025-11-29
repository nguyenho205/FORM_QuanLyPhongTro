using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("THANNHAN_THUETRO")]
    public class THANNHAN_THUETRO
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MATN { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MAKH { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string TENTHANNHAN { get; set; }
        [Column(TypeName = "NVARCHAR(10)")]
        public string GIOITINH { get; set; }
        [Column(TypeName = "CHAR(12)")]
        public string SOCMND { get; set; }
        [Column(TypeName = "CHAR(10)")]
        public string SODT_TN { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string DIACHI { get; set; }

        [ForeignKey("MAKH")]
        public virtual KHACHHANG KhachHang { get; set; }
    }
}
