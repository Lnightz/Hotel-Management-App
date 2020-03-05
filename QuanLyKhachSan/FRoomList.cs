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

    public partial class FRoomList : DevExpress.XtraEditors.XtraForm
    {
        BindingSource roomlist = new BindingSource();

        public FRoomList()
        {
            InitializeComponent();
            gridControl1.DataSource = roomlist;
            LoadRoomList();
            AddDataBinding();
            LoadRoomTypeList();
            LoadRoomStatus();
        }

        #region Method

        public void LoadRoomList()
        {
            List<Room> room = RoomDAO.Instance.LoadRoomList();
            roomlist.DataSource = room;
        }
        private void AddDataBinding()
        {
            textRoomID.DataBindings.Add(new Binding("Text", gridControl1.DataSource, "Room_ID", true, DataSourceUpdateMode.Never));
            textRoomNumber.DataBindings.Add(new Binding("Text", gridControl1.DataSource, "Room_Number", true, DataSourceUpdateMode.Never));
            comboBoxRoomType.DataBindings.Add(new Binding("Text", gridControl1.DataSource, "Room_Type_Name", true, DataSourceUpdateMode.Never));
            comboBoxRoomStat.DataBindings.Add(new Binding("Text", gridControl1.DataSource, "Room_stat_Name", true, DataSourceUpdateMode.Never));
        }
        private void LoadRoomTypeList()
        {
            List<Room> rooms = RoomDAO.Instance.LoadRoomList();
            comboBoxRoomType.DataSource = rooms;
            comboBoxRoomType.DisplayMember = "Room_Type_Name";
        }
        private void LoadRoomPricesbyTypeName(string name)
        {
            RoomType roomType = RoomDAO.Instance.GetRoomPricesByTypeName(name);
            textRoomPrices.Text = roomType.Room_Prices.ToString();

        }
        private void LoadRoomStatus()
        {
            List<RoomStatus> roomStatuses = RoomDAO.Instance.GetRoomStatus();
            comboBoxRoomStat.DataSource = roomStatuses;
            comboBoxRoomStat.DisplayMember = "Room_stat_name";
        }
        #endregion

        #region Event

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRoomType.DisplayMember = "Room_Type_Name";
            if (comboBoxRoomType.Text != "QuanLyKhachSan.DTO.Room")
            {
                LoadRoomPricesbyTypeName(comboBoxRoomType.Text);
            }

        }
        private void simpleButtonAddRoom_Click(object sender, EventArgs e)
        {
            string roomID = textRoomID.Text;
            string roomNumber = textRoomNumber.Text;
            Room existRoomID = RoomDAO.Instance.GetRoomDetailByRoomID(textRoomID.Text);
            Room existRoomNumber = RoomDAO.Instance.GetRoomByRoomNumber(textRoomNumber.Text);
            RoomType roomtype = RoomDAO.Instance.GetRoomPricesByTypeName(comboBoxRoomType.Text);
            if (existRoomID != null || existRoomNumber != null)
            {
                MessageBox.Show("Phòng này đã tồn tại", "Thông báo");
            }
            else
            {
                if (comboBoxRoomStat.Text != "Trống")
                {
                    MessageBox.Show("Phòng thêm vào phải có trạng thái trống", "Thông Báo");
                }
                else
                {
                    if (RoomDAO.Instance.InsertRoom(roomID, roomNumber, roomtype.Room_Type_Id))
                    {
                        MessageBox.Show("Thêm phòng thành công", "Thông Báo");
                        LoadRoomList();
                    }
                    else MessageBox.Show("Không thêm được phòng", "Thông Báo");
                }
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            string roomID = textRoomID.Text;
            string roomNumber = textRoomNumber.Text;
            Room existRoomID = RoomDAO.Instance.GetRoomDetailByRoomID(textRoomID.Text);
            Room existRoomNumber = RoomDAO.Instance.GetRoomByRoomNumber(textRoomNumber.Text);
            RoomType roomtype = RoomDAO.Instance.GetRoomPricesByTypeName(comboBoxRoomType.Text);
            RoomStatus status = RoomDAO.Instance.GetRoomStatusByName(comboBoxRoomStat.Text);
            if (existRoomID == null || existRoomNumber == null)
            {
                MessageBox.Show("Phòng này không tồn tại", "Thông báo");
            }
            else
            {
                if (existRoomID.Room_StatID == "02" || existRoomID.Room_StatID == "01")
                {
                    MessageBox.Show("Phòng đang sử dụng, không thể sửa thông tin", "Thông Báo");
                }
                else
                {
                    if (RoomDAO.Instance.UpdateRoom(roomID, roomNumber, roomtype.Room_Type_Id, status.Room_Stat_ID ))
                    {
                        MessageBox.Show("Sửa thành công", "Thông Báo");
                        LoadRoomList();
                    }
                    else MessageBox.Show("Sửa không thành công", "Thông Báo");
                }
            }
        }

        private void simpleButtonDeleteRoom_Click(object sender, EventArgs e)
        {
            string roomID = textRoomID.Text;
            Room existRoomID = RoomDAO.Instance.GetRoomDetailByRoomID(textRoomID.Text);
            if (existRoomID == null)
            {
                MessageBox.Show("Phòng này không tồn tại", "Thông báo");
            }
            else
            {
                if (comboBoxRoomStat.Text != "Trống")
                {
                    MessageBox.Show("Phòng đang sử dụng, không thể xóa", "Thông Báo");
                }
                else
                {
                    try
                    {
                        if (RoomDAO.Instance.DeleteRoom(roomID))
                        {
                            MessageBox.Show("Xóa thành công", "Thông Báo");
                            LoadRoomList();
                        }
                    }
                    catch { MessageBox.Show("Không xóa được phòng", "Thông Báo"); }
                }
            }
        }
        #endregion
    }
}
