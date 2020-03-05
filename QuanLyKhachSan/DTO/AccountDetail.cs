using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class AccountDetail
    {
        private string userName;

        private string displayName;

        private string passWord;

        private string accountType;

        private string typeName;

        private int empID;

        private string empName;

        public string UserName { get => userName; set => userName = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string AccountType { get => accountType; set => accountType = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string TypeName { get => typeName; set => typeName = value; }
        public int EmpID { get => empID; set => empID = value; }
        public string EmpName { get => empName; set => empName = value; }

        public AccountDetail(string userName, string displayName, string accountType, string typename, int empid, string empname ,string passWord = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.AccountType = accountType;
            this.PassWord = passWord;
            this.TypeName = typename;
            this.EmpID = empid;
            this.EmpName = empname;
        }
        public AccountDetail(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["display_Name"].ToString();
            this.AccountType = row["account_Type_ID"].ToString();
            this.PassWord = row["password"].ToString();
            this.TypeName = row["account_type_name"].ToString();
            this.EmpID = (int)row["Employee_ID"];
            this.EmpName = row["Emp_Name"].ToString();
        }
    }
}
