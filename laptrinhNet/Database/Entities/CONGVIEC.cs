using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("CONGVIEC")]
    public class CongViec
    {
        [Column("MACV"), Key]
        public string MaCV { get; set; }

        [Column("TENCV")]
        public string TenCV { get; set; }

        [Column("MOTACONGVIEC")]
        public string MoTaCongViec { get; set; }
    }
}
