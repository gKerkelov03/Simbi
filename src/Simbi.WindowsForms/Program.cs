using System;
using System.Windows.Forms;

namespace Simbi.WindowsForms
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region Settings
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #endregion

            var loginForm = new LoginForm();
            var mainForm = new MainForm(loginForm);

            Application.Run(mainForm);
        }
    }
}
