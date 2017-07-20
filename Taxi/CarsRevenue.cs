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


    public partial class CarsRevenue : Habil
    {
        public CarsRevenue()
        {
            InitializeComponent();
        }

        private void CarsRevenue_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = checkBox1.Checked;
            maskedTextBox1.Enabled = maskedTextBox2.Enabled = checkBox3.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // TODO

            // WHERE ها فراموش نشه


            var query = (

                from service in db.tblServices

                join service_car in db.tblServiceCars
                on service.ID equals service_car.ServiceID

                join route in db.tblRoutes
                on service_car.RouteID equals route.ID

                join car in db.tblCars
                on service_car.CarID equals car.ID

                join driver in db.tblUsers
                on car.DriverID equals driver.ID

                select new { service, car, service_car, route, driver }

                )
                .GroupBy(x=>new {x.car.ID, x.car.CarName, x.car.IdentityNumber, x.driver.FName , x.driver.LName })
                .Select(x=>new CarsRevenueReportLayout{ CarName = x.Key.CarName, DriverName = x.Key.FName + " " + x.Key.LName , Cash = (double)x.Sum(y=>y.route.Price)  })
                ;

            CarsRevenueReportLayoutBindingSource.DataSource = query.ToList();
            this.reportViewer1.RefreshReport();

        }
    }
}
