using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class RoomStatus
    {
        private string room_Stat_ID;

        private string room_stat_Name;

        public string Room_Stat_ID { get => room_Stat_ID; set => room_Stat_ID = value; }
        public string Room_stat_Name { get => room_stat_Name; set => room_stat_Name = value; }

        public RoomStatus (string room_stat_id, string room_stat_name)
        {
            this.Room_Stat_ID = room_stat_id;
            this.Room_stat_Name = room_stat_name;
        }
        public RoomStatus (DataRow row)
        {
            this.Room_Stat_ID = row["room_stat_id"].ToString();
            this.Room_stat_Name = row["room_stat_name"].ToString();
        }
    }
}
