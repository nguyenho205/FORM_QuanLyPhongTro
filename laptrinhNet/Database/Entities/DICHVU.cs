using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("DICHVU")]
    public class DICHVU
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MADV { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string TENDV { get; set; }
        public decimal? DONGIA { get; set; } // MONEY
        [Column(TypeName = "NVARCHAR(20)")]
        public string LOAIDICHVU { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        public string GHICHU { get; set; }
        public virtual ICollection<CT_DICHVU> ChiTietDichVus { get; set; }
        public virtual ICollection<CT_HOADON> ChiTietHoaDons { get; set; }
    }
}
