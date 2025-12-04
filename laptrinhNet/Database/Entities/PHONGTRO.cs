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
    public class PhongTro
    {
        [Column("MAPHONG"), Key]
        public string MaPhong { get; set; }

        [Column("TENPHONG")]
        public string TenPhong { get; set; }

        [Column("MALOAI"), ForeignKey("LoaiPTDaTa")]
        public string MaLoai { get; set; }
        public virtual LoaiPhongTro LoaiPTDaTa { get; set; }

        [Column("TRANGTHAI")]
        public string TrangThai { get; set; }

        [Column("SONGUOIHIENTAI")]
        public int? SoNguoiHienTai { get; set; }

        [Column("GHICHU")]
        public string GhiChu { get; set; }
    }
}
