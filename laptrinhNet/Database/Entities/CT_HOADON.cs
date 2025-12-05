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
    public class CT_HoaDon
    {
        [Key, Column("MAHD", Order = 1)]
        public string MaHD { get; set; }

        [Key, Column("MADV", Order = 2)]
        public string MaDV { get; set; }

        [Column("CHISO_CU")]
        public int? ChiSoCu { get; set; }

        [Column("CHISO_MOI")]
        public int? ChiSoMoi { get; set; }

        [Column("SOLUONG")]
        public int? SoLuong { get; set; }

        [Column("DONGIA")]
        public decimal DonGia { get; set; }

        [Column("THANHTIEN")]
        public decimal? ThanhTien { get; set; }

        [Column("GHICHU")]
        public string GhiChu { get; set; }
    }
}
