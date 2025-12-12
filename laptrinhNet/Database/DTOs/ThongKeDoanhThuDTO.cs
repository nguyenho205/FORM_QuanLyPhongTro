using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs
{
    public class ThongKeDoanhThuDTO
    {
        public string MaHD { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal TongTien { get; set; }
        public string TenPH { get; set; }
        public string TenKH { get; set; }
        public decimal TienPhong { get; set; }
        public decimal TienNuoc { get; set; }

        public decimal TienDien { get; set; }
        public decimal TienDichVu { get; set; }

    }
}
