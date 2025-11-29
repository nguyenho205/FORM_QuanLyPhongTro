using laptrinhNet.Database.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laptrinhNet.Login
{
    public static class SessionManager
    {
        public static TaiKhoanDTO CurrentUser { get; private set; }

        public static bool IsLoggedIn => CurrentUser != null;

        public static void SetCurrentUser(TaiKhoanDTO user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
