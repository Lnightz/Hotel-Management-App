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
using DevExpress.XtraEditors;
using QuanLyKhachSan.Settings;
using DAL;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;

namespace QuanLyKhachSan
{
    public partial class FMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Account LoginAccount;

        public FMain()
        {
            
            InitializeComponent();

            this.LoginAccount = UserManager.Account;

            LoadRoom();

            barButtonDisplayName.Caption = LoginAccount.DisplayName;

            Permission(LoginAccount.AccountType);

        }

        #region Method

        void Permission(string account_type_ID)
        {
            ribbonPageGroup_List.Enabled = account_type_ID == "00";
            ribbonPageGroup_Hotel.Enabled = account_type_ID == "00";
            Tools_Report.Enabled = account_type_ID == "00";
        }

        private void LoadRoom()
        {
            flowLayoutPanel1.Controls.Clear();
            List<Room> roomlist = RoomDAO.Instance.LoadRoomList();
            foreach (Room item in roomlist)
            {
                Button btn = new Button();
                btn.Width = 100;
                btn.Height = 100;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                //btn.Appearance.Font = new Font("Tahoma", 10, FontStyle.Regular);
                btn.Font = new Font("Tahoma", 9, FontStyle.Regular);
                btn.Text = item.Room_Number + Environment.NewLine + item.Room_Type_Name;
                btn.TextImageRelation = TextImageRelation.ImageAboveText;
                //btn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
                btn.Click += Btn_Click;
                btn.Tag = item;

                switch (item.Room_StatID)
                {
                    case "00":
                        btn.BackColor = Color.FromArgb(187, 229, 254);
                        btn.Image = global::QuanLyKhachSan.Properties.Resources.bed;
                        break;
                    case "01":
                        btn.BackColor = Color.FromArgb(171, 112, 2);
                        btn.Image = global::QuanLyKhachSan.Properties.Resources.guest__house__hote;
                        break;
                    case "02":
                        btn.BackColor = Color.FromArgb(163, 4, 5);
                        btn.Image = global::QuanLyKhachSan.Properties.Resources.guest__house__hote;
                        break;
                    case "03":
                        btn.BackColor = Color.Purple;
                        btn.Image = global::QuanLyKhachSan.Properties.Resources.Fixed_icon;
                        btn.Enabled = false;
                        break;
                }
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        #endregion

        #region Event

        private void barButtonDashBoard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FDashBoard f = new FDashBoard();
            f.ShowDialog();
        }

        private void barButtonItem_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Infor_Infor_Group_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TeamInfor f = new TeamInfor();
            f.Show();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            string room_id = ((sender as Button).Tag as Room).Room_ID;
            FRoomInfo f = new FRoomInfo(room_id);
            f.ShowDialog();
            LoadRoom();
        }

        private void Mange_Booking_Room_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FBooking f = new FBooking();
            f.ShowDialog();
            LoadRoom();
        }

        private void barButtonItem1_ListCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FCustomerList f = new FCustomerList();
            f.ShowDialog();
        }
        private void barButtonItemListEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FEmployeeList f = new FEmployeeList();
            f.ShowDialog();
        }
        private void Manage_Room_List_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FRoomList f = new FRoomList();
            f.ShowDialog();
            LoadRoom();
        }

        private void barButtonItem1_Bill_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FBillList f = new FBillList();
            f.ShowDialog();
        }

        private void barButtonItem_ChangePass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FAccountInfo f = new FAccountInfo();
            f.UpdateDisplayName += f_UpdateDisplayName;
            f.ShowDialog();
            
        }
        private void f_UpdateDisplayName (object sender , AccountEvent e)
        {
            barButtonDisplayName.Caption = e.Acc.DisplayName;
        }

        private void Manage_Room_Type_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FRoomType f = new FRoomType();
            f.ShowDialog(); 
        }

        private void Manage_Room_Status_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FRoomStatus f = new FRoomStatus();
            f.ShowDialog();
        }

        private void Mange_Services_List_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FServicesList f = new FServicesList();
            f.ShowDialog();
        }

        private void barButtonItemListUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FAccountList f = new FAccountList();
            f.ShowDialog();
        }

        private void Manage_Services_Type_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FServicesCatogory f = new FServicesCatogory();
            f.ShowDialog();
        }

        private void barButtonItemReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FReport f = new FReport();
            f.ShowDialog();
        }
        #endregion


    }
}
