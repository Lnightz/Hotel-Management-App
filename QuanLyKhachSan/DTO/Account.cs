using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Account
    {
        private string userName;

        private string displayName;

        private string passWord;

        private string accountType;

        private int empID;

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string AccountType { get => accountType; set => accountType = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public int EmpID { get => empID; set => empID = value; }

        public Account (string userName, string displayName, string accountType, int empid ,string passWord = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.AccountType = accountType;
            this.PassWord = passWord;
            this.EmpID = empid;
        }
        public Account (DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["display_Name"].ToString();
            this.AccountType = row["account_Type_ID"].ToString();
            this.PassWord = row["password"].ToString();
            this.EmpID = (int)row["Employee_ID"];
        }
    }
}
