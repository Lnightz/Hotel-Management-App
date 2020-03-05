using DAL;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return instance; }
            private set => instance = value;
        }

        private EmployeeDAO() { }

        public List<Employee> GetEmployeesList()
        {
            List<Employee> employees = new List<Employee>();

            string query = "Select * From Employee";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                employees.Add(employee);
            }
            return employees;
        } 

        public Employee GetEmployeeByName (string name)
        {
            string query = "Select * from Employee where Emp_Name =N'"+name+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new Employee(item);
            }
            return null;
        }

        public Employee GetEmployeeByID (int id)
        {
            string query = "Select * from Employee where Employee_ID =  "+id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                return new Employee(item);
            }
            return null;
        }

        public int IsExistEmp (string cmnnd)
        {
            int result = (int)DataProvider.Instance.ExecuteScalarQuery("Select count (*) from Employee where Emp_CMND = N'" + cmnnd + "'");
            return result;
        }

        public bool InsertEmployee(string name ,string phone , string mail, string birth, string adress,string cmnd)
        {
            string query = string.Format("INSERT dbo.Employee(Emp_Name,Emp_Phone,Emp_Email,Emp_BirthDay,Emp_Address,Emp_CMND) VALUES (N'{0}',N'{1}',N'{2}','{3}',N'{4}', N'{5}')",name,phone,mail,birth,adress,cmnd);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateEmployee(int id, string name, string phone, string mail, string birth, string adress, string cmnd)
        {
            string query = string.Format("Update dbo.Employee SET Emp_Name = N'{0}',Emp_Phone = N'{1}' ,  Emp_EMail = N'{2}', Emp_BirthDay = '{3}' ,Emp_Address = N'{4}' ,Emp_CMND = N'{5}' where Employee_ID = {6}", name,phone,mail,birth,adress,cmnd,id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteEmployee(int id)
        {
            string query = string.Format("DELETE Employee Where Employee_ID = {0} ",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
