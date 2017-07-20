using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Componenets;
using Taxi.Masters;

namespace Taxi
{
    public partial class Form1 : Habil
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Hide();
            switch ((sender as Button).Text)
            {
                case "مدیریت مسیر ها":
                    new Routes().ShowDialog();
                    break;
                case "مدیریت مشتری ها":
                    new Customers().ShowDialog();
                    break;
                case "مدیریت کارمند ها":
                    new Users().ShowDialog();
                    break;
                case "مدیریت خودرو ها":
                    new Cars().ShowDialog();
                    break;
                case "مدیریت سرویس ها":
                    new Services().ShowDialog();
                    break;
                case "مدیریت پیام ها":
                    break;
                case "تنظیمات برنامه":
                    new Settings().ShowDialog();
                    break;
                case "گزارش درامد خودرو ها":
                    new CarsRevenue().ShowDialog();
                    break;
                case "گزارش 2":
                    new RexaMessage("در نسخه ی پیشرفته").ShowDialog();
                    break;
            }
            Show();
        }
    }
}
