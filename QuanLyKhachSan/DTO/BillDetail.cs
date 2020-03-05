using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class BillDetail
    {
        private string services_name;
        private int quantity;
        private float prices;
        private float total;
        public BillDetail(string services_name, int quantity, float prices,float total)
        {
            this.Services_name = services_name;
            this.Quantity = quantity;
            this.Prices = prices;
            this.Total = total;
        }
        public BillDetail(DataRow row)
        {
            this.Services_name = row["services_name"].ToString();
            this.Quantity = (int)row["quantity_services"];
            this.Prices = (float)Convert.ToDouble(row["prices"].ToString());
            this.Total = (float)Convert.ToDouble(row["total"].ToString());
        }
        public string Services_name { get => services_name; set => services_name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Prices { get => prices; set => prices = value; }
        public float Total { get => total; set => total = value; }
    }
}
