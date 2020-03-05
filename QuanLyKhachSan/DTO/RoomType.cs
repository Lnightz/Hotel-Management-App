using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class RoomType
    {
        private string room_Type_Id;

        private string room_Type_Name;

        private float room_Prices;

        private int number_Max;

        private int number_Min;

        public string Room_Type_Id { get => room_Type_Id; set => room_Type_Id = value; }
        public string Room_Type_Name { get => room_Type_Name; set => room_Type_Name = value; }
        public float Room_Prices { get => room_Prices; set => room_Prices = value; }
        public int Number_Max { get => number_Max; set => number_Max = value; }
        public int Number_Min { get => number_Min; set => number_Min = value; }

        public RoomType (string room_type_id, string room_Type_Name, float room_prices, int number_max, int number_min)
        {
            this.Room_Type_Id = room_type_id;
            this.Room_Type_Name = room_Type_Name;
            this.Room_Prices = room_prices;
            this.Number_Max = number_max;
            this.Number_Min = number_min;
        }
        public RoomType (DataRow row)
        {
            this.Room_Type_Id = row["room_type_id"].ToString();
            this.Room_Type_Name = row["room_Type_Name"].ToString();
            this.Room_Prices = (float)Convert.ToDouble(row["room_prices"]);
            this.Number_Max = (int)row["number_max"];
            this.Number_Min = (int)row["number_min"];
        }
    }
}
