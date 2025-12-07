using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("KHACHHANG")]
    public class KhachHang
    {
        [Column("MAKH"), Key]
        public string MaKH { get; set; }

        [Column("TENKH")]
        public string TenKH { get; set; }

        [Column("SOCMND")]
        public string SoCMND { get; set; }

        [Column("SODIENTHOAI")]
        public string SoDienThoai { get; set; }

        [Column("EMAIL_KHACHHANG")]
        public string EmailKhachHang { get; set; }

        [Column("DIACHITHUONGTRU")]
        public string DiaChiThuongTru { get; set; }

        [Column("MATKHAU")]
        public string MatKhau { get; set; }
    }
}
