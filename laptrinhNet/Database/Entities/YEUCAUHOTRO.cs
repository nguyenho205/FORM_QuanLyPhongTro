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
    public class YEUCAUHOTRO
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MAYEUCAU { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MAKH { get; set; }
        public DateTime? NGAYGUI { get; set; }
        [Column(TypeName = "NVARCHAR(200)")]
        public string NOIDUNG { get; set; }
        [Column(TypeName = "NVARCHAR(20)")]
        public string TRANGTHAI { get; set; }
        [Column(TypeName = "CHAR(5)")]
        public string MANV_XULY { get; set; }
        public DateTime? NGAYXULY { get; set; }
        [Column(TypeName = "NVARCHAR(200)")]
        public string PHANHOI { get; set; }

        [ForeignKey("MAKH")]
        public virtual KHACHHANG KhachHang { get; set; }
        [ForeignKey("MANV_XULY")]
        public virtual NHANVIEN NhanVienXuLy { get; set; }
    }
}
