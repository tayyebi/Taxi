using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Models;

namespace Taxi.Masters
{
    public partial class Habil : Adam
    {
        public MainModel db = new MainModel();

        public Habil()
        {
            InitializeComponent();
        }

        private void Habil_Load(object sender, EventArgs e)
        {

        }

        private void Habil_TextChanged(object sender, EventArgs e)
        {
            label5.Text = Text;
        }
    }
}
