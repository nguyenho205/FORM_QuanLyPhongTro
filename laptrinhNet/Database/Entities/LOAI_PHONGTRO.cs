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
    public class LoaiPhongTro
    {
        [Column("MALOAI"), Key]
        public string MaLoai { get; set; }

        [Column("TENLOAI")]
        public string TenLoai { get; set; }

        [Column("GIAPHONG")]
        public decimal? GiaPhong { get; set; }

        [Column("SONGUOITOIDA")]
        public int? SoNguoiToiDa { get; set; }

        [Column("TIENICH")]
        public string TienIch { get; set; }

        [Column("GHICHU")]
        public string GhiChu { get; set; }
    }
}
