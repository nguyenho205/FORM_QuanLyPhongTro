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
        public string TENKH { get; set; } // FK
        public string TENPHONG { get; set; } // FK
    }
}
