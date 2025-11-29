using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs
{
    public class HoaDonDTO
    {
        public string MAHD { get; set; }
        public string MAHOPDONG { get; set; } // FK
        public DateTime? THANGNAM { get; set; }
        public DateTime? NGAYLAP { get; set; }
        public decimal? TONGTIEN { get; set; }
        public string TRANGTHAITHANHTOAN { get; set; }
        public string PHUONGTHUCTT { get; set; }
        public DateTime? NGAYTHANHTOAN { get; set; }
        public string GHICHU { get; set; }
    }
}
