using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs
{    
    public class TaiKhoanDTO
    {
        public string MATK { get; set; }
        public string TENDANGNHAP { get; set; }
        // KHÔNG BAO GIỜ TRUYỀN MATKHAU HASH LÊN UI/CLIENT
        // public string MATKHAU { get; set; } 

        // Cột này để liên kết với thực thể người dùng
        public string MA_NGUOIDUNG { get; set; }
        public string LOAI_TAIKHOAN { get; set; } // Thêm để dễ phân biệt NV/KH
    }
   
}
