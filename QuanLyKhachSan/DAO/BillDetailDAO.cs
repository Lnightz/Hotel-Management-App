using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace QuanLyKhachSan.DAO
{
    public class BillDetailDAO
    {
        private static BillDetailDAO instance;

        public static BillDetailDAO Instance
        {
            get { if (instance == null) instance = new BillDetailDAO(); return instance; }
            set => instance = value;
        }
        private BillDetailDAO () { }

        public List<BillDetail> GetBillDetailsByBillID(int id_bill)
        {
            List<BillDetail> list = new List<BillDetail>();
            string query = "SELECT s.Services_name , bd.Quantity_Services , s.Prices , bd.Quantity_Services * s.Prices AS Total FROM bill b, dbo.Bill_Detail bd , dbo.Services s WHERE b.Bill_ID ="+id_bill+" AND b.Bill_ID = bd.Bill_ID AND bd.Services_ID = s.Services_ID";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                BillDetail detail = new BillDetail(item);
                list.Add(detail);
            }
            return list; 
        }
        public void InsertBillInfo(int bill_id, int quantity, string services_id)
        {
            DataProvider.Instance.ExecuteNonQuery("EXECUTE dbo.USP_InsertBillInfo @bill_id , @quantity , @services_id", new object[] { bill_id, quantity, services_id });
        }

    }
}
