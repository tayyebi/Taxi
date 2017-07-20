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
    public partial class Cars : Crud
    {
        public Cars()
        {
            InitializeComponent();
        }

        private void Customers_Load(object sender, EventArgs e)
        {

        }



        public override void RexaSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            base.RexaSelect_CellContentClick(sender, e);
            var car = db.tblCars.Find(SelectedId);
            if (car != null)
            {
                textBox1.Text = car.CarName;
                comboBox1.Text = car.CarColor;
                label8.Text = car.IdentityNumber;
                var driver = db.tblUsers.Find(car.DriverID);
                comboBox2.Text = driver.FName + " " + driver.LName;
            }
        }
        public override void RexaSelect()
        {

            textBox1.Text =
            textBox4.Text =
            textBox2.Text =
            textBox3.Text =
            comboBox1.Text =
            comboBox2.Text =
            comboBox3.Text =
             string.Empty;
            base.RexaSelect();

        }
        public override void RexaInsert()
        {
            var car = new Models.tblCar
            {
                CarName = textBox1.Text,
                IdentityNumber = textBox3.Text + comboBox3.Text + textBox4.Text + "ایران" + textBox2.Text,
                CarColor = comboBox1.Text,
                //DriverID = ((tblUser)comboBox2.SelectedItem).ID
                DriverID = int.Parse(comboBox2.SelectedValue.ToString())
            };
            new RexaValidator(car);
            db.tblCars.Add(car);
            db.SaveChanges();
            base.RexaInsert();
        }
        public override void RexaUpdate()
        {
            var car = db.tblCars.Find(SelectedId);

            car.CarName = textBox1.Text;
            car.IdentityNumber = textBox3.Text + comboBox3.Text + textBox4.Text + "ایران" + 2;
            car.CarColor = comboBox1.Text;
            car.DriverID = int.Parse(comboBox3.SelectedValue.ToString());


            new RexaValidator(car);

            db.SaveChanges();
            base.RexaUpdate();
        }
        public override void RexaDelete()
        {
            var car = db.tblCars.Find(SelectedId);
            db.tblCars.Remove(car);
            db.SaveChanges();
            base.RexaDelete();
        }
        public override void RexaBind()
        {
            comboBox2.DataSource = db.tblUsers.Where(x => x.UserType == "راننده").Select(x => new { Fullname = x.FName + " " + x.LName, x.ID }).ToList();
            comboBox2.DisplayMember = "Fullname";
            comboBox2.ValueMember = "ID";
            comboBox2.Refresh();
            comboBox2.SelectedIndex = 0;

            dataGridView1.DataSource = db.tblCars.Select(x => new { x.ID, x.CarName, x.CarColor }).ToList();

            dataGridView1.Refresh();
            base.RexaBind();
        }


    }
}
