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

namespace Taxi.Componenets
{
    public partial class RexaMessage : Adam
    {
        public RexaMessage(string Message)
        {

            InitializeComponent();
            label1.Text = Message;
        }

        private void RexaMessage_Load(object sender, EventArgs e)
        {

        }
    }
}
