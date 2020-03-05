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
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set => instance = value;
        }
        private BillDAO() { }

        public int GetUncheckBillByRoomID (string room_id)
        {
            string query = "SELECT * FROM Bill b, dbo.Room r WHERE b.Room_ID = r.Room_ID AND r.Room_id =N'"+room_id+"' AND b.Bill_Status = 0 ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public Customer GetCustomerByBillID (int bill_id)
        {
            string query = "SELECT b.Customer_ID, c.Cus_name , c.Cus_Phone , c.Cus_CMND , c.Cus_Email FROM dbo.Bill b INNER JOIN dbo.Customer c ON b.Customer_ID = c.Customer_ID WHERE b.Bill_ID =" + bill_id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Customer customer = new Customer(data.Rows[0]);
                return customer;
            }

            return null;
        }
        public Bill GetBillInforByBillID (int bill_id)
        {
            string query = "SELECT * FROM Bill b, Customer c, Room r, Room_Type rt WHERE b.Room_ID = r.Room_ID AND r.Room_Type_ID = rt.Room_Type_ID AND b.Customer_ID = c.Customer_ID AND b.Bill_ID =" + bill_id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill;
            }

            return null;
        }

        public void InsertBill(string username, int customer_id, string room_id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXECUTE USP_InsertBill @username , @customer_id , @room_id", new object[] {username, customer_id, room_id });
        }
        public void Checkout (int id_bill,string id_room, float deposit, float discount, float total)
        { 
            DataProvider.Instance.ExecuteNonQuery("EXECUTE USP_CheckOut @bill_id  , @room_id  , @deposit  , @discount  , @total", new object[] {id_bill, id_room , deposit, discount , total});
        }
        public void ChangeBookingtoBill(int booking_id, DateTime datecheckin, float deposit, string username, int customer_id, string room_id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXECUTE dbo.USP_ChangeBookingToBill @booking_id , @datecheckin , @deposit , @username , @customer_id , @room_id ", new object[] { booking_id, datecheckin, deposit, username, customer_id, room_id });
        }

        public List<Bill> GetListBill(DateTime fromdate, DateTime todate)
        {
            List <Bill> bills = new List<Bill>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXECUTE dbo.USP_LoadBillList @datefromdate , @datetodate",new object[] { fromdate, todate });
            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                bills.Add(bill);
            }
            return bills;
        }

        public bool UpdateCustomerOfBill (int billid, int cusid)
        {
            string query = string.Format("UPDATE dbo.Bill SET Customer_ID = {0} WHERE Bill_ID = {1}", cusid, billid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
