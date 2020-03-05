using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Customer
    {
        private int cus_id;
        private string cus_name;
        private string cus_phone;
        private string cus_cmnd;
        private string cus_mail;
        public string Cus_name { get => cus_name; set => cus_name = value; }
        public string Cus_phone { get => cus_phone; set => cus_phone = value; }
        public string Cus_cmnd { get => cus_cmnd; set => cus_cmnd = value; }
        public string Cus_mail { get => cus_mail; set => cus_mail = value; }
        public int Cus_id { get => cus_id; set => cus_id = value; }

        public Customer (DataRow row)
        {
            this.Cus_id = (int)row["Customer_ID"];
            this.Cus_name = row["Cus_name"].ToString();
            this.Cus_phone = row["Cus_Phone"].ToString();
            this.Cus_cmnd =  row["Cus_CMND"].ToString();
            this.Cus_mail = row["Cus_email"].ToString();
        }
    }
}
