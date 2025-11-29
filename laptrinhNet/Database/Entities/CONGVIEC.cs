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
    public class CONGVIEC
    {
        [Key]
        [Column(TypeName = "CHAR(5)")]
        public string MACV { get; set; }
        [Column(TypeName = "NVARCHAR(50)")]
        public string TENCV { get; set; }
        [Column(TypeName = "NVARCHAR(256)")]
        public string MOTACONGVIEC { get; set; }
        public virtual ICollection<PHANCONG> PhanCongs { get; set; }
    }
}
