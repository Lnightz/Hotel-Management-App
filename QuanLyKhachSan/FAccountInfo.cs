using DAL;
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
    public partial class FAccountInfo : DevExpress.XtraEditors.XtraForm
    {
        public Account LoginAccount;
        public FAccountInfo()
        {
            this.LoginAccount = UserManager.Account;
            InitializeComponent();
            LoadInfor();
        }

        private void LoadInfor()
        {
            Account account = AccountDAO.Instance.GetAccountByUserName(LoginAccount.UserName);
            textUserName.Text = LoginAccount.UserName;
            textDisplayName.Text = account.DisplayName;
        }

        private void UpdateAccount()
        {
            string userName = textUserName.Text;
            string displayName = textDisplayName.Text;
            string passWord = textPass.Text;
            string newPass = textNewPass.Text;
            string reEnterPass = textReEnterPass.Text;
            if (!newPass.Equals(reEnterPass))
            {
                MessageBox.Show("Vui lòng nhập lại đúng mật khẩu mới", "Thông Báo");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, passWord, newPass))
                {
                    if (MessageBox.Show("Cập nhật thành công","Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (updateDisplayName != null)
                            updateDisplayName(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName))); 
                        this.Close();
                    }
                }
                else MessageBox.Show("Vui lòng điền đúng mật khẩu!", "Thông báo");
            }
        }

        private void simpleButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }


        /// <summary>
        /// Tạo Event để hiển thị lại displayname 
        /// </summary>
        private event EventHandler<AccountEvent> updateDisplayName;
        public event EventHandler<AccountEvent> UpdateDisplayName
        {
            add { updateDisplayName += value; }
            remove { updateDisplayName -= value; }
        }
    }
    /// khởi tạo Event account để hiển thị lại displayname
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc { get => acc; set => acc = value; }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
