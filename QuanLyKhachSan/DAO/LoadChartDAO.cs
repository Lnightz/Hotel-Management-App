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
    public class LoadChartDAO
    {

        private static LoadChartDAO instance;

        public static LoadChartDAO Instance
        {
            get { if (instance == null) instance = new LoadChartDAO(); return instance; }
            private set => instance = value;
        }

        private LoadChartDAO () { }

        public int CountCustomer ()
        {
            int result = (int)DataProvider.Instance.ExecuteScalarQuery("SELECT COUNT (*) FROM dbo.Customer");
            return result;
        }

        public int CountBooking(int month , int year)
        {
            string query = string.Format("SELECT COUNT (*) FROM Bill where Bill_status = 1 AND MONTH(Date_Checkout) = {0} AND YEAR(Date_Checkout) = {1}", month, year);
            int result = (int)DataProvider.Instance.ExecuteScalarQuery(query);
            return result;
        }

        public int CountCancelBooking(int month , int year)
        {
            string query = string.Format("SELECT COUNT (*) FROM dbo.Booking WHERE Booking_status_id = 2 AND MONTH(Date_Book) = {0} AND Year(Date_Book) = {1}", month, year);
            int result = (int)DataProvider.Instance.ExecuteScalarQuery(query);
            return result;
        }

        public double Total(int month, int year)
        {
            string query = string.Format("SELECT SUM (Total) AS ToTal_All FROM dbo.Bill where MONTH(Date_Checkout) = {0} AND Year(Date_Checkout) = {1}", month, year);
            double result = Convert.ToDouble(DataProvider.Instance.ExecuteScalarQuery(query));
            return result;
        }
    }
}
