using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Database
{
    public static class Session
    {
        // Lưu chuỗi kết nối chứa User/Pass của người vừa đăng nhập
        public static string ConnectionString { get; set; } = "";

        // Lưu Mã nhân viên (VD: NV01)
        public static string Username { get; set; } = "";
    }
}
