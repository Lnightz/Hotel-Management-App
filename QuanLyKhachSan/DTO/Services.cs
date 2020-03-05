using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Services
    {
        private string servID;
        private string servName;
        private float servPrices;
        private string unit;
        private string servCategoryID;
        private string categoryName;

        public Services(string id, string name, string unit, string categoryID, float prices, string categoryname)
        {
            this.ServID = id;
            this.ServName = name;
            this.Unit = unit;
            this.ServCategoryID = categoryID;
            this.ServPrices = prices;
            this.CategoryName = categoryName;
        }
        public Services (DataRow row)
        {
            this.ServID = row["Services_ID"].ToString();
            this.ServName = row["Services_Name"].ToString();
            this.Unit = row["unit"].ToString();
            this.ServCategoryID = row["Services_category_ID"].ToString();
            this.ServPrices = (float)Convert.ToDouble(row["Prices"].ToString());
            this.CategoryName = row["Category_Name"].ToString();
        }
        public string ServID { get => servID; set => servID = value; }
        public string ServName { get => servName; set => servName = value; }
        public float ServPrices { get => servPrices; set => servPrices = value; }
        public string Unit { get => unit; set => unit = value; }
        public string ServCategoryID { get => servCategoryID; set => servCategoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
    }
}
