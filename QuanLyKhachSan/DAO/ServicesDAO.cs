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
    public class Services_DAO
    {
        private static Services_DAO instance;

        public static Services_DAO Instance
        {
            get { if (instance == null) instance = new Services_DAO(); return instance; }
            private set => instance = value; 
        }
        private Services_DAO() { }

        public List<Services> GetServByCategoryID (string id)
        {
            List<Services> servlist = new List<Services>();

            string query = "Select * from Services s INNER JOIN dbo.Services_Category sc ON s.Services_category_ID = sc.Services_category_ID where sc.Services_category_ID = N'" + id+"'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Services serv = new Services(item);
                servlist.Add(serv);
            }

            return servlist;
        }

        public Services GetServicesById (string servid)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Services s INNER JOIN dbo.Services_Category sc ON s.Services_category_ID = sc.Services_category_ID where s.Services_ID = N'" + servid + "'");
            if (data.Rows.Count > 0)
            {
                Services services  = new Services(data.Rows[0]);
                return services;
            }

            return null;
        }

        public List<Services> GetServicesList()
        {
            List<Services> services = new List<Services>();

            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Services s INNER JOIN dbo.Services_Category sc ON s.Services_category_ID = sc.Services_category_ID");
            foreach (DataRow item in data.Rows)
            {
                Services serv = new Services(item);
                services.Add(serv);
            }
            return services;
        }

        public int IsExistServbyName(string name)
        {
            int result =(int)DataProvider.Instance.ExecuteScalarQuery("Select Count (*) from Services Where Services_Name = N'" + name + "'");
            return result;
        }

        public bool InsertServ(string servid, string servname , float prices, string unit, string categoryid)
        {
            string query = string.Format("INSERT dbo.Services ( Services_ID , Services_name , Prices , Unit , Services_category_ID) VALUES  ( N'{0}' , N'{1}' , {2} , N'{3}' , N'{4}' )",servid,servname,prices,unit,categoryid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateServ(string servid, string servname, float prices, string unit ,string categoryid)
        {
            string query = string.Format("UPDATE dbo.Services SET Services_name = N'{0}' , Prices = {1} , Unit =N'{2}' , Services_category_ID = N'{3}' WHERE Services_ID = N'{4}'",servname,prices,unit,categoryid,servid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteServ(string servid)
        {
            string query = string.Format("DELETE dbo.Services WHERE Services_ID = N'{0}' ",servid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
