using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class BookingType
    {
        private string booking_Type_ID;

        private string booking_Type_Name;

        public string Booking_Type_ID { get => booking_Type_ID; set => booking_Type_ID = value; }
        public string Booking_Type_Name { get => booking_Type_Name; set => booking_Type_Name = value; }

        public BookingType(string booking_type_id, string booking_type_name)
        {
            this.Booking_Type_ID = booking_type_id;
            this.Booking_Type_Name = booking_type_name;
        }
        public BookingType(DataRow row)
        {
            this.Booking_Type_ID = row["booking_type_id"].ToString();
            this.Booking_Type_Name = row["booking_type_name"].ToString();
        }
    }
}
