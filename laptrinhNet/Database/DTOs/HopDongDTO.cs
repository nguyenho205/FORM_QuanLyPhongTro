using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs
{
    public class HopDongDTO
    {
        public string MAHOPDONG { get; set; }
        public DateTime? NGAYBD { get; set; }
        public DateTime? NGAYKT { get; set; }
        public decimal? TIENCOC { get; set; }
        public string TRANGTHAI { get; set; }
        public string MAKH { get; set; } // FK
        public string MAPHONG { get; set; } // FK
    }
}
