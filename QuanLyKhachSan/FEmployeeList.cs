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
    public partial class FEmployeeList : DevExpress.XtraEditors.XtraForm
    {
        BindingSource emplist = new BindingSource();

        public FEmployeeList()
        {
            InitializeComponent();
            gridControlEmp.DataSource = emplist;
            LoadEmpList();
            AddDataBinding();
        }

        private void LoadEmpList()
        {
            List<Employee> emp = EmployeeDAO.Instance.GetEmployeesList();
            emplist.DataSource = emp;
        }
        private void AddDataBinding()
        {
            textEmpID.DataBindings.Add(new Binding("Text", gridControlEmp.DataSource, "EmpID", true, DataSourceUpdateMode.Never));
            textEmpName.DataBindings.Add(new Binding("Text", gridControlEmp.DataSource, "EmpName", true, DataSourceUpdateMode.Never));
            textEmpPhone.DataBindings.Add(new Binding("Text", gridControlEmp.DataSource, "EmpPhone", true, DataSourceUpdateMode.Never));
            textEmpMail.DataBindings.Add(new Binding("Text", gridControlEmp.DataSource, "EmpMail", true, DataSourceUpdateMode.Never));
            textEmpAdress.DataBindings.Add(new Binding("Text", gridControlEmp.DataSource, "EmpAddress", true, DataSourceUpdateMode.Never));
            textEmpCMND.DataBindings.Add(new Binding("Text", gridControlEmp.DataSource, "EmpCMND", true, DataSourceUpdateMode.Never));
            dateEmpBirth.DataBindings.Add(new Binding("Text", gridControlEmp.DataSource, "EmpBirth", true, DataSourceUpdateMode.Never));
        }
        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            string name = textEmpName.Text;
            string phone = textEmpPhone.Text;
            string mail = textEmpMail.Text;
            string address = textEmpAdress.Text;
            DateTime birth = Convert.ToDateTime(dateEmpBirth.Text);
            string birthdate = String.Format("{0:MM/dd/yyyy}", birth);
            string cmnd =  textEmpCMND.Text;
            if (name == null || birth == null || cmnd == null)
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết", "Thông báo!!");
            }
            else
            {
                int test = EmployeeDAO.Instance.IsExistEmp(cmnd);
                if (test != 1)
                {
                    if (EmployeeDAO.Instance.InsertEmployee(name, phone, mail, birthdate, address, cmnd))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo!!");
                        LoadEmpList();
                    }
                    else { MessageBox.Show("Thêm thất bại", "Thông báo!!"); }
                }
                else { MessageBox.Show("Nhân viên này đã tồn tại", "Thông báo!!"); }
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textEmpID.Text);
            string name = textEmpName.Text;
            string phone = textEmpPhone.Text;
            string mail = textEmpMail.Text;
            string address = textEmpAdress.Text;
            DateTime birth = Convert.ToDateTime(dateEmpBirth.Text);
            string birthdate = String.Format("{0:MM/dd/yyyy}", birth);
            string cmnd = textEmpCMND.Text;
            if (name == null || birth == null || cmnd == null)
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết", "Thông báo!!");
            }
            else
            {
                Employee IsEditCMND = EmployeeDAO.Instance.GetEmployeeByID(id);
                if (cmnd.Equals(IsEditCMND.EmpCMND))
                {
                    if (EmployeeDAO.Instance.UpdateEmployee(id,name, phone, mail, birthdate, address, cmnd))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo!!");
                        LoadEmpList();
                    }
                }
                else
                {
                    int test = EmployeeDAO.Instance.IsExistEmp(cmnd);
                    if (test != 1)
                    {
                        if (EmployeeDAO.Instance.UpdateEmployee(id, name, phone, mail, birthdate, address, cmnd))
                        {
                            MessageBox.Show("Sửa thành công", "Thông báo!!");
                            LoadEmpList();
                        }
                    }
                    else { MessageBox.Show("CMND của nhân viên này bị trùng", "Thông báo!!"); }
                }
            }
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textEmpID.Text);
            try
            {
                if (EmployeeDAO.Instance.DeleteEmployee(id))
                {
                    MessageBox.Show("Xoá thành công", "Thông báo!!");
                    LoadEmpList();
                }
            }
            catch { MessageBox.Show("Không xoá nhân viên này được", "Thông báo!!"); }
        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
