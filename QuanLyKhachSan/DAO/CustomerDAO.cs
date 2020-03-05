using DAL;
using DevExpress.ClipboardSource.SpreadsheetML;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set => instance = value;
        }
        private CustomerDAO() { }

        public List<Customer> GetCustomerList ()
        {
            List<Customer> list = new List<Customer>();

            string query = "SELECT c.Cus_name, c.Cus_Phone, c.Cus_CMND, c.Cus_EMail, Customer_ID FROM dbo.Customer c";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Customer cus = new Customer(item);
                list.Add(cus);
            }

            return list;
        }

        public int GetCustomerIDbyUncheckBillID(int bill_id)
        {
            string query = "Select * From Customer c, Bill b where c.Customer_ID = b.Customer_ID and b.Bill_ID= "+bill_id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Customer customer = new Customer(data.Rows[0]);
                return customer.Cus_id;
            }

            return -1;
        }

        public Customer GetCustomerByName (string cus_name)
        {

            string query = "Select * from Customer where Cus_name = N'" +cus_name+"'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Customer(item);
            }

            return null;
        }

        public bool InsertCustomer (string cusname, string cusphone, string cuspassport, string cusemail)
        {
            string query = string.Format("INSERT dbo.Customer (Cus_name , Cus_Phone , Cus_CMND , Cus_Email) VALUES ( N'{0}' , N'{1}' , N'{2}' , N'{3}')",cusname,cusphone,cuspassport,cusemail);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int IsExistCustomer (string passport)
        {
            string query = string.Format("Select count (*) from Customer where cus_CMND = N'{0}'",passport);
            int result = (int)DataProvider.Instance.ExecuteScalarQuery(query);
            return result ;
        }

        public bool UpdateCustomer(string cusname, string cusphone, string cuspassport, string cusemail, int cusid)
        {
            string query = string.Format("UPDATE dbo.Customer SET Cus_name = N'{0}' , Cus_Phone = N'{1}' , Cus_CMND = N'{2}' , Cus_Email = N'{3}' WHERE Customer_ID = {4}", cusname, cusphone, cuspassport, cusemail, cusid ) ;
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteCustomer(int cusid)
        {
            string query = string.Format("DELETE dbo.Customer WHERE Customer_ID = {0}", cusid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public Customer GetCustomerByID (int cusid)
        {
            string query = "Select * from Customer where Customer_id =N'"+cusid+"' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Customer(item);
            }

            return null;
        }
    }
}
