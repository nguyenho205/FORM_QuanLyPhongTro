using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("KHACHHANG")]
    public class KHACHHANG
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MAKH { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string TENKH { get; set; }
        [Column(TypeName = "CHAR(12)")]
        public string SOCMND { get; set; }
        [Column(TypeName = "CHAR(10)")]
        public string SODIENTHOAI { get; set; }
        [Column(TypeName = "CHAR(30)")]
        public string EMAIL_KHACHHANG { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        public string DIACHITHUONGTRU { get; set; }
        public virtual ICollection<HOPDONG> HopDongs { get; set; }
        public virtual ICollection<THANNHAN_THUETRO> ThanNhans { get; set; }
        public virtual ICollection<YEUCAUHOTRO> YeuCauHoTroes { get; set; }
    }
}
