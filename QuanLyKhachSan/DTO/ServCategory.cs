using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class ServCategory
    {
        private string ser_Category_ID;
        private string ser_Category_Name;
        public string Ser_Category_ID { get => ser_Category_ID; set => ser_Category_ID = value; }

        public string Ser_Category_Name { get => ser_Category_Name; set => ser_Category_Name = value; }
        
        public ServCategory(string services_category_Id, string category_Name)
        {
            this.Ser_Category_ID = services_category_Id;
            this.Ser_Category_Name = category_Name;
        }

        public ServCategory(DataRow row)
        {
            this.Ser_Category_ID = row["Services_Category_ID"].ToString();
            this.Ser_Category_Name = row["Category_Name"].ToString();
        }
        }
    }
