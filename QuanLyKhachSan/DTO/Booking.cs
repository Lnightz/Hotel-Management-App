using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Booking
    {
        private int bookingID;

        private DateTime? dateBook;

        private DateTime? dateCheckin;

        private DateTime? dateCheckout;

        private float deposit;

        private string bookingTypeID;

        private string userName;

        private int cusID;

        private int booking_Status_Id;

        private string roomID;
        public int BookingID { get => bookingID; set => bookingID = value; }
        public DateTime? DateBook { get => dateBook; set => dateBook = value; }
        public DateTime? DateCheckin { get => dateCheckin; set => dateCheckin = value; }
        public DateTime? DateCheckout { get => dateCheckout; set => dateCheckout = value; }
        public float Deposit { get => deposit; set => deposit = value; }
        public string BookingTypeID { get => bookingTypeID; set => bookingTypeID = value; }
        public string UserName { get => userName; set => userName = value; }
        public int CusID { get => cusID; set => cusID = value; }
        public string RoomID { get => roomID; set => roomID = value; }
        public int Booking_Status_Id { get => booking_Status_Id; set => booking_Status_Id = value; }

        public Booking(int booking_ID, DateTime? Date_book, DateTime? Date_checkin, DateTime? Date_Checkout, float Deposit, string booking_type_ID, string username, int customer_id, string room_id, int booking_status_id)
        {

            this.BookingID = booking_ID;
            this.DateBook = Date_book;
            this.DateCheckin = Date_checkin;
            this.DateCheckout = Date_Checkout;
            this.Deposit = Deposit;
            this.BookingTypeID = booking_type_ID;
            this.UserName = username;
            this.CusID = customer_id;
            this.RoomID = room_id;
            this.Booking_Status_Id = booking_status_id;
        }

        public Booking(DataRow row)
        {

            this.BookingID = (int)row["booking_ID"];
            this.DateBook = (DateTime?)row["Date_book"];
            this.DateCheckin = (DateTime?)row["Date_checkin"];
            var datecheckouttemp = row["Date_checkout"];
            if (datecheckouttemp.ToString() != "")
                this.DateCheckout = (DateTime?)datecheckouttemp;
            this.Deposit = (float)Convert.ToDouble(row["Deposit"].ToString());
            this.BookingTypeID = row["booking_type_ID"].ToString() ;
            this.UserName = row["username"].ToString();
            this.CusID = (int)row["customer_id"];
            this.RoomID = row["room_id"].ToString();
            this.Booking_Status_Id = (int)row["booking_status_id"];
        }
    }
}
