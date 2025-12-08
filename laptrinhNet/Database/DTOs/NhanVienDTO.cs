using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs
{
    public class NhanVienDTO
    {
        public string MANV { get; set; }
        public string TENNHANVIEN { get; set; }
        public DateTime? NGAYSINH { get; set; }
        public string GIOITINH { get; set; }
        public string DIACHI { get; set; }
        public string SODT_NV { get; set; }
        public string SOCMND_NHANVIEN { get; set; }
        public string EMAIL { get; set; }
    }
}
