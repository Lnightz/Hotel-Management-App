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
    public class BookingDAO
    {
        private static BookingDAO instance;

        public static BookingDAO Instance
        {
            get { if (instance == null) instance = new BookingDAO(); return instance; }
            private set => instance = value;
        }

        private BookingDAO() { }

        public void InsertBooking(DateTime datecheckin, float deposit, string bookingtype, string username, int customerid, string roomid )
        {
            DataProvider.Instance.ExecuteNonQuery("EXECUTE dbo.USP_InsertBooking @datecheckin , @deposit , @bookingtype , @username , @customerid  , @roomid", new object[] { datecheckin, deposit, bookingtype, username,customerid,roomid });
        }

        public Customer GetCustomerByBookingId(int bookingID)
        {
            string query = "SELECT b.Customer_ID, c.Cus_name , c.Cus_Phone , c.Cus_CMND , c.Cus_Email FROM dbo.Booking b INNER JOIN dbo.Customer c ON b.Customer_ID = c.Customer_ID WHERE b.Booking_ID = " + bookingID;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Customer customer = new Customer(data.Rows[0]);
                return customer;
            }

            return null;
        }

        public int GetBookingIDByRoomID(string room_id)
        {
            string query = "SELECT * FROM dbo.Booking WHERE Booking_status_id = 0 AND Room_ID =N'"+room_id+"' ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Booking booking = new Booking(data.Rows[0]);
                return booking.BookingID ;
            }
            return -1;
        }

        public Booking GetBookingInfoByIdBooking (int bookingID)
        {
            string query = "Select * From Booking where Booking_ID = " + bookingID;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Booking booking = new Booking(data.Rows[0]);
                return booking;
            }
            return null;
        }

        public void CancelBooking (int bookingID, string roomID)
        {
            DataProvider.Instance.ExecuteNonQuery("EXECUTE dbo.USP_CancelBooking @booking_id , @room_id", new object[] { bookingID, roomID });
        }
    }
}
