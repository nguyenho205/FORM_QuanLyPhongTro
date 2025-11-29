using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs
{
    public class PhongTroDTO
    {
        public string MAPHONG { get; set; }
        public string TENPHONG { get; set; }
        public string MALOAI { get; set; } // Giữ FK để liên kết (nếu cần)
        public string TRANGTHAI { get; set; }
        public int? SONGUOIHIENTAI { get; set; }
        public string GHICHU { get; set; }
    }
}