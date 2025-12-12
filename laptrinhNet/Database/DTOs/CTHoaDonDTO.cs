using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs // Nhớ đổi namespace theo project của bạn
{
    public class CTHoaDonDTO
    {
        public string MaHD { get; set; }
        public string TenPhong { get; set; }
        public string TenKhach { get; set; }
        public DateTime NgayLap { get; set; }

        // Chỉ cần số lượng để hiển thị, tiền sẽ tính toán sau
        public int SoDien { get; set; }
        public int SoNuoc { get; set; }

        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
        public string PhuongThucTT { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayThanhToan { get; set; }
    }
}