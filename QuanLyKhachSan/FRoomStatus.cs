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
    public partial class FRoomStatus : DevExpress.XtraEditors.XtraForm
    {
        BindingSource roomstatlist = new BindingSource();
        public FRoomStatus()
        {
            InitializeComponent();
            gridControl1.DataSource = roomstatlist;
            LoadRoomStat();
            AddDataBiding();
        }

        private void LoadRoomStat()
        {
            List<RoomStatus> list = RoomDAO.Instance.GetRoomStatus();
            roomstatlist.DataSource = list;
        }
        private void AddDataBiding()
        {
            textStatID.DataBindings.Add(new Binding("Text", gridControl1.DataSource, "Room_Stat_ID", true, DataSourceUpdateMode.Never));
            textStatName.DataBindings.Add(new Binding("Text", gridControl1.DataSource, "Room_stat_Name", true, DataSourceUpdateMode.Never));
        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            string statID = textStatID.Text;
            string statName = textStatName.Text;
            if (textStatID.Text == "" || textStatName.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo");
            }
            else
            {
                int test = RoomDAO.Instance.IsExistRoomStat(statName);
                if (test != 1)
                {
                    if (MessageBox.Show("Bạn có muốn thêm trạng thái "+statName+" không?","Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            if (RoomDAO.Instance.InsertRoomStat(statID, statName))
                            {
                                MessageBox.Show("Thêm thành công", "Thông báo");
                                LoadRoomStat();
                            }
                        }
                        catch { MessageBox.Show("Mã trạng thái này đã tồn tại", "Thông báo"); }
                    }
                }
                else MessageBox.Show("Trạng thái này đã tồn tại", "Thông báo");
            }
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            string statID = textStatID.Text;
            string statName = textStatName.Text;
            if (MessageBox.Show("Bạn có muốn xoá trạng thái " + statName + " không?", "Thông Báo!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (RoomDAO.Instance.DeleteRoomStat(statID))
                    {
                        MessageBox.Show("Xoá " + statName + " thành công", "Thông báo");
                        LoadRoomStat();
                    }
                }
                catch
                {
                    MessageBox.Show("Không xoá được " + statName + "", "Thông báo");
                }
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            if (textStatID.Text == "" || textStatName.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo");
            }
            else
            {
                string statID = textStatID.Text;
                string statName = textStatName.Text;
                RoomStatus isexiststatus = RoomDAO.Instance.GetRoomStatusByID(statID);
                if (isexiststatus == null)
                {
                    MessageBox.Show("Trạng thái này không tồn tại", "Thông báo");
                }
                else
                {
                    if (string.Compare(statName, isexiststatus.Room_stat_Name) == 0)
                    {
                        if (MessageBox.Show("Bạn có muốn sửa thông tin loại phòng không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            if (RoomDAO.Instance.UpdateRoomStat(statID,statName))
                            {
                                MessageBox.Show("Sửa thành công", "Thông báo");
                                LoadRoomStat();
                            }
                        }
                    }
                    else
                    {
                        if (RoomDAO.Instance.IsExistRoomStat(statName) == 1)
                        {
                            MessageBox.Show("Tên trạng thái này đã tồn tại", "Thông báo");
                        }
                        else
                        {
                            if (MessageBox.Show("Bạn có muốn sửa thông tin loại phòng không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                            {
                                if (RoomDAO.Instance.UpdateRoomStat(statID, statName))
                                {
                                    MessageBox.Show("Sửa thành công", "Thông báo");
                                    LoadRoomStat();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
