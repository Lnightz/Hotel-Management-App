using DAL;
using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.Settings;
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
    public partial class FReport : DevExpress.XtraEditors.XtraForm
    {
        public Account LoginAccount;
        public FReport()
        {
            this.LoginAccount = UserManager.Account;
            InitializeComponent();
        }

        private void documentViewer1_Load(object sender, EventArgs e)
        {
            ReportRevenue report = new ReportRevenue();

            Employee employee = EmployeeDAO.Instance.GetEmployeeByID(LoginAccount.EmpID);

            report.DataSource = DataProvider.Instance.ExecuteQuery("EXECUTE dbo.USP_LoadReport");

            report.Binding();

            report.labelDay.Text = string.Format("TP.Hồ Chí Minh, Ngày {0}, tháng {1}, năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            report.labelCreator.Text = employee.EmpName;

            documentViewer1.PrintingSystem = report.PrintingSystem;

            report.CreateDocument();

            //ReportPrintTool tool = new ReportPrintTool(report);

            //tool.ShowPreview();
        }
    }
}
