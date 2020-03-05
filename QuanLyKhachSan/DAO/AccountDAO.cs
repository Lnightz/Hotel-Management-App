using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }
        public bool Login (string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });
            return result.Rows.Count > 0 ;
        }

        public Account GetAccountByUserName(string userName)
        {
            string query = "Select * from Account Where UserName = N'"+userName+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in  data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool UpdateAccount (string username, string displayname, string pass, string newpass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Execute USP_UpdateAccount @userName , @displayName  , @passWord  , @newPassWord", new object[] {username , displayname , pass , newpass });
            return result > 0;
        }

        public List<AccountDetail> GetAccountDetailsList()
        {
            List<AccountDetail> accounts = new List<AccountDetail>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Account a, dbo.Account_Type at , Employee e WHERE a.Account_type_ID = at.Account_type_ID AND a.Employee_ID = e.Employee_ID");

            foreach (DataRow item in data.Rows)
            {
                AccountDetail detail = new AccountDetail(item);
                accounts.Add(detail);
            }
            return accounts;
        }

        public List<AccountType> GetAccountTypesList()
        {
            List<AccountType> acctype = new List<AccountType>();

            DataTable data = DataProvider.Instance.ExecuteQuery("Select * From Account_Type");

            foreach (DataRow item in data.Rows)
            {
                AccountType type = new AccountType(item);
                acctype.Add(type);
            }
            return acctype;
        }

        public AccountType GetAccountTypeIdByName (string name)
        {
            string query = "Select * from Account_type Where Account_Type_Name = N'" + name + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new AccountType(item);
            }
            return null;
        }

        public bool InsertAccount (string username, string displayname, string typeid, int empid)
        {
            string query = string.Format("INSERT dbo.Account( UserName , Display_name , Account_type_ID, Employee_ID ) VALUES  ( N'{0}', N'{1}' , N'{2}',{3})",username,displayname,typeid,empid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(string username, string displayname, string typeid, int empid)
        {
            string query = string.Format("Update Account Set display_name = N'{0}' , Account_type_ID = N'{1}', Employee_ID = {3} where UserName = N'{2}'", displayname,typeid,username,empid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string username)
        {
            string query = string.Format("DELETE Account where Username = N'{0}'",username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ResetPassAccount(string username)
        {
            string query = string.Format("Update Account Set password = 1 where UserName = N'{0}'", username);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
