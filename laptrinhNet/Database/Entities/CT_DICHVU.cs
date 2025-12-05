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
        // ====== KHÓA CHÍNH KÉP ======
        [Key, Column("MAHOPDONG", Order = 1)]
        public string MaHopDong { get; set; }

        [Key, Column("MADV", Order = 2)]
        public string MaDV { get; set; }

        // ====== CỘT PHỤ (KHÔNG PHẢI KHÓA CHÍNH) ======
        [Column("MACTDV")]
        public string MaCTDV { get; set; }

        [Column("NGAYBD")]
        public DateTime? NgayBD { get; set; }

        [Column("GHICHU")]
        public string GhiChu { get; set; }
    }
}
