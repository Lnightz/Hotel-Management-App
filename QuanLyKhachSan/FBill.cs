using DAL;
using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FBill : DevExpress.XtraEditors.XtraForm
    {
        private int id_bill;
        private string id_room;
        private float toTal;
        private float discount;
        private float deposit;
        private float totalservices;
        public FBill(int id_bill, string id_room )
        {
            this.Id_bill = id_bill;
            this.Id_room = id_room;
            InitializeComponent();
            LoadServicesUsed(id_bill);
            LoadBill();
        }

        public int Id_bill { get => id_bill; set => id_bill = value; }
        public string Id_room { get => id_room; set => id_room = value; }
        public float ToTal { get => toTal; set => toTal = value; }
        public float Discount { get => discount; set => discount = value; }
        public float Deposit { get => deposit; set => deposit = value; }
        public float Totalservices { get => totalservices; set => totalservices = value; }

        private void LoadServicesUsed(int id_bill)
        {

            gridControlServices.DataSource = BillDetailDAO.Instance.GetBillDetailsByBillID(id_bill);

            List<BillDetail> list = BillDetailDAO.Instance.GetBillDetailsByBillID(id_bill);

            foreach (BillDetail item in list)
            {
                Totalservices += item.Total;
            }

            textEditTotalServ.Text = Totalservices.ToString("c");
        }
        public void LoadBill()
        {
            string query = "SELECT c.Cus_name, r.Room_number, rt.Room_Prices ,rt.Room_Type_Name, b.Date_Chekin, b.Date_Checkout, B.Date_Created ,DATEDIFF(hh, b.Date_Chekin, b.Date_Checkout) AS Day_Rent, b.Deposit, b.Discount ,rt.Room_Prices * DATEDIFF(hh, b.Date_Chekin, b.Date_Checkout) AS Total FROM Bill b, Customer c, Room r, Room_Type rt WHERE b.Room_ID = r.Room_ID AND r.Room_Type_ID = rt.Room_Type_ID AND b.Customer_ID = c.Customer_ID AND b.Bill_ID =" + Id_bill;
            DataRow row = DataProvider.Instance.ExecuteQuery(query).Rows[0];
            List<BillDetail> list = BillDetailDAO.Instance.GetBillDetailsByBillID(Id_bill);
            textCusName.Text = row["Cus_Name"].ToString();
            textRoomNum.Text = row["Room_Number"].ToString();
            textRoomType.Text = row["Room_Type_Name"].ToString();
                float showroomprices = (float)Convert.ToDouble(row["Room_Prices"].ToString());
                Deposit = (float)Convert.ToDouble(row["Deposit"].ToString());
                float showtotalrent = (float)Convert.ToDouble(row["ToTal"].ToString());
                Discount = (float)Convert.ToDouble(row["Discount"].ToString());
            textRoomPrices.Text = string.Format("{0:c}", showroomprices);
            textDateCheckin.Text = row["Date_Chekin"].ToString();
            textDateCheckout.Text = row["Date_Checkout"].ToString();
            textDateCreated.Text = row["Date_created"].ToString();
            textDayRent.Text = row["Day_rent"].ToString();
            textTotalRent.Text = showtotalrent.ToString("c");
            textDeposit.Text = Deposit.ToString("c");
            textDiscount.Text = Discount.ToString("P");
            ToTal = showtotalrent * (1 - Discount) + Totalservices - Deposit;
            textTotal.Text = ToTal.ToString("c");
        }

        private int GetBillStattusById (int id_bill)
        {
            string query = "SELECT Bill_Status FROM dbo.Bill where Bill_ID = " + id_bill ;
            int result = (int)DataProvider.Instance.ExecuteScalarQuery(query);
            return result;
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            int test = GetBillStattusById(Id_bill);
            if (test == 0)
            {
                string message = "Bạn có muốn thanh toán cho phòng " + textRoomNum.Text + "?";
                if (MessageBox.Show(message, "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.Checkout(Id_bill, Id_room, Deposit, Discount, ToTal);

                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
    }
}
