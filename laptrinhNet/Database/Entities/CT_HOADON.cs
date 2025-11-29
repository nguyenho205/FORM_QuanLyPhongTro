using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("CT_HOADON")]
    public class CT_HOADON
    {
        [Column(TypeName = "CHAR(5)")]
        public string MAHD { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MADV { get; set; }
        public int? CHISO_CU { get; set; }
        public int? CHISO_MOI { get; set; }
        public int? SOLUONG { get; set; }
        [Required]
        public decimal DONGIA { get; set; } // MONEY, NOT NULL
        public decimal? THANHTIEN { get; set; } // MONEY
        [Column(TypeName = "NVARCHAR(100)")]
        public string GHICHU { get; set; }

        [ForeignKey("MAHD")]
        public virtual HOADON HoaDon { get; set; }
        [ForeignKey("MADV")]
        public virtual DICHVU DichVu { get; set; }
    }
}
