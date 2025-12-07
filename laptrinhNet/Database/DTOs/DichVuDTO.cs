using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database.DTOs
{
    public class DichVuDTO
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public decimal DonGia { get; set; }
        public string LoaiDV { get; set; }
        public string GhiChu { get; set; }
    }
}