using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;

namespace QuanLyKhachSan
{
    public partial class FCustomerList : DevExpress.XtraEditors.XtraForm
    {
        BindingSource customerlist = new BindingSource();
        public FCustomerList()
        {
            InitializeComponent();
            gridControlCustomer.DataSource = customerlist;
            LoadCustomerList();
            AddDataBiding();
        }

        public void AddDataBiding()
        {
            textEditCusName.DataBindings.Add(new Binding("Text", gridControlCustomer.DataSource, "Cus_name",true,DataSourceUpdateMode.Never));
            textEditCusPhone.DataBindings.Add(new Binding("Text", gridControlCustomer.DataSource, "Cus_phone", true, DataSourceUpdateMode.Never));
            textEditCusPassport.DataBindings.Add(new Binding("Text", gridControlCustomer.DataSource, "Cus_cmnd", true, DataSourceUpdateMode.Never));
            textEditCusMail.DataBindings.Add(new Binding("Text", gridControlCustomer.DataSource, "Cus_mail", true, DataSourceUpdateMode.Never));
            textEditCusID.DataBindings.Add(new Binding("Text", gridControlCustomer.DataSource,"Cus_id"));
        }
        private void LoadCustomerList()
        {
            List<Customer> customers = CustomerDAO.Instance.GetCustomerList();
            customerlist.DataSource = customers;
        }

        private void simpleButtonAddCustomer_Click(object sender, EventArgs e)
        {
            string cusname = textEditCusName.Text;
            string cusphone = textEditCusPhone.Text;
            string cuspassport = textEditCusPassport.Text;
            string cusemail = textEditCusMail.Text;
            if (cusname == "" || cuspassport == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết của khách hàng", "Thông báo!!");
            }
            else
            {
                int isExistCustomer = CustomerDAO.Instance.IsExistCustomer(cuspassport);
                if (isExistCustomer == 1)
                {
                    MessageBox.Show("Khách hàng này đã tồn tại", "Thông Báo");
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn thêm khách hàng " + cusname + " không?", "Thông Báo!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (CustomerDAO.Instance.InsertCustomer(cusname, cusphone, cuspassport, cusemail))
                        {
                            MessageBox.Show("Thêm khách hàng thành công", "Thông báo");
                            LoadCustomerList();
                        }
                        else MessageBox.Show("Không thêm được khách hàng này", "Thông Báo");
                    }
                }
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            string cusname = textEditCusName.Text;
            string cusphone = textEditCusPhone.Text;
            string cuspassport = textEditCusPassport.Text;
            string cusemail = textEditCusMail.Text;
            int cusid = Convert.ToInt32(textEditCusID.Text);
            if (cusname == "" || cuspassport == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết của khách hàng", "Thông báo!!");
            }
            else 
            {
                Customer customer = CustomerDAO.Instance.GetCustomerByID(cusid);
                //Kiểm tra xem có sửa CMND/ Passport hay không
                if (string.Compare(customer.Cus_cmnd,cuspassport) == 0)// không sửa passport
                {
                    if (MessageBox.Show("Bạn có sửa thông tin khách hàng " + cusname + " không?", "Thông Báo!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (CustomerDAO.Instance.UpdateCustomer(cusname, cusphone, cuspassport, cusemail, cusid))
                        {
                            MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo");
                            LoadCustomerList();
                        }
                        else MessageBox.Show("Sửa không thành công!", "Thông báo");
                    }
                }
                else //khách hàng sửa passport 
                {
                    int isexistcus = CustomerDAO.Instance.IsExistCustomer(cuspassport);
                    //Kiểm tra xem passport vừa sửa có bị trùng với passport có sẵn không
                    if (isexistcus == 1)// passport bị trùng
                    {
                        MessageBox.Show("Thông tin khách hàng này bị trùng", "Thông báo");
                    }
                    else //Không bị trùng 
                    {
                        if (MessageBox.Show("Bạn có sửa thông tin khách hàng " + cusname + " không?", "Thông Báo!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            if (CustomerDAO.Instance.UpdateCustomer(cusname, cusphone, cuspassport, cusemail, cusid))
                            {
                                MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo");
                                LoadCustomerList();
                            }
                            else MessageBox.Show("Sửa không thành công!", "Thông báo");
                        }
                    }
                }
            }
        }

        private void simpleButtonDeleteCus_Click(object sender, EventArgs e)
        {
            string cusname = textEditCusName.Text;
            int cusid = Convert.ToInt32(textEditCusID.Text);
            if (MessageBox.Show("Bạn có muốn xoá khách hàng " + cusname + " không?", "Thông Báo!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (CustomerDAO.Instance.DeleteCustomer(cusid))
                    {
                        MessageBox.Show("Xoá khách hàng " + cusname + " thành công", "Thông báo");
                        LoadCustomerList();
                    }
                }
                catch
                {
                    MessageBox.Show("Không xoá được khách hàng này", "Thông báo");
                }
            }
        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
