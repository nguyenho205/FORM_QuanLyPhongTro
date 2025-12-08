using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs
{
    public class KhachHangDTO
    {
        public string MAKH { get; set; }
        public string TENKH { get; set; }
        public string SOCMND { get; set; }
        public string SODIENTHOAI { get; set; }
        public string EMAIL_KHACHHANG { get; set; }
        public string DIACHITHUONGTRU { get; set; }
    }
}