using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Bill
    {
        private int iD;
        private DateTime? daycheckin;
        private DateTime? daycheckout;
        private DateTime? daycreated;
        private int status;
        private float discount;
        private float deposit;
        private float total;
        private int cusid;
        private string roomid;
        private string username;
        private string cusName;
        private int dayRent;
        private string roomTypeName;
        private float roomPrice;
        private string roomNumber;
        private float totalRent;


        public int ID { get => iD; set => iD = value; }
        public DateTime? Daycheckin { get => daycheckin; set => daycheckin = value; }
        public DateTime? Daycheckout { get => daycheckout; set => daycheckout = value; }
        public DateTime? Daycreated { get => daycreated; set => daycreated = value; }
        public int Status { get => status; set => status = value; }
        public float Discount { get => discount; set => discount = value; }
        public float Deposit { get => deposit; set => deposit = value; }
        public int Cusid { get => cusid; set => cusid = value; }
        public string Roomid { get => roomid; set => roomid = value; }
        public string Username { get => username; set => username = value; }
        public string CusName { get => cusName; set => cusName = value; }
        public int DayRent { get => dayRent; set => dayRent = value; }
        public string RoomTypeName { get => roomTypeName; set => roomTypeName = value; }
        public string RoomNumber { get => roomNumber; set => roomNumber = value; }
        public float TotalRent { get => totalRent; set => totalRent = value; }
        public float RoomPrice { get => roomPrice; set => roomPrice = value; }
        public float Total { get => total; set => total = value; }

        public Bill (int id, DateTime? daycheckin, DateTime? daycheckout, DateTime? daycreated, int cusid, float deposit, float total, int discount, int status, string roomid, string username)
        {
            this.ID = id;
            this.Daycheckin = daycheckin;
            this.Daycheckout = daycheckout;
            this.Daycreated = daycreated;
            this.Status = status;
            this.Roomid = roomid;
            this.Username = username;
            this.Total = total;
            this.Deposit = deposit;
            this.Cusid = cusid;
            this.Discount = discount;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["BiLL_ID"];
            this.Daycheckin = (DateTime?)row["Date_chekin"];
            var dateCheckout_Temp = row["date_checkout"];
            if (dateCheckout_Temp.ToString() != "")
                this.Daycheckout = (DateTime?)dateCheckout_Temp;
            this.Daycreated = (DateTime?)row["Date_created"];
            this.Status = (int)row["Bill_status"];
            this.Roomid = row["room_id"].ToString();
            this.Username = row["username"].ToString();
            this.Total = (float)Convert.ToDouble(row["total"].ToString());
            this.Deposit = (float)Convert.ToDouble(row["deposit"].ToString());
            this.Cusid = (int)row["Customer_ID"];
            this.Discount = (float)Convert.ToDouble(row["discount"].ToString());
            this.RoomNumber = row["Room_Number"].ToString();
        }
    }
}
