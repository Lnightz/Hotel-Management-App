using DAL;
using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FBooking : DevExpress.XtraEditors.XtraForm
    {
        public Account LoginAccount;

        public FBooking()
        {
            this.LoginAccount = UserManager.Account;
            InitializeComponent();
            LoadSearchCustomer();
            LoadRoomList();
            LoadBookingType();
            AddRoomBiding();
        }

        #region Method

        private void LoadRoomList()
        {

            string query = "SELECT * FROM dbo.Room r INNER JOIN dbo.Room_Type rt ON r.Room_Type_ID = rt.Room_Type_ID where r.Room_stat_Id = N'00'";

            gridControlRoomList.DataSource = DataProvider.Instance.ExecuteQuery(query);


            //Load DateCreatedBill
            dateBook.Text = DateTime.Now.ToString();
        }

        private void LoadSearchCustomer()
        {
            string query = "Select * from Customer";
            
            searchLookUpCus.Properties.DataSource = DataProvider.Instance.ExecuteQuery(query);

            searchLookUpCus.Properties.DisplayMember = "Họ Tên";

        }
        private void LoadBookingType()
        {
            List<BookingType> bookingTypes = BookingTypeDAO.Instance.GetBookingTypes();
            comboBoxPickBookingType.DataSource = bookingTypes;
            comboBoxPickBookingType.DisplayMember = "booking_Type_Name";
        }
        void AddRoomBiding()
        {
            textBoxPickedRoom.DataBindings.Add(new Binding("Text", gridControlRoomList.DataSource, "Room_Number"));
        }
        #endregion


        #region Event
        private void simpleButtonAddCus_Click(object sender, EventArgs e)
        {
            FAddCustomer f = new FAddCustomer();
            f.ShowDialog();
            LoadSearchCustomer();
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void searchLookUpCus_EditValueChanged(object sender, EventArgs e)
        {

            searchLookUpCus.Properties.DisplayMember = "Cus_name";

            Customer customer = CustomerDAO.Instance.GetCustomerByName(searchLookUpCus.Text);

            textCusName.Text = customer.Cus_name;
            textCusPhone.Text = customer.Cus_phone;
            textCusPassport.Text = customer.Cus_cmnd;
            textCusMail.Text = customer.Cus_mail;

        }
        private void comboBoxPickBookingType_Leave(object sender, EventArgs e)
        {
            comboBoxPickBookingType.DisplayMember = "booking_Type_Name";

            string s1 = "Không đảm bảo";
            int test = 0;
            if (test == string.Compare(comboBoxPickBookingType.Text,s1))
            {
                textDeposit.ReadOnly = true;
            }
            else textDeposit.ReadOnly = false;
        }

        private void simpleButtonConfirm_Click(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("en-US");

            Customer customer = CustomerDAO.Instance.GetCustomerByName(textCusName.Text);

            BookingType bookingType = BookingTypeDAO.Instance.GetBookingTypeByName(comboBoxPickBookingType.Text);

            Room room = RoomDAO.Instance.GetRoomByRoomNumber(textBoxPickedRoom.Text);
           
            if (searchLookUpCus.Text == "" && dateCheckin.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đầy đủ thông để đặt phòng", "Thông báo");
            }
            else if (MessageBox.Show("Bạn có muốn đặt phòng không?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {

                BookingDAO.Instance.InsertBooking(Convert.ToDateTime(dateCheckin.EditValue), (float)Convert.ToDouble(textDeposit.Text), bookingType.Booking_Type_ID , LoginAccount.UserName , customer.Cus_id, room.Room_ID);

                this.Close();
            }

        }

        #endregion


    }
}
