using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("PHONGTRO")]
    public class PHONGTRO
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MAPHONG { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string TENPHONG { get; set; }
        [Column(TypeName = "CHAR(10)")]
        public string MALOAI { get; set; }
        [Column(TypeName = "NVARCHAR(20)")]
        public string TRANGTHAI { get; set; }
        public int? SONGUOIHIENTAI { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        public string GHICHU { get; set; }

        [ForeignKey("MALOAI")]
        public virtual LOAI_PHONGTRO LoaiPhongTro { get; set; }
        public virtual ICollection<HOPDONG> HopDongs { get; set; }
    }
}
