using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("HOADON")]
    public class HoaDon
    {
        [Column("MAHD"), Key]
        public string MaHD { get; set; }

        [Column("MAHOPDONG")]
        public string MaHopDong { get; set; }

        [Column("THANGNAM")]
        public DateTime? ThangNam { get; set; }

        [Column("NGAYLAP")]
        public DateTime? NgayLap { get; set; }

        [Column("TONGTIEN")]
        public decimal? TongTien { get; set; }

        [Column("TRANGTHAITHANHTOAN")]
        public string TrangThaiThanhToan { get; set; }

        [Column("PHUONGTHUCTT")]
        public string PhuongThucTT { get; set; }

        [Column("NGAYTHANHTOAN")]
        public DateTime? NgayThanhToan { get; set; }

        [Column("GHICHU")]
        public string GhiChu { get; set; }
    }
}
