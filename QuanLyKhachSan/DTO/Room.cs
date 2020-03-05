using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Room
    {
        private string room_ID;
        private string room_Number;
        private string room_Type_Name;
        private float room_Prices;
        private string room_Stat_Name;
        private int room_NumberMax;
        private int room_NumberMin;
        private string room_Notes;
        private string room_TypeID;
        private string room_StatID;

        public string Room_Number { get => room_Number; set => room_Number = value; }
        public string Room_Type_Name { get => room_Type_Name; set => room_Type_Name = value; }
        public float Room_Prices { get => room_Prices; set => room_Prices = value; }
        public string Room_ID { get => room_ID; set => room_ID = value; }
        public string Room_Stat_Name { get => room_Stat_Name; set => room_Stat_Name = value; }
        public int Room_NumberMax { get => room_NumberMax; set => room_NumberMax = value; }
        public int Room_NumberMin { get => room_NumberMin; set => room_NumberMin = value; }
        public string Room_Notes { get => room_Notes; set => room_Notes = value; }
        public string Room_TypeID { get => room_TypeID; set => room_TypeID = value; }
        public string Room_StatID { get => room_StatID; set => room_StatID = value; }


        public Room(string room_ID, string room_number, float room_prices, string room_type_name, string room_stat_name, int number_max, int number_min , string room_notes, string room_stat_id, string room_type_id)
        {
            this.Room_ID = room_ID;
            this.Room_Number = room_number;
            this.Room_Prices = room_prices;
            this.Room_Type_Name = room_type_name;
            this.Room_Stat_Name = room_stat_name;
            this.Room_NumberMax = number_max;
            this.Room_NumberMin = number_min;
            this.Room_Notes = room_notes;
            this.Room_TypeID = room_type_id;
            this.Room_StatID = room_stat_id;
        }
        public Room(DataRow row )
        {
            this.Room_ID = row["Room_ID"].ToString();
            this.Room_Number = row["Room_number"].ToString();
            this.Room_Prices = (float)Convert.ToDouble(row["Room_Prices"].ToString());
            this.Room_Type_Name = row["room_type_name"].ToString();
            this.Room_Stat_Name = row["room_stat_name"].ToString();
            this.Room_NumberMax = (int)row["number_max"];
            this.Room_NumberMin = (int)row["number_min"];
            this.Room_Notes = row["Room_notes"].ToString();
            this.Room_TypeID = row["Room_Type_ID"].ToString();
            this.Room_StatID = row["Room_stat_ID"].ToString();
        }
    }
}
