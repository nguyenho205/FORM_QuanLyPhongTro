using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("HOADON")]
    public class HOADON
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MAHD { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MAHOPDONG { get; set; }
        public DateTime? THANGNAM { get; set; }
        public DateTime? NGAYLAP { get; set; }
        public decimal? TONGTIEN { get; set; } // MONEY
        [Column(TypeName = "NVARCHAR(50)")]
        public string TRANGTHAITHANHTOAN { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string PHUONGTHUCTT { get; set; }
        public DateTime? NGAYTHANHTOAN { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        public string GHICHU { get; set; }

        [ForeignKey("MAHOPDONG")]
        public virtual HOPDONG HopDong { get; set; }
        public virtual ICollection<CT_HOADON> ChiTietHoaDons { get; set; }
    }
}
