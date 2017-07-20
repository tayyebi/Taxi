using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Masters;
using Taxi.Models;

namespace Taxi
{
    public partial class Login : Adam
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            using (var db = new MainModel())
            {
                var user = db.tblUsers.Where(x => x.UserType == "اپراتور" && x.Username == textBox1.Text).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == textBox2.Text)
                    {
                        Program.OperatorId = user.ID;
                        DialogResult = DialogResult.OK;
                    }
                }
                label4.Visible = true;
            }
        }
    }
}
