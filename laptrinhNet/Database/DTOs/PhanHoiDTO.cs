using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs
{
    public class PhanHoiDTO
    {
        public string MaPH { get; set; }
        public string TenNguoiGui { get; set; } // Tên khách hàng
        public string SoPhong { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayGui { get; set; }
        public string TrangThai { get; set; }
        public string TenNhanVien { get; set; } // Tên nhân viên xử lý
        public string PhanHoi { get; set; }
    }
}

