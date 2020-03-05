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
    public partial class FLogIn : Form
    {
        public FLogIn()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void FLogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void roundedButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void roundedButtonExit_MouseHover(object sender, EventArgs e)
        {
            roundedButtonExit.BackColor = Color.Red;
        }

        private void roundedButtonExit_MouseLeave(object sender, EventArgs e)
        {
            roundedButtonExit.BackColor = Color.FromArgb(161, 196, 251);
        }

        private void roundedButtonLogIn_MouseHover(object sender, EventArgs e)
        {
            roundedButtonLogIn.BackColor = Color.Blue;
        }

        private void roundedButtonLogIn_MouseLeave(object sender, EventArgs e)
        {
            roundedButtonLogIn.BackColor = Color.FromArgb(161, 196, 251);
        }

        private void roundedButtonLogIn_Click(object sender, EventArgs e)
        {
            string username = textBoxUserName.Text;
            string password = textBoxPass.Text;
            if (Login(username, password))
            {
                Account LoginAccount = AccountDAO.Instance.GetAccountByUserName(username);

                UserManager.Account = LoginAccount;

                FMain f = new FMain();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặt mật khẩu!", "Thông Báo");
            }
        }
        bool Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }
    }
}
