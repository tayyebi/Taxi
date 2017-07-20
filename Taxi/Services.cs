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
using Taxi.Models;

namespace Taxi
{
    public partial class Services : Crud
    {
        public Services()
        {
            InitializeComponent();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Fullname";
            comboBox1.DataSource = db.tblCustomers.Select(x => new { Fullname = x.FName + " " + x.LName, Id = x.ID }).ToList();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // textBox3.Text = ((tblCustomer)comboBox1.SelectedItem).ToString();
            if (radioButton2.Checked)
                textBox3.Text = comboBox1.SelectedValue.ToString();
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = textBox5.Enabled = radioButton1.Checked;
            textBox3.Enabled = comboBox1.Enabled = radioButton2.Checked;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Drivers((int)SelectedId).ShowDialog();
        }

        public override void RexaSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            base.RexaSelect_CellContentClick(sender, e);
            var service = db.tblServices.Find(SelectedId);
            if (service != null)
            {
                textBox1.Text = service.Date;

                if (service.CustomerID != null)
                {
                    textBox3.Text = service.CustomerID.ToString();
                    radioButton2.Checked = true;
                }
                else
                {
                    textBox2.Text = service.FullName;
                    textBox5.Text = service.Tellnumber;
                    radioButton1.Checked = true;
                }
                textBox4.Text = service.Time;
                button7.Visible = true;
            }
        }
        public override void RexaSelect()
        {
            textBox3.Text =
            textBox2.Text =
            textBox5.Text =
            string.Empty;



            base.RexaSelect();
        }
        public override void RexaInsert()
        {
            var service = new Models.tblService
            {
                Date = textBox1.Text,
                Time = textBox4.Text
            };
            if (radioButton1.Checked)
            {
                service.FullName = textBox2.Text;
                service.Tellnumber = textBox5.Text;
            }
            else if (radioButton2.Checked)
                service.CustomerID = int.Parse(textBox3.Text);


            new RexaValidator(service);
            db.tblServices.Add(service);
            db.SaveChanges();
            base.RexaInsert();
        }
        public override void RexaUpdate()
        {
            var service = db.tblServices.Find(SelectedId);

            service.Date = textBox1.Text;
            if (radioButton1.Checked)
            {
                service.FullName = textBox2.Text;
                service.Tellnumber = textBox5.Text;
            }
            else if (radioButton2.Checked)
                service.CustomerID = int.Parse(textBox3.Text);
            service.Time = textBox4.Text;

            new RexaValidator(service);

            db.SaveChanges();
            base.RexaUpdate();
        }
        public override void RexaDelete()
        {
            var service = db.tblServices.Find(SelectedId);
            db.tblServices.Remove(service);
            db.SaveChanges();
            base.RexaDelete();
        }
        public override void RexaBind()
        {
            button7.Visible = false;

            var now = DateTime.Now;
            textBox4.Text = now.ToString("HH:mm");
            textBox1.Text = now.ToShortDateString();

            dataGridView1.DataSource =
                (from service in db.tblServices

                 join customer in db.tblCustomers
                 on service.CustomerID equals customer.ID
                 into leftCustomer
                 from LeftCustomer in leftCustomer.DefaultIfEmpty()

                 join service_car in db.tblServiceCars
                 on service.ID equals service_car.ServiceID
                 into leftServiceCar
                 from LeftServiceCar in leftServiceCar.DefaultIfEmpty()

                 join car in db.tblCars
                 on LeftServiceCar.CarID equals car.ID
                 into leftCar
                 from LeftCar in leftCar.DefaultIfEmpty()

                 join driver in db.tblUsers
                 on LeftCar.DriverID equals driver.ID
                 into leftDriver
                 from LeftDriver in leftDriver.DefaultIfEmpty()

                 join route in db.tblRoutes
                 on LeftServiceCar.RouteID equals route.ID
                 into leftRoute
                 from LeftRoute in leftRoute.DefaultIfEmpty()

                 // where

                 select new
                 {
                     service.ID,
                     service.Date,
                     service.Time,
                     Fullname = LeftCustomer != null ? LeftCustomer.FName + " " + LeftCustomer.LName + " - اشتراک:" + LeftCustomer.ID : service.FullName,
                     Car = LeftCar != null ? "(" + LeftCar.CarName + " -  " + LeftDriver.LName + ")" : null,
                     Price = LeftRoute.Price,
                     Destinations = LeftRoute.DestinationName
                 }
                 )
                 .GroupBy(x => new { x.ID, x.Date, x.Time, x.Fullname })
                 .AsEnumerable()
                 .Select(h => new
                 {
                     ID = h.Key.ID,
                     زمان = h.Key.Time,
                     تاریخ = h.Key.Date,
                     نام_مشتری = h.Key.Fullname,
                     قیمت_نهایی = h.Sum(x => x.Price ?? 0).ToString(),
                     خودرو_ها = h.Aggregate("", (current, next) => current + ", " + next.Car ?? String.Empty).ToString(),
                     مقصد_ها = h.Aggregate("", (current, next) => current + " / " + next.Destinations ?? String.Empty).ToString()
                 })
                 .ToList();


            dataGridView1.Refresh();

            base.RexaBind();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(textBox3.Text, out id);
            var customer = db.tblCustomers.Find(id);
            if (customer != null)
                comboBox1.Text = customer.FName + " " + customer.LName;
        }
    }
}
