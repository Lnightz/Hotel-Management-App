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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FRoomInfo : DevExpress.XtraEditors.XtraForm
    {
        private string room_ID;

        public string Room_ID { get => room_ID; set => room_ID = value; }
        public Account LoginAccount;

        public FRoomInfo(string room_ID)
        {
            this.LoginAccount = UserManager.Account;

            this.Room_ID = room_ID;
            
            InitializeComponent();

            int id_booking = BookingDAO.Instance.GetBookingIDByRoomID(Room_ID) ;

            int id_bill = BillDAO.Instance.GetUncheckBillByRoomID(Room_ID);

            if (id_booking != -1)
            {
                LoadCusBookingIfo(id_booking);
                LoadInfoBook(id_booking);
                simpleButtonAddServices.Enabled = false;
                nmUpDwnDiscount.Enabled = false;

                simpleButtonCancelBooking.Visible = true;
            }

            if (id_bill != -1)
            {
                LoadBillInfo(id_bill);

                LoadServicesUsed(id_bill);

                LoadCusInfo(id_bill);

                simpleButtonAddServices.Enabled = true;

                simpleButtonCancelBooking.Visible = false;
            }
            if (id_bill == -1 && id_booking == -1)
            {
                simpleButtonAddServices.Enabled = false ;
                simpleButtonCancelBooking.Visible = false;
            }
            LoadRoomSwitch();

            LoadSearchCustomer();

            LoadSerCategory();

            LoadRoomInfo(Room_ID);
        }

        #region Method
        void LoadSerCategory()
        {
            List<ServCategory> categorylist = ServCategoryDAO.Instance.GetServCategoryList();

            comboBoxServCategory.DataSource = categorylist;

            comboBoxServCategory.DisplayMember = "Ser_Category_Name";
        }
        void LoadSerByCategoryID(string id)
        {
            List<Services> servlist = Services_DAO.Instance.GetServByCategoryID(id);

            comboBoxServ.DataSource = servlist;

            comboBoxServ.DisplayMember = "ServName";
        }
        private void LoadServicesUsed(int id_bill)
        {

            gridControlServices.DataSource = BillDetailDAO.Instance.GetBillDetailsByBillID(id_bill);

            List<BillDetail> list = BillDetailDAO.Instance.GetBillDetailsByBillID(id_bill);

            float totalservices = 0;

            foreach (BillDetail item in list)
            {
                totalservices += item.Total;
            }

            textEditTotalServ.Text = totalservices.ToString("c");
        }

        void LoadCusInfo (int id_bill)
        {
            Customer customer = BillDAO.Instance.GetCustomerByBillID(id_bill);

            textEditCusName.Text = customer.Cus_name;

            textEditCusPhone.Text = customer.Cus_phone;

            textEditCusPassport.Text = customer.Cus_cmnd;

            textEditCusMail.Text = customer.Cus_mail;
        }

        void LoadRoomInfo (string Room_ID)
        {
            Room roomDetail = RoomDAO.Instance.GetRoomDetailByRoomID(Room_ID);

            textEditRoomType.Text = roomDetail.Room_Type_Name;

            textEditRomNum.Text = roomDetail.Room_Number;

            textEditRoomPirces.Text = roomDetail.Room_Prices.ToString("c");           
        }
        void LoadBillInfo (int id_bill)
        {
            Bill bill = BillDAO.Instance.GetBillInforByBillID(id_bill);

            textEditDateCheckin.Text = bill.Daycheckin.ToString();

            textEditDeposit.Text = bill.Deposit.ToString("c");

            numericUpDowndiscount.Text = (bill.Discount*100).ToString();
        }

        private void LoadSearchCustomer ()
        {
            string query = "Select * from Customer";

            searchLookUpEditCus.Properties.DataSource = DataProvider.Instance.ExecuteQuery(query);

        }

        private void LoadCusBookingIfo(int id_booking)
        {
            Customer customer = BookingDAO.Instance.GetCustomerByBookingId(id_booking);
            textEditCusName.Text = customer.Cus_name;

            textEditCusPhone.Text = customer.Cus_phone;

            textEditCusPassport.Text = customer.Cus_cmnd;

            textEditCusMail.Text = customer.Cus_mail;

        }
        private void LoadInfoBook (int id_booking)
        {

            Booking booking = BookingDAO.Instance.GetBookingInfoByIdBooking(id_booking);

            textEditDateCheckin.Text = Convert.ToDateTime(booking.DateCheckin).ToString();

            textEditDeposit.Text = booking.Deposit.ToString();

        }
        private void LoadRoomSwitch()
        {
            List<Room> rooms = RoomDAO.Instance.GetRoomSwitched();
            searchLookUpRoomSwitched.Properties.DataSource = rooms;
            searchLookUpRoomSwitched.Properties.DisplayMember = "Room_Number";
        }
        
        #endregion


        #region Event

        private void simpleButtonPay_Click_1(object sender, EventArgs e)
        {
            int billID = BillDAO.Instance.GetUncheckBillByRoomID(Room_ID);

            if (billID != -1)
            {
                try
                {
                    string query = "Update Bill Set Date_Checkout = GETDATE () where Bill_ID =" + billID;
                    DataProvider.Instance.ExecuteNonQuery(query);
                    FBill f = new FBill(billID, Room_ID);
                    f.ShowDialog();
                    if (BillDAO.Instance.GetUncheckBillByRoomID(Room_ID) == -1)
                    {
                        this.Close();
                    }
                }
                catch (Exception) { }
            }
            
        }
        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void comboBoxServCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            ServCategory selected = cb.SelectedItem as ServCategory;
            id = selected.Ser_Category_ID;
            LoadSerByCategoryID(id);
        }

        private void simpleButtonAddServices_Click(object sender, EventArgs e)
        {
            int id_bill = BillDAO.Instance.GetUncheckBillByRoomID(Room_ID);
            string serv_id = (comboBoxServ.SelectedItem as Services).ServID;
            int quantity = (int)numericUpDownServQuantity.Value;

            BillDetailDAO.Instance.InsertBillInfo(id_bill, quantity, serv_id);

            LoadServicesUsed(id_bill);
        }

        private void simpleButtonAddCus_Click(object sender, EventArgs e)
        {
            FAddCustomer f = new FAddCustomer();
            f.ShowDialog();
            LoadSearchCustomer();
        }

        private void simpleButtonConfirm_Click(object sender, EventArgs e)
        {
            int id_bill = BillDAO.Instance.GetUncheckBillByRoomID(Room_ID);

            int bookingID = BookingDAO.Instance.GetBookingIDByRoomID(Room_ID);

            Customer customer = CustomerDAO.Instance.GetCustomerByName(textEditCusName.Text);

            if (id_bill == -1 && bookingID == -1)
            {
                if (textEditCusName.Text == "" || textEditCusPassport.Text == "" || textEditCusPhone.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ thông tin khách hàng", "Thông báo");
                }
                else if (MessageBox.Show("Bạn có muốn thuê phòng không?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        BillDAO.Instance.InsertBill(LoginAccount.UserName, customer.Cus_id, Room_ID);
                        this.Close();
                    }
                    catch { MessageBox.Show("Chưa có khách hàng này trong kho dữ liệu", "Thông Báo") ; }
                }
            }
            if (bookingID != -1)
            {
                Customer newcustomer = CustomerDAO.Instance.GetCustomerByName(textEditCusName.Text);
                if (MessageBox.Show("Bạn có muốn thuê phòng cho đơn đặt phòng này không? ", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.ChangeBookingtoBill(bookingID, Convert.ToDateTime(textEditDateCheckin.Text), (float)Convert.ToDouble(textEditDeposit.Text), LoginAccount.UserName, newcustomer.Cus_id, Room_ID);
                    this.Close();
                }
            }
            if (id_bill != -1)
            {
                Customer confirmcustomer = BillDAO.Instance.GetCustomerByBillID(id_bill);
                if (string.Compare(customer.Cus_cmnd, confirmcustomer.Cus_cmnd) == 0)
                {
                    this.Close();
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn thay đổi thông tin khách hàng không?","Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            if (BillDAO.Instance.UpdateCustomerOfBill(id_bill, customer.Cus_id))
                            {
                                MessageBox.Show("Thay đổi thông tin khách hàng thành công", "Thông báo");
                                LoadCusInfo(id_bill);
                            }
                        }
                        catch { MessageBox.Show("Thay đổi không thành công", "Thông báo"); }
                    }
                }
            }

        }
        private void textEditDeposit_Leave(object sender, EventArgs e)
        {
            int id_bill = BillDAO.Instance.GetUncheckBillByRoomID(Room_ID);

            int id_booking = BookingDAO.Instance.GetBookingIDByRoomID(Room_ID);

            if (id_bill != -1)
            {
                string textboxvalue = textEditDeposit.Text;
                double temp;
                double.TryParse(textboxvalue, out temp);
                double deposit = temp;
                DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.Bill SET Deposit ="+deposit+" WHERE Bill_ID = " + id_bill);
            }
            if( id_booking != -1)
            {
                string textboxvalue = textEditDeposit.Text;
                double temp;
                double.TryParse(textboxvalue, out temp);
                double deposit = temp;
                DataProvider.Instance.ExecuteNonQuery("UPDATE dbo.Booking SET Deposit = " + deposit + "  WHERE Booking_ID = " + id_booking);
            }
        }

        private void numericUpDowndiscount_Leave(object sender, EventArgs e)
        {
            int id_bill = BillDAO.Instance.GetUncheckBillByRoomID(Room_ID);

            if (id_bill == -1)
            {

            }
            else
            {
                CultureInfo culture = new CultureInfo("en-US");
                double discount = Convert.ToDouble(numericUpDowndiscount.Value) * 0.01;
                string query = "UPDATE dbo.Bill SET Discount = " + discount.ToString(culture) + " WHERE Bill_ID = " + id_bill;
                DataProvider.Instance.ExecuteNonQuery(query);
            }
        }

        private void searchLookUpEditCus_EditValueChanged(object sender, EventArgs e)
        {
            searchLookUpEditCus.Properties.DisplayMember = "Cus_name";
            Customer customer = CustomerDAO.Instance.GetCustomerByName(searchLookUpEditCus.Text);

            textEditCusName.Text = customer.Cus_name;
            textEditCusPassport.Text = customer.Cus_cmnd;
            textEditCusPhone.Text = customer.Cus_phone;
            textEditCusMail.Text = customer.Cus_mail;
        }

        private void simpleButtonCancelBooking_Click(object sender, EventArgs e)
        {
            int id_booking = BookingDAO.Instance.GetBookingIDByRoomID(Room_ID);
            if (MessageBox.Show("Bạn có muốn hủy đặt phòng không?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                BookingDAO.Instance.CancelBooking(id_booking , Room_ID);
                this.Close();
            }
        }

        private void simpleButtonChangeRoom_Click(object sender, EventArgs e)
        {
            int idbill = BillDAO.Instance.GetUncheckBillByRoomID(Room_ID);
            Room room = RoomDAO.Instance.GetRoomByRoomNumber(searchLookUpRoomSwitched.Text);
            if (RoomDAO.Instance.SwapRoom(room.Room_ID, Room_ID, idbill))
            {
                MessageBox.Show("Chuyển phòng thành công", "Thông báo");
                this.Close();
            }
        }

        #endregion


    }
}
