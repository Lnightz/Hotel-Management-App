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
    public partial class FAccountList : DevExpress.XtraEditors.XtraForm
    {
        public Account LoginAccount;
        BindingSource accountlist = new BindingSource();
        public FAccountList()
        {
            this.LoginAccount = UserManager.Account;
            InitializeComponent();
            gridControlAcc.DataSource = accountlist;
            LoadAccountList();
            AddDataBinding();
            LoadCBTN();
            LoadEmpName();
        }

        private void LoadAccountList()
        {
            List<AccountDetail> acclist = AccountDAO.Instance.GetAccountDetailsList();
            accountlist.DataSource = acclist;
        }
        private void AddDataBinding()
        {
            textUserName.DataBindings.Add(new Binding("Text", gridControlAcc.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            textDisplayName.DataBindings.Add(new Binding("Text", gridControlAcc.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            comboBoxAccountType.DataBindings.Add(new Binding("Text", gridControlAcc.DataSource, "TypeName", true, DataSourceUpdateMode.Never));
            //searchLookUpEditEmpName.DataBindings.Add(new Binding("Text", gridControlAcc.DataSource, "EmpName", true, DataSourceUpdateMode.Never));
        }

        private void LoadCBTN()
        {
            List<AccountType> typeslist = AccountDAO.Instance.GetAccountTypesList();
            comboBoxAccountType.DataSource = typeslist;
            comboBoxAccountType.DisplayMember = "TypeName";
        }

        private void LoadEmpName()
        {
            List<Employee> list = EmployeeDAO.Instance.GetEmployeesList();
            searchLookUpEditEmpName.Properties.DataSource = list;
            searchLookUpEditEmpName.Properties.DisplayMember = "EmpName";
        }
        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text;
            string displayname = textDisplayName.Text;
            AccountType type = AccountDAO.Instance.GetAccountTypeIdByName(comboBoxAccountType.Text);
            Employee employee = EmployeeDAO.Instance.GetEmployeeByName(searchLookUpEditEmpName.Text);
            if (textUserName.Text == "" || textDisplayName.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết của khách hàng", "Thông báo!!");
            }
            else
            {
                try
                {
                    if (AccountDAO.Instance.InsertAccount(username, displayname, type.TypeID,employee.EmpID))
                    {
                        MessageBox.Show("Thêm tài khoản thành công", "Thông báo!!");
                        LoadAccountList();
                    }
                }
                catch { MessageBox.Show("Tên đăng nhập bị trùng", "Thông báo!!"); }
            }
        }

        private void simpleButtonResetPass_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text;
            if (textUserName.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản để đặt lại mật khẩu", "Thông báo");
            }
            else
            {
                try
                {
                    if (AccountDAO.Instance.ResetPassAccount(username))
                    {
                        MessageBox.Show("Đặt lại mật khẩu thành công", "Thông báo!!");
                        LoadAccountList();
                    }
                }
                catch { MessageBox.Show("Không đặt lại mật khẩu được", "Thông báo!!"); }
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text;
            string displayname = textDisplayName.Text;
            AccountType type = AccountDAO.Instance.GetAccountTypeIdByName(comboBoxAccountType.Text);
            Employee employee = EmployeeDAO.Instance.GetEmployeeByName(searchLookUpEditEmpName.Text);
            if (textUserName.Text == "" || textDisplayName.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết", "Thông báo!!");
            }
            else
            {
                try
                {
                    if (AccountDAO.Instance.UpdateAccount(username, displayname, type.TypeID,employee.EmpID))
                    {
                        MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo!!");
                        LoadAccountList();
                    }
                }
                catch { MessageBox.Show("Tên đăng nhập bị trùng", "Thông báo!!"); }
            }
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            string username = textUserName.Text;
            if (textUserName.Text== "")
            {
                MessageBox.Show("Vui lòng chọn tài khoản để xóa", "Thông báo");
            }
            else
            {
                if (!username.Equals(LoginAccount.UserName))
                {
                    try
                    {
                        if (AccountDAO.Instance.DeleteAccount(username))
                        {
                            MessageBox.Show("Xóa tài khoản thành công", "Thông báo!!");
                            LoadAccountList();
                        }
                    }
                    catch { MessageBox.Show("Không xóa được tài khoản này", "Thông báo!!"); }
                }
                else { MessageBox.Show("Tài Khoản này đang được sử dụng, không thể xóa được", "Thông báo!!"); }
            }

        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
