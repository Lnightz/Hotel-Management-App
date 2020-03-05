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
    public partial class FServicesList : DevExpress.XtraEditors.XtraForm
    {
        BindingSource servlist = new BindingSource();
        public FServicesList()
        {
            InitializeComponent();
            gridControlServ.DataSource = servlist;
            LoadServList();
            AddDataBinding();
            LoadCBSC();
        }

        private void LoadServList()
        {
            List<Services> services = Services_DAO.Instance.GetServicesList();
            servlist.DataSource = services;
        }
        
        private void AddDataBinding()
        {
            textServID.DataBindings.Add(new Binding("Text", gridControlServ.DataSource, "ServID", true, DataSourceUpdateMode.Never));
            textServ.DataBindings.Add(new Binding("Text", gridControlServ.DataSource, "ServName", true, DataSourceUpdateMode.Never));
            comboBoxServCategory.DataBindings.Add(new Binding("Text", gridControlServ.DataSource, "CategoryName", true, DataSourceUpdateMode.Never));
            textPrices.DataBindings.Add(new Binding("Text", gridControlServ.DataSource, "ServPrices", true, DataSourceUpdateMode.Never));
            textUnit.DataBindings.Add(new Binding("Text", gridControlServ.DataSource, "Unit", true, DataSourceUpdateMode.Never));
        }
        private void LoadCBSC()
        {
            List<ServCategory> categories = ServCategoryDAO.Instance.GetServCategoryList();
            comboBoxServCategory.DataSource = categories;
            comboBoxServCategory.DisplayMember = "Ser_Category_Name";
        }
        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            string servid = textServID.Text;
            string servname = textServ.Text;
            ServCategory category = ServCategoryDAO.Instance.GetCategoryByName(comboBoxServCategory.Text);
            string unit = textUnit.Text;
            float prices = (float)Convert.ToDouble(textPrices.Text);
            if (textServID.Text == "" || textServ.Text == "" || comboBoxServCategory.Text == "" || textUnit.Text == "" || textPrices.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết", "Thông báo!!");
            }
            else
            {
                Services services = Services_DAO.Instance.GetServicesById(servid);
                if (services == null)
                {
                    int test = Services_DAO.Instance.IsExistServbyName(servname);
                    if (test != 1)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm dịch vụ này không?","Thông báo",MessageBoxButtons.OKCancel)== System.Windows.Forms.DialogResult.OK)
                        {
                            if (Services_DAO.Instance.InsertServ(servid, servname, prices, unit, category.Ser_Category_ID))
                            {
                                MessageBox.Show("Thêm thành công?", "Thông báo");
                                LoadServList();
                            }
                        }
                    }
                    else { MessageBox.Show("Dịch vụ này đã tồn tại", "Thông báo"); }
                }
                else { MessageBox.Show("Mã dịch vụ này bị trùng", "Thông báo"); }
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            string servid = textServID.Text;
            string servname = textServ.Text;
            ServCategory category = ServCategoryDAO.Instance.GetCategoryByName(comboBoxServCategory.Text);
            string unit = textUnit.Text;
            float prices = (float)Convert.ToDouble(textPrices.Text);
            if (textServID.Text == "" || textServ.Text == "" || comboBoxServCategory.Text == "" || textUnit.Text == "" || textPrices.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết", "Thông báo!!");
            }
            else
            {
                Services services = Services_DAO.Instance.GetServicesById(servid);
                if (services != null)
                {
                    if (services.ServName.Equals(servname))
                    {
                        if (Services_DAO.Instance.UpdateServ(servid, servname, prices, unit, category.Ser_Category_ID))
                        {
                            MessageBox.Show("Sửa thành công?", "Thông báo");
                            LoadServList();
                        }
                    }
                    else
                    {
                        int test = Services_DAO.Instance.IsExistServbyName(servname);
                        if (test != 1)
                        {
                            if (Services_DAO.Instance.UpdateServ(servid, servname, prices, unit, category.Ser_Category_ID))
                            {
                                MessageBox.Show("Sửa thành công?", "Thông báo");
                                LoadServList();
                            }
                        }
                        else { MessageBox.Show("Dịch vụ này đã tồn tại", "Thông báo"); }
                    }
                }
                else { MessageBox.Show("Mã dịch vụ này không tồn tại", "Thông báo"); }
            }
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            string servid = textServID.Text;
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa dịch vụ này không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (Services_DAO.Instance.DeleteServ(servid))
                    {
                        MessageBox.Show("Xóa thành công?", "Thông báo");
                        LoadServList();
                    }
                }
            }
            catch { MessageBox.Show("Không xóa được?", "Thông báo"); }

        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
