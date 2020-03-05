using DAL;
using DevExpress.XtraCharts;
using QuanLyKhachSan.DAO;
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
    public partial class FDashBoard : Form
    {
        public FDashBoard()
        {
            InitializeComponent();
            var monthyear = DateTime.Now.Date.ToString("MM/yyyy");
            dateEditPick.Text = monthyear;
            var month = dateEditPick.DateTime.Month;
            var year = dateEditPick.DateTime.Year;
            LoadCount(month,year);
            LoadChart(month, year);
        }

        #region Method
        
        public void LoadCount(int month, int year)
        {
            labelBooking.Text = LoadChartDAO.Instance.CountBooking(month,year).ToString();
            labelCancelBooking.Text = LoadChartDAO.Instance.CountCancelBooking(month,year).ToString();
            labelVisistor.Text = LoadChartDAO.Instance.CountCustomer().ToString();
            try
            {
                labelToTal.Text = LoadChartDAO.Instance.Total(month, year).ToString("c");
            }
            catch { labelToTal.Text = "0" ; }
        }

        private void LoadChart(int month, int year)
        {
            //Tạo Series cho biểu đồ tròn
            Series series1 = new Series("", ViewType.Pie);
            series1.DataSource = DataProvider.Instance.ExecuteQuery("EXECUTE USP_RoomTypeNameQuantityRent @month , @year", new object[] { month, year });
            series1.ArgumentDataMember = "Room_Type"; //Truyền thông tin đo
            series1.ValueDataMembers.AddRange(new string[] { "Count_Quantity" });//Truyền giá trị đo
            //Clear chart trước khi gắn series vào
            pieChart.Series.Clear();
            //Gắn series vào biểu đồ tròn
            pieChart.Series.Add(series1);
            //Chú thích hiển thị tên
            series1.LegendTextPattern = "{A}";
            ((PieSeriesLabel)series1.Label).Position = PieSeriesLabelPosition.TwoColumns;

            //Tạo Series cho biểu đồ đường ADR
            Series series2 = new Series("", ViewType.Line);
            series2.DataSource = DataProvider.Instance.ExecuteQuery("EXECUTE USP_DashBoardChartADR @month , @year", new object[] { month, year });
            series2.ArgumentDataMember = "Day"; //Truyền thông tin đo
            series2.ValueDataMembers.AddRange(new string[] { "Room_Rent_Total" });//Truyền giá trị đo
            //Clear chart trước khi gắn series vào
            chart1.Series.Clear();
            //Gắn series vào biểu đồ tròn
            chart1.Series.Add(series2);
        }

        #endregion

        #region Event

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonWatch_Click(object sender, EventArgs e)
        {
            try
            {
                
                var month = dateEditPick.DateTime.Month;
                var year = dateEditPick.DateTime.Year;
                LoadCount(month, year);
                LoadChart(month, year);
            }
            catch { MessageBox.Show("Dữ liệu tháng này không có ", "Thông báo"); }
        }

        #endregion
    }
}
