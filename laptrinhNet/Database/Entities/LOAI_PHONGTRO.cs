using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("LOAI_PHONGTRO")]
    public class LOAI_PHONGTRO
    {
        [Key]
        [Column(TypeName = "CHAR(10)")]
        public string MALOAI { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string TENLOAI { get; set; }
        public decimal? GIAPHONG { get; set; } // MONEY
        public int? SONGUOITOIDA { get; set; }
        [Column(TypeName = "NVARCHAR(200)")]
        public string TIENICH { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]
        public string GHICHU { get; set; }
        public virtual ICollection<PHONGTRO> PhongTroes { get; set; }
    }
}
