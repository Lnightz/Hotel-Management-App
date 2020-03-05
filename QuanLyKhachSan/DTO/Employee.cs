using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Employee
    {
        private int empID;

        private string empName;

        private string empPhone;

        private string empMail;

        private string empAddress;

        private DateTime empBirth;

        private string empCMND;


        public int EmpID { get => empID; set => empID = value; }
        public string EmpName { get => empName; set => empName = value; }
        public string EmpPhone { get => empPhone; set => empPhone = value; }
        public string EmpMail { get => empMail; set => empMail = value; }
        public string EmpAddress { get => empAddress; set => empAddress = value; }
        public string EmpCMND { get => empCMND; set => empCMND = value; }
        public DateTime EmpBirth { get => empBirth; set => empBirth = value; }

        public Employee(DataRow row)
        {
            this.EmpID = (int)row["Employee_ID"];
            this.EmpName = row["Emp_Name"].ToString() ;
            this.EmpPhone = row["Emp_Phone"].ToString();
            this.EmpMail = row["Emp_Email"].ToString();
            this.EmpAddress = row["Emp_Address"].ToString();
            this.EmpBirth = (DateTime)row["Emp_BirthDay"];
            this.EmpCMND = row["Emp_CMND"].ToString();
        }
    }
}
