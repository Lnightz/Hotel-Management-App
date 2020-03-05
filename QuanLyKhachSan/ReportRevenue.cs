using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QuanLyKhachSan
{
    public partial class ReportRevenue : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportRevenue()
        {
            InitializeComponent();
        }

        public void Binding()
        {
            CellBillID.DataBindings.Add("Text", DataSource, "Bill_ID");
            CellRoom.DataBindings.Add("Text", DataSource, "Room_number");
            CellCheckin.DataBindings.Add("Text", DataSource, "Date_Chekin").FormatString = "{0:dd/MM/yyyy}";
            CellCheckout.DataBindings.Add("Text", DataSource, "Date_Checkout").FormatString = "{0:dd/MM/yyyy}";
            CellHourRent.DataBindings.Add("Text", DataSource, "Hour_Rent");
            //CellServ.DataBindings.Add("Text", DataSource, "Bill_ID");
            CellToTal.DataBindings.Add("Text", DataSource, "Total").FormatString = "{0:00,0}";
            labelToTalALL.DataBindings.Add("Text", DataSource, "Total");
            labelToTalALL.Summary = new DevExpress.XtraReports.UI.XRSummary(DevExpress.XtraReports.UI.SummaryRunning.Report, DevExpress.XtraReports.UI.SummaryFunc.Sum, "{0:00,0}");
        }

    }
}
