using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("TAIKHOAN")]
    public class TaiKhoan
    {
        [Column("MATK"), Key]
        public string MaTK { get; set; }

        [Column("TENDANGNHAP")]
        public string TenDangNhap { get; set; }

        [Column("MATKHAU")]
        public string MatKhau { get; set; }

        [Column("MALIENKET")]
        public string MaLienKet { get; set; }

        [Column("LOAITAIKHOAN")]
        public string LoaiTaiKhoan { get; set; }
    }
}
