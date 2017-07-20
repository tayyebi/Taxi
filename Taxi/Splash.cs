using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taxi
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();


            Opacity = 0;
            Timer t = new Timer();
            t.Interval = 1;
            int i = 0;
            bool shown = false;
            t.Tick += delegate
            {
                if (i == 100 || shown)
                {
                    shown = true;
                    i--;
                }
                else if (!shown)
                {
                    i++;
                }

                Opacity = 0.01 * i;

                if (i == 0 && shown)
                    Close();
            };
            t.Enabled = true;
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }
    }
}
