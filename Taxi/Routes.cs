
using App.Triggers;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Taxi.Masters;


namespace Taxi
{
    public partial class Routes : Crud
    {
        public Routes()
        {
            InitializeComponent();
        }

        private void Routes_Load(object sender, EventArgs e)
        {
        }

        public override void RexaSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            base.RexaSelect_CellContentClick(sender, e);
            var route = db.tblRoutes.Find(SelectedId);
            if (route != null)
            {
                textBox1.Text = route.DestinationName;
                textBox2.Text = route.Price.ToString();
            }
        }
        public override void RexaSelect()
        {

            textBox1.Text =
                textBox2.Text =
                string.Empty;

            base.RexaSelect();

        }
        public override void RexaInsert()
        {
            var route = new Models.tblRoute
            {
                DestinationName = textBox1.Text,
                Price = decimal.Parse(textBox2.Text)
            };
            new RexaValidator(route);
            db.tblRoutes.Add(route);
            db.SaveChanges();
            base.RexaInsert();
        }
        public override void RexaUpdate()
        {
            var route = db.tblRoutes.Find(SelectedId);

            route.DestinationName = textBox1.Text;
            route.Price = decimal.Parse(textBox2.Text);

            new RexaValidator(route);
            db.SaveChanges();
            base.RexaUpdate();
        }
        public override void RexaDelete()
        {
            var route = db.tblRoutes.Find(SelectedId);
            db.tblRoutes.Remove(route);
            db.SaveChanges();
            base.RexaDelete();
        }
        public override void RexaBind()
        {
            dataGridView1.DataSource = db.tblRoutes.Select(x => new { x.ID, x.DestinationName, x.Price }).ToList();
            dataGridView1.Refresh();
            base.RexaBind();
        }

    }
}
