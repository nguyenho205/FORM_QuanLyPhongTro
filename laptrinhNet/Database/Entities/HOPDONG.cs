using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("HOPDONG")]
    public class HOPDONG
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MAHOPDONG { get; set; }
        public DateTime? NGAYBD { get; set; }
        public DateTime? NGAYKT { get; set; }
        public decimal? TIENCOC { get; set; } // MONEY
        [Column(TypeName = "NVARCHAR(50)")]
        public string TRANGTHAI { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MAKH { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MAPHONG { get; set; }

        [ForeignKey("MAKH")]
        public virtual KHACHHANG KhachHang { get; set; }
        [ForeignKey("MAPHONG")]
        public virtual PHONGTRO PhongTro { get; set; }
        public virtual ICollection<CT_DICHVU> ChiTietDichVus { get; set; }
        public virtual ICollection<HOADON> HoaDons { get; set; }
    }
}
