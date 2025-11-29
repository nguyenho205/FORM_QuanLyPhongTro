using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("CT_DICHVU")]
    public class CT_DICHVU
    {
        
        [Column(TypeName = "CHAR(5)")]
        public string MACTDV { get; set; } 
        [Column(TypeName = "CHAR(5)")]
        public string MAHOPDONG { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MADV { get; set; }
        public DateTime? NGAYBD { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        public string GHICHU { get; set; }

        [ForeignKey("MAHOPDONG")]
        public virtual HOPDONG HopDong { get; set; }
        [ForeignKey("MADV")]
        public virtual DICHVU DichVu { get; set; }
    }
}
