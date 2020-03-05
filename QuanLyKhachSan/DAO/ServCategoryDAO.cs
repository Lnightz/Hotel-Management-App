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
    public class ServCategoryDAO
    {
        private static ServCategoryDAO instance;

        public static ServCategoryDAO Instance
        {
            get { if (instance == null) instance = new ServCategoryDAO(); return instance; }
            private set => instance = value; 
        }
        private ServCategoryDAO() { }
        public List<ServCategory> GetServCategoryList()
        {
            List<ServCategory> categorylist = new List<ServCategory>();

            string query = "SELECT * FROM dbo.Services_Category";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ServCategory category = new ServCategory(item);
                categorylist.Add(category);
            }
            return categorylist;
        }

        public int IsExistCategoryByName (string name)
        {
            int result = (int)DataProvider.Instance.ExecuteScalarQuery("Select Count (*) From dbo.Services_Category where Category_name = N'"+name+"' ");
            return result;
        }
        public bool InsertCategory(string categoryID, string categoryName)
        {
            string query = string.Format("INSERT dbo.Services_Category( Services_category_ID , Category_name ) VALUES  ( N'{0}' , N'{1}'  )",categoryID,categoryName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteCategory(string categoryID)
        {
            string query = string.Format("Delete dbo.Services_Category Where Services_category_ID = N'{0}'", categoryID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateCategory(string name , string id)
        {
            string query = string.Format("UPDATE dbo.Services_Category Set Category_name = N'{0}' where Services_category_ID = N'{1}'", name , id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public ServCategory GetCategoryById(string categoryid)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from dbo.Services_Category Where Services_category_ID = N'"+categoryid+"'");
            foreach (DataRow item in data.Rows)
            {
                return new ServCategory(item);
            }
            return null;
        }

        public ServCategory GetCategoryByName(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from dbo.Services_Category Where Category_Name = N'" + name + "'");
            foreach (DataRow item in data.Rows)
            {
                return new ServCategory(item);
            }
            return null;
        }
    }
}
