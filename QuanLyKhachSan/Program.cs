using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Threading;

namespace QuanLyKhachSan
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            WindowsFormsSettings.DefaultFont = new System.Drawing.Font("Tahoma", 11);
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.LiquidSky);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FLogIn());
        }
    }
}
