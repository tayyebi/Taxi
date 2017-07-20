using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Masters;

namespace Taxi
{
    public partial class Settings : Habil
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            if (File.Exists("settings.gpj"))
            numericUpDown1.Value = Convert.ToInt32(File.ReadAllText("settings.gpj"));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = 100 - numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText("settings.gpj", numericUpDown1.Value.ToString());
        }
    }
}
