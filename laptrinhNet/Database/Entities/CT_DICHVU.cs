using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("CT_DICHVU")]
    public class CT_DichVu
    {


        [Column("MAHOPDONG", Order = 1), Key]
        public string MaHopDong { get; set; }

        [Column("MADV", Order = 2), Key]
        public string MaDV { get; set; }

        [Column("MACTDV")]
        public string MaCTDV { get; set; }

        [Column("NGAYBD")]
        public DateTime? NgayBD { get; set; }

        [Column("GHICHU")]
        public string GhiChu { get; set; }
    }
}
