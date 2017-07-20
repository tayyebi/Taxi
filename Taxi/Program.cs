using App.Triggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Componenets;

namespace Taxi
{
    static class Program
    {


        static public int OperatorId { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => RexaError(sender, args.ExceptionObject as Exception);
            Application.ThreadException += (sender, args) => RexaError(sender, args.Exception);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //// TODO
            // new Splash().ShowDialog();
            //if (new Login().ShowDialog() == DialogResult.OK)
                Application.Run(new Form1());
            //else throw new RexaException("برنامه متوقف شد");
        }

        private static void RexaError(object sender, Exception e)
        {

            RexaMessage rm = new RexaMessage("خطا");
            rm.label1.Text += "\r\n" + e.Message;
            rm.ShowDialog();
        }
    }
}
