using App.Triggers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taxi.Masters;

namespace Taxi
{
    public partial class Users : Crud
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PNG|*.png|JPG|*.jpg|JPG|*.jpg|همه ی فایل ها|*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackgroundImage = Image.FromFile(ofd.FileName);
            }
            else
            {
                throw new RexaException("تصویری انتخاب نشد");
            }
        }


        public override void RexaSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            base.RexaSelect_CellContentClick(sender, e);
            var user = db.tblUsers.Find(SelectedId);
            if (user != null)
            {
                textBox1.Text = user.FName;
                textBox2.Text = user.LName;
                textBox3.Text = user.Address;
                textBox4.Text = user.Tellnumber;
                textBox5.Text = user.PhoneNumber;
                textBox6.Text = user.Username;
                textBox7.Text = user.Password;
                comboBox1.Text = user.UserType;
                pictureBox2.BackgroundImage = new Bitmap(new MemoryStream(user.Picture, 0, user.Picture.Length));
            }
        }
        public override void RexaSelect()
        {

            textBox1.Text =
            textBox2.Text =
            textBox3.Text =
            textBox4.Text =
            textBox5.Text =
            textBox6.Text =
            textBox7.Text =
             string.Empty;

            pictureBox2.BackgroundImage = null;
            comboBox1.Text = "راننده";

            base.RexaSelect();

        }

        public byte[] ImageToByteArray(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public override void RexaInsert()
        {



            var user = new Models.tblUser
            {
                FName = textBox1.Text,
                LName = textBox2.Text,
                Address = textBox3.Text,
                Tellnumber = textBox4.Text,
                PhoneNumber = textBox5.Text,
                Username = textBox6.Text,
                Password = textBox7.Text,
                UserType = comboBox1.Text,
                Picture = ImageToByteArray(pictureBox2.BackgroundImage),

            };
            new RexaValidator(user);
            db.tblUsers.Add(user);
            db.SaveChanges();
            base.RexaInsert();
        }
        public override void RexaUpdate()
        {
            var user = db.tblUsers.Find(SelectedId);

            user.FName = textBox1.Text;
            user.LName = textBox2.Text;
            user.Address = textBox3.Text;
            user.Tellnumber = textBox4.Text;
            user.PhoneNumber = textBox5.Text;
            user.Username = textBox6.Text;
            user.Password = textBox7.Text;
            user.UserType = comboBox1.Text;
            user.Picture = ImageToByteArray(pictureBox2.BackgroundImage);

            new RexaValidator(user);

            db.SaveChanges();
            base.RexaUpdate();
        }
        public override void RexaDelete()
        {
            var user = db.tblUsers.Find(SelectedId);
            db.tblUsers.Remove(user);
            db.SaveChanges();
            base.RexaDelete();
        }
        public override void RexaBind()
        {
            dataGridView1.DataSource = db.tblUsers.Select(x => new { x.ID, x.Picture, نام = x.FName + " " + x.LName, x.PhoneNumber, x.Tellnumber, x.UserType, x.Username }).ToList();
            dataGridView1.Refresh();
            (dataGridView1.Columns["Picture"] as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;
            base.RexaBind();
        }

    }
}
