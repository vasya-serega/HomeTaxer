using System;
using System.Windows.Forms;
using HomeTaxer.Client.Forms;

namespace HomeTaxer.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogOnForm());
        }
    }
}
