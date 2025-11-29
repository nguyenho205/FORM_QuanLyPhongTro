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
    public class TAIKHOAN
    {
        [Key]
        [Column(TypeName = "CHAR(15)")]
        public string MATK { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string TENDANGNHAP { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string MATKHAU { get; set; }
        public int? MALIENKET { get; set; }
    }
}
