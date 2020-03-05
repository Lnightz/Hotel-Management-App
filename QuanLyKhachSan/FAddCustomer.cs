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
    public partial class FAddCustomer : DevExpress.XtraEditors.XtraForm
    {
        public FAddCustomer()
        {
            InitializeComponent();
        }



        private void simpleButtonOk_Click(object sender, EventArgs e)
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
                    if (MessageBox.Show("Bạn có muốn thêm khách hàng " + cusname + " không", "Thông Báo!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (CustomerDAO.Instance.InsertCustomer(cusname, cusphone, cuspassport, cusemail))
                        {
                            MessageBox.Show("Thêm khách hàng thành công", "Thông báo");
                            this.Close();
                        }
                        else MessageBox.Show("Không thêm được khách hàng này", "Thông Báo");
                    }
                }
            }
        }

        private void simpleButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
