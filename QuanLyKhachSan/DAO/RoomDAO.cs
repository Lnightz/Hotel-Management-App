using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace QuanLyKhachSan.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance;

        public static RoomDAO Instance
        { get { if (instance == null) instance = new RoomDAO(); return RoomDAO.instance; }
          private set => instance = value;
        }

        private RoomDAO () { }

        public List<Room> LoadRoomList()
        {
            List<Room> roomlist = new List<Room>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXECUTE dbo.USP_LoadRoomList");
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                roomlist.Add(room);
            }
            return roomlist;
        }
        public Room GetRoomDetailByRoomID(string room_id)
        {
            string query = " SELECT * FROM dbo.Room r, dbo.Room_Type rt, Room_status rs WHERE r.Room_ID = N'"+room_id+"' AND r.Room_Type_ID =rt.Room_Type_ID and r.Room_stat_ID = rs.Room_stat_id";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Room roomDetail = new Room(data.Rows[0]);
                return roomDetail;
            }

            return null;
        }
        
        public List<Room> GetRoomSwitched()
        {
            List<Room> freerooom = new List<Room>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXECUTE USP_LoadRoomSwitchedList");
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                freerooom.Add(room);
            }
            return freerooom;
        }

        public Room GetRoomByRoomNumber (string roomNumber)
        {

            string query = " SELECT * FROM Room r , dbo.Room_Type rt, dbo.Room_status rs WHERE r.Room_Type_ID = rt.Room_Type_ID AND r.Room_stat_ID = rs.Room_stat_ID AND r.Room_number = N'" + roomNumber + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Room(item);
            }

            return null;
        }

        public RoomType GetRoomPricesByTypeName (string roomTypeName)
        {
            string query = "SELECT * FROM dbo.Room_Type WHERE Room_Type_Name = N'"+roomTypeName+"'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new RoomType(item);
            }
            return null;
        }
        public RoomType GetRoomTypeByID (string roomtypeid)
        {
            string query = "select * From Room_Type where Room_Type_ID = N'"+roomtypeid+"' ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                return new RoomType(item);
            }
            return null;
        }
        public List<RoomStatus> GetRoomStatus()
        {
            List<RoomStatus> roomStatuses = new List<RoomStatus>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Room_status");
            foreach (DataRow item in data.Rows)
            {
                RoomStatus room = new RoomStatus(item);
                roomStatuses.Add(room);
            }
            return roomStatuses;

        }

        public List<RoomType> GetRoomType()
        {
            List<RoomType> roomTypes = new List<RoomType>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * FROM Room_Type");
            foreach (DataRow item in data.Rows)
            {
                RoomType roomType = new RoomType(item);
                roomTypes.Add(roomType);
            }
            return roomTypes;
        }

        public bool SwapRoom(string roomidnew, string roomidold, int idbill)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXECUTE USP_SwitchRoom @roomidold , @roomidnew , @billID", new object[] { roomidold, roomidnew, idbill });
            return result > 0;
        }

        public bool InsertRoom(string roomid, string roomnumber, string roomtypeid)
        {
            string query =string.Format("INSERT dbo.Room ( Room_ID ,  Room_number ,  Room_Type_ID , Room_stat_ID ,  Room_Notes) VALUES ( N'{0}' , N'{1}' , N'{2}' , N'00', NULL )", roomid, roomnumber,roomtypeid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateRoom(string roomid, string roomnumber, string roomtypeid, string roomstatid)
        {
            string query = string.Format("UPDATE dbo.Room SET Room_number = N'{0}', Room_Type_ID =N'{1}', Room_stat_id = N'{2}' WHERE Room_ID = N'{3}'", roomnumber, roomtypeid, roomstatid ,roomid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteRoom(string roomid)
        {
            string query = string.Format("DELETE dbo.Room WHERE Room_ID = N'{0}'",roomid );
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool InsertRoomType(string roomtypeid, string roomtypename, float prices, int numbermin , int numbermax )
        {
            string query = string.Format("INSERT dbo.Room_Type( Room_Type_ID , Room_Type_Name , Room_Prices , Number_min , Number_max ) VALUES  ( N'{0}' , N'{1}' , {2} , {3} , {4})", roomtypeid, roomtypename, prices, numbermin, numbermax);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public int IsExistRoomTypeByRoomTypeName(string typename)
        {
            string query = string.Format("Select Count (*) from Room_type where Room_Type_name = N'{0}'" , typename);
            int result = (int)DataProvider.Instance.ExecuteScalarQuery(query);
            return result;
        }

        public bool DeleteRoomType(string roomtypeid)
        {
            string query = string.Format("DELETE dbo.Room_Type WHERE Room_Type_ID = N'{0}'", roomtypeid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateRoomType(string roomtypeid, string typename, float prices, int min, int max)
        {
            string query = string.Format("UPDATE dbo.Room_Type SET Room_Type_Name = N'{0}' , Room_Prices = {1} , Number_min = {2} , Number_max = {3} where Room_Type_ID = N'{4}'", typename, prices, min, max, roomtypeid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int IsExistRoomStat(string statname)
        {
            string query = string.Format("Select count (*) from Room_status where Room_stat_name = N'{0}'",statname);
            int result = (int)DataProvider.Instance.ExecuteScalarQuery(query);
            return result;
        }

        public RoomStatus GetRoomStatusByID (string statid)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Room_status where Room_stat_ID = N'" + statid + "'");
            foreach (DataRow item in data.Rows)
            {
                return new RoomStatus(item);
            }
            return null;
        }

        public RoomStatus GetRoomStatusByName(string statName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Room_status where Room_stat_name = N'" + statName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new RoomStatus(item);
            }
            return null;
        }

        public bool InsertRoomStat(string statID, string statName)
        {
            string query = string.Format("INSERT dbo.Room_status (Room_stat_ID, Room_stat_name) VALUES ( N'{0}' , N'{1}')", statID, statName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteRoomStat(string statid)
        {
            string query = string.Format("DELETE dbo.Room_Status WHERE Room_stat_ID = N'{0}'", statid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateRoomStat(string statID, string statName)
        {
            string query = string.Format("UPDATE Room_status SET Room_stat_Name = N'{0}' where Room_stat_ID = N'{1}'", statName, statID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
