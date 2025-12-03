using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("YEUCAUHOTRO")]
    public class YeuCauHoTro
    {
        [Column("MAYEUCAU"), Key]
        public string MaYeuCau { get; set; }

        [Column("MAKH")]
        public string MaKH { get; set; }

        [Column("NGAYGUI")]
        public DateTime? NgayGui { get; set; }

        [Column("NOIDUNG")]
        public string NoiDung { get; set; }

        [Column("TRANGTHAI")]
        public string TrangThai { get; set; }

        [Column("MANV_XULY")]
        public string MaNV_XuLy { get; set; }

        [Column("NGAYXULY")]
        public DateTime? NgayXuLy { get; set; }

        [Column("PHANHOI")]
        public string PhanHoi { get; set; }
    }
}
