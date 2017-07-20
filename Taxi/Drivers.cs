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
    public partial class Drivers : Crud
    {
        public int ServiceId { get; set; }

        public Drivers(int Service)
        {
            InitializeComponent();
            ServiceId = Service;
        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            var service = db.tblServices.Find(ServiceId);
            label7.Text += service.Date + " " + service.Time;
            label7.Text += "\r\n شماره اشتراک - " + service.CustomerID;
            label7.Text += "\r\n مشتری - " + service.FullName;

        }



        public override void RexaSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            base.RexaSelect_CellContentClick(sender, e);
            var service_car = db.tblServiceCars.Find(SelectedId);
            if (service_car != null)
            {
                comboBox2.SelectedValue = service_car.CarID;
                comboBox1.SelectedValue = db.tblCars.Find(service_car.CarID).DriverID;
                comboBox3.SelectedValue = db.tblRoutes.Find(service_car.RouteID).ID;
            }
        }
        public override void RexaSelect()
        {
            checkBox1.Checked = false;

            base.RexaSelect();

        }
        public override void RexaInsert()
        {
            var service_car = new Models.tblServiceCar
            {
                RouteID = int.Parse(comboBox3.SelectedValue.ToString()),
                ServiceID = ServiceId,
                Payed = checkBox1.Checked,
                CarID = int.Parse(comboBox2.SelectedValue.ToString())
            };
            new RexaValidator(service_car);
            db.tblServiceCars.Add(service_car);
            db.SaveChanges();
            base.RexaInsert();
        }
        public override void RexaUpdate()
        {
            var service_car = db.tblServiceCars.Find(SelectedId);

            service_car.RouteID = int.Parse(comboBox3.SelectedValue.ToString());
            service_car.ServiceID = ServiceId;
            service_car.CarID = int.Parse(comboBox3.SelectedValue.ToString());
            service_car.Payed = checkBox1.Checked;


            new RexaValidator(service_car);

            db.SaveChanges();
            base.RexaUpdate();
        }
        public override void RexaDelete()
        {
            var car = db.tblServiceCars.Find(SelectedId);
            db.tblServiceCars.Remove(car);
            db.SaveChanges();
            base.RexaDelete();
        }
        public override void RexaBind()
        {


            comboBox1.ValueMember = "Id";
            comboBox2.ValueMember = "Id";

            comboBox2.DataSource = comboBox1.DataSource = (
            from car in db.tblCars
            join driver in db.tblUsers.Where(x => x.UserType == "راننده") on car.DriverID equals driver.ID
            select new
            {
                Driver = driver.FName + " " + driver.LName,
                Car = car.CarName + " " + car.CarColor + "  (" + car.IdentityNumber + ")",
                Id = car.ID
            }
            ).ToList();

            comboBox2.DisplayMember = "Car";
            comboBox1.DisplayMember = "Driver";


            comboBox3.ValueMember = "Id";
            comboBox3.DataSource = db.tblRoutes.ToList();
            comboBox3.DisplayMember = "DestinationName";

            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            dataGridView1.DataSource = db.tblServiceCars
                .Include("tblCars")
                .Include("tblRoute")
                .Include("tblUser")
                .Where(x => x.ServiceID == ServiceId)
                .Select(x => new
                {
                    x.ID,
                    خودرو = x.tblCar.CarName + " " + x.tblCar.CarColor + " (" + x.tblCar.IdentityNumber + ")",
                    مقصد  = x.tblRoute.DestinationName,
                    راننده = x.tblCar.tblUser.FName + " " + x.tblCar.tblUser.LName
                })
                
                .ToList();

            dataGridView1.Refresh();
            base.RexaBind();
        }

    }
}
