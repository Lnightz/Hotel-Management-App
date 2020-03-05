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
    public partial class FServicesCatogory : DevExpress.XtraEditors.XtraForm
    {
        BindingSource categorylist = new BindingSource();
        public FServicesCatogory()
        {
            InitializeComponent();
            gridControlCategory.DataSource = categorylist;
            LoadCategoryList();
            AddDataBinding();
        }

        private void LoadCategoryList()
        {
            List<ServCategory> categories = ServCategoryDAO.Instance.GetServCategoryList();
            categorylist.DataSource = categories;
        }
        private void AddDataBinding()
        {
            textCategoryID.DataBindings.Add(new Binding("Text", gridControlCategory.DataSource, "Ser_Category_ID", true, DataSourceUpdateMode.Never));
            comboBoxCategory.DataBindings.Add(new Binding("Text", gridControlCategory.DataSource, "Ser_Category_Name", true, DataSourceUpdateMode.Never));
        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            string categoryID = textCategoryID.Text;
            string name = comboBoxCategory.Text;
            if (textCategoryID.Text == "" || comboBoxCategory.Text =="" )
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết", "Thông báo");
            }
            else
            {
                int testexistcategory = ServCategoryDAO.Instance.IsExistCategoryByName(name);
                if (testexistcategory != 1)
                {
                    if (MessageBox.Show("Bạn có muốn thêm loại "+name + " không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        try
                        {
                            if (ServCategoryDAO.Instance.InsertCategory(categoryID,name))   
                            {
                                MessageBox.Show("Thêm thành công", "Thông báo");
                                LoadCategoryList();
                            }
                        }
                        catch { MessageBox.Show("Mã loại đã tồn tại", "Thông báo"); }
                    }
                }
                else MessageBox.Show("Loại dịch vụ này đã tồn tại", "Thông báo");
            }
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            string categoryID = textCategoryID.Text;
            string name = comboBoxCategory.Text;
            if (MessageBox.Show("Bạn có muốn xoá " + name + " không?", "Thông Báo!!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (ServCategoryDAO.Instance.DeleteCategory(categoryID))
                    {
                        MessageBox.Show("Xoá loại " + name + " thành công", "Thông báo");
                        LoadCategoryList();
                    }
                }
                catch
                {
                    MessageBox.Show("Không xoá được " + name + "", "Thông báo");
                }
            }
        }

        private void simpleButtonEdit_Click(object sender, EventArgs e)
        {
            string categoryID = textCategoryID.Text;
            string name = comboBoxCategory.Text;
            if (textCategoryID.Text == "" || comboBoxCategory.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin cần thiết", "Thông báo");
            }
            else
            {
                ServCategory test = ServCategoryDAO.Instance.GetCategoryById(categoryID);
                if (test == null)
                {
                    MessageBox.Show("Mã loại dịch vụ này không tồn tại", "Thông báo");
                }
                else
                {
                    if (comboBoxCategory.Text.Equals(test.Ser_Category_Name))
                    {
                        if (MessageBox.Show("Bạn có muốn sửa thông tin loại dịch vụ không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            if (ServCategoryDAO.Instance.UpdateCategory(name,categoryID))
                            {
                                MessageBox.Show("Sửa thành công", "Thông báo");
                                LoadCategoryList();
                            }
                        }
                    }
                    else
                    {
                        int testexistcategory = ServCategoryDAO.Instance.IsExistCategoryByName(name);
                        if (testexistcategory != 1)
                        {
                            if (MessageBox.Show("Bạn có muốn sửa thông tin loại dịch vụ không?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                            {
                                if (ServCategoryDAO.Instance.UpdateCategory(name, categoryID))
                                {
                                    MessageBox.Show("Sửa thành công", "Thông báo");
                                    LoadCategoryList();
                                }
                            }
                        }
                        else { MessageBox.Show("Tên loại dịch vụ này đã tồn tại", "Thông báo"); }
                    }
                }
            }
        }
    }
}
