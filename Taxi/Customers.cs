using App.Triggers;
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

namespace Taxi
{
    public partial class Customers : Crud
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }



        public override void RexaSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            base.RexaSelect_CellContentClick(sender, e);
            var customer = db.tblCustomers.Find(SelectedId);
            if (customer != null)
            {
                textBox1.Text = customer.FName;
                textBox2.Text = customer.LName;
                textBox3.Text = customer.Address;
                textBox4.Text = customer.TellNumber;
                textBox5.Text = customer.Phone;
            }
        }
        public override void RexaSelect()
        {

            textBox1.Text =
            textBox2.Text =
            textBox3.Text =
            textBox4.Text =
            textBox5.Text =
             string.Empty;
            base.RexaSelect();

        }
        public override void RexaInsert()
        {
            var customer = new Models.tblCustomer
            {
                FName = textBox1.Text,
                LName = textBox2.Text,
                Address = textBox3.Text,
                TellNumber = textBox4.Text,
                Phone = textBox5.Text,
                CreateDate = DateTime.Now.ToString("yyyy/MM/dd")
            };
            new RexaValidator(customer);
            db.tblCustomers.Add(customer);
            db.SaveChanges();
            base.RexaInsert();
        }
        public override void RexaUpdate()
        {
            var customer = db.tblCustomers.Find(SelectedId);

            customer.FName = textBox1.Text;
            customer.LName = textBox2.Text;
            customer.Address = textBox3.Text;
            customer.TellNumber = textBox4.Text;
            customer.Phone = textBox5.Text;

            new RexaValidator(customer);

            db.SaveChanges();
            base.RexaUpdate();
        }
        public override void RexaDelete()
        {
            var customer = db.tblCustomers.Find(SelectedId);
            db.tblCustomers.Remove(customer);
            db.SaveChanges();
            base.RexaDelete();
        }
        public override void RexaBind()
        {
            dataGridView1.DataSource = db.tblCustomers.Select(x => new { x.ID, x.CreateDate, x.FName, x.LName, x.Phone, x.TellNumber }).ToList();
            dataGridView1.Refresh();
            base.RexaBind();
        }


    }
}
