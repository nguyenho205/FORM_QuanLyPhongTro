using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    // 12. BẢNG THÂN NHÂN THUÊ TRỌ
    [Table("THANNHAN_THUETRO")]
    public class ThanNhan
    {
        [Column("MATN"), Key]
        public string MaTN { get; set; }

        [Column("MAKH"), ForeignKey("KhachHangDaTa")]
        public string MaKH { get; set; }
        public virtual KhachHang KhachHangDaTa { get; set; }

        [Column("TENTHANNHAN")]
        public string TenThanNhan { get; set; }

        [Column("GIOITINH")]
        public string GioiTinh { get; set; }

        [Column("SOCMND")]
        public string SoCMND { get; set; }

        [Column("SODT_TN")]
        public string SoDT_TN { get; set; }

        [Column("DIACHI")]
        public string DiaChi { get; set; }
    }
}
