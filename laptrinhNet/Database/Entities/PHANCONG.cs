using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("PHANCONG")]
    public class PhanCong
    {
        [Column("MAPHANCONG"), Key]
        public string MaPhanCong { get; set; }

        [Column("MANV"), ForeignKey("NhanVienDaTa")]
        public string MaNV { get; set; }
        public virtual NhanVien NhanVienDaTa { get; set; }

        [Column("MACV"), ForeignKey("CongViecDaTa")]
        public string MaCV { get; set; }
        public virtual CongViec CongViecDaTa { get; set; }

        [Column("NGAYPHANCONG")]
        public DateTime? NgayPhanCong { get; set; }
    }
}
