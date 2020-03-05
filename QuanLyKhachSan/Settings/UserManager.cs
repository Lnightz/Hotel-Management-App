using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Settings
{
    public static class UserManager
    {
        private static Account account;

        public static Account Account
        {
            get { return account; }
            set { account = value; }
        }
    }
}
