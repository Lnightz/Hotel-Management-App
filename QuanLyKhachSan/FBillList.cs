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
    public partial class FBillList : DevExpress.XtraEditors.XtraForm
    {
        public FBillList()
        {
            InitializeComponent();
            LoadDateTime();
            LoadlistBill(Convert.ToDateTime(dateFromDate.Text), Convert.ToDateTime(dateToDate.Text));
        }

        public void LoadDateTime()
        {
            DateTime today = DateTime.Now;
            dateFromDate.Text = new DateTime(today.Year, today.Month,1).ToString();
            dateToDate.Text = Convert.ToDateTime(dateFromDate.Text).AddMonths(1).AddDays(-1).ToString();
        }
        public void LoadlistBill(DateTime fromdate, DateTime todate)
        {
            List<Bill> listbill = BillDAO.Instance.GetListBill(fromdate, todate);
            gridControl1.DataSource = listbill;
        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonCheckBill_Click(object sender, EventArgs e)
        {
            LoadlistBill(Convert.ToDateTime(dateFromDate.Text), Convert.ToDateTime(dateToDate.Text));
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            int id_bill = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]);
            string room_number  = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString().Trim() + "";
            Room room = RoomDAO.Instance.GetRoomByRoomNumber(room_number);
            FBill f = new FBill(id_bill,room.Room_ID);
            f.ShowDialog();
        }
    }
}
