using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class AccountType
    {

        private string typeID;

        private string typeName;

        public string TypeName { get => typeName; set => typeName = value; }
        public string TypeID { get => typeID; set => typeID = value; }

        public AccountType (string typeid, string typename)
        {
            this.TypeID = typeid;
            this.TypeName = typename;
        }
        public AccountType (DataRow row)
        {
            this.TypeName = row["account_type_name"].ToString();
            this.TypeID = row["account_Type_ID"].ToString();
        }
    }
}
