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
    public partial class FRoomType : DevExpress.XtraEditors.XtraForm
    {
        BindingSource roomtypelist = new BindingSource();
        public FRoomType()
        {
            InitializeComponent();
            gridControlRoomTypeList.DataSource = roomtypelist;
            LoadRoomType();
            AddDataBinding();
            LoadCBRoomTypeName();
        }

        private void LoadRoomType()
        {
            List<RoomType> roomTypes = RoomDAO.Instance.GetRoomType();
            roomtypelist.DataSource = roomTypes;
        }
        private void AddDataBinding()
        {
            textRoomTypeID.DataBindings.Add(new Binding("Text", gridControlRoomTypeList.DataSource, "Room_Type_Id", true, DataSourceUpdateMode.Never));
            comboBoxRoomType.DataBindings.Add(new Binding("Text", gridControlRoomTypeList.DataSource, "Room_Type_Name", true, DataSourceUpdateMode.Never));
            textNumberMin.DataBindings.Add(new Binding("Text", gridControlRoomTypeList.DataSource, "Number_Min", true, DataSourceUpdateMode.Never));
            textNumberMax.DataBindings.Add(new Binding("Text", gridControlRoomTypeList.DataSource, "Number_Max", true, DataSourceUpdateMode.Never));
            textRoomPrices.DataBindings.Add(new Binding("Text", gridControlRoomTypeList.DataSource, "Room_Prices", true, DataSourceUpdateMode.Never));
        }
        private void LoadCBRoomTypeName()
        {
            List<RoomType> roomTypes = RoomDAO.Instance.GetRoomType();
            comboBoxRoomType.DataSource = roomTypes;
            comboBoxRoomType.DisplayMember = "Room_Type_Name";
        }
        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {

            if (textRoomTypeID.Text == "" || comboBoxRoomType.Text == "" || textRoomPrices.Text == "" || textNumberMin.Text == "" || textNumberMax.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết", "Thông báo");
            }
            else
            {
                string roomtypeid = textRoomTypeID.Text;
                string typename = comboBoxRoomType.Text;
                float prices = (float)Convert.ToDouble(textRoomPrices.Text);
                int min = Convert.ToInt32(textNumberMin.Text);
                int max = Convert.ToInt32(textNumberMax.Text);
                int isexistroomtype = RoomDAO.Instance.IsExistRoomTypeByRoomTypeName(typename);
                if (isexistroomtype != 1)
                {
                    if (MessageBox.Show("Bạn có muốn thêm loại " + typename + " không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            if (RoomDAO.Instance.InsertRoomType(roomtypeid, typename, prices, min, max))
                            {
                                MessageBox.Show("Thêm thành công", "Thông báo");
                                LoadRoomType();
                            }
                        }
                        catch { MessageBox.Show("Mã loại đã tồn tại", "Thông báo"); }
                    }
                }
                else MessageBox.Show("Loại phòng này đã tồn tại", "Thông báo");
            }
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            string roomtypeid = textRoomTypeID.Text;
            string typename = comboBoxRoomType.Text;
            if (MessageBox.Show("Bạn có muốn xoá " + typename + " không?", "Thông Báo!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (RoomDAO.Instance.DeleteRoomType(roomtypeid))
                    {
                        MessageBox.Show("Xoá loại " + typename + " thành công", "Thông báo");
                        LoadRoomType();
                    }
                }
                catch
                {
                    MessageBox.Show("Không xoá được "+typename+"", "Thông báo");
                }
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            if (textRoomTypeID.Text == "" || comboBoxRoomType.Text == "" || textRoomPrices.Text == "" || textNumberMin.Text == "" || textNumberMax.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết", "Thông báo");
            }
            else
            {
                string roomtypeid = textRoomTypeID.Text;
                string typename = comboBoxRoomType.Text;
                float prices = (float)Convert.ToDouble(textRoomPrices.Text);
                int min = Convert.ToInt32(textNumberMin.Text);
                int max = Convert.ToInt32(textNumberMax.Text);
                RoomType isexistroomtype = RoomDAO.Instance.GetRoomTypeByID(textRoomTypeID.Text);
                if (isexistroomtype == null)
                {
                    MessageBox.Show("Kiểu phòng này không tồn tại", "Thông báo");
                }
                else
                {
                    if (string.Compare(comboBoxRoomType.Text, isexistroomtype.Room_Type_Name) == 0)//không sửa tên loại phòng
                    {
                        if (MessageBox.Show("Bạn có muốn sửa thông tin loại phòng "+typename+" không?","Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            if (RoomDAO.Instance.UpdateRoomType(roomtypeid, typename , prices, min, max))
                            {
                                MessageBox.Show("Sửa thành công", "Thông báo");
                                LoadRoomType();
                            }
                        }
                    }
                    else //sửa tên loại phòng
                    {
                        int test = RoomDAO.Instance.IsExistRoomTypeByRoomTypeName(typename);
                        if (test == 1) // tên loại phòng trùng
                        {
                            MessageBox.Show("Tên kiểu phòng này đã tồn tại", "Thông báo");
                        }
                        else// không trùng
                        {
                            if (MessageBox.Show("Bạn có muốn sửa thông tin loại phòng " + typename + " không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                            {
                                if (RoomDAO.Instance.UpdateRoomType(roomtypeid, typename, prices, min, max))
                                {
                                    MessageBox.Show("Sửa thành công", "Thông báo");
                                    LoadRoomType();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
