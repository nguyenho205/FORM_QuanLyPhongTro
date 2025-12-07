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
    public class HopDong
    {
        [Column("MAHOPDONG"), Key]
        public string MaHopDong { get; set; }

        [Column("NGAYBD")]
        public DateTime? NgayBD { get; set; }

        [Column("NGAYKT")]
        public DateTime? NgayKT { get; set; }

        [Column("TIENCOC")]
        public decimal? TienCoc { get; set; }

        [Column("TRANGTHAI")]
        public string TrangThai { get; set; }

        [Column("MAKH"), ForeignKey("KhachHangData")]
        public string MaKH { get; set; }
        public virtual KhachHang KhachHangData { get; set; }

        [Column("MAPHONG"), ForeignKey("PhongTroData")]
        public string MaPhong { get; set; }
        public virtual PhongTro PhongTroData { get; set; }
    }
}
