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
    public class BookingTypeDAO
    {
        private static BookingTypeDAO instance;

        public static BookingTypeDAO Instance
        {
            get { if (instance == null) instance = new BookingTypeDAO(); return instance; }
            private set => instance = value;
        }

        private BookingTypeDAO() { }

        public List<BookingType> GetBookingTypes()
        {
            List<BookingType> typeslist = new List<BookingType>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Booking_type");
            foreach (DataRow item in data.Rows)
            {
                BookingType type = new BookingType(item);
                typeslist.Add(type);
            }
            return typeslist;
        }

        public BookingType GetBookingTypeByName (string name)
        {
            string query = "SELECT * FROM dbo.Booking_type WHERE Booking_type_name = N'" + name +"' ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new BookingType(item);
            }

            return null;
        }
    }
}
