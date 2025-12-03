using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.Entities
{
    [Table("DICHVU")]
    public class DichVu
    {
        [Column("MADV"), Key]
        public string MaDV { get; set; }

        [Column("TENDV")]
        public string TenDV { get; set; }

        [Column("DONGIA")]
        public decimal? DonGia { get; set; }

        [Column("LOAIDICHVU")]
        public string LoaiDichVu { get; set; }

        [Column("GHICHU")]
        public string GhiChu { get; set; }
    }
}
