using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.Triggers;
using Taxi.Models;
using Taxi.Componenets;

namespace Taxi.Masters
{
    public partial class Crud : Habil
    {
        public MainModel db = new MainModel();

        public enum Mode
        {
            Select,
            Update,
            Delete
        }

        private Mode currentMode;

        public Mode CurrentMode
        {
            get
            {
                return currentMode;
            }
            set
            {
                switch (value)
                {

                    case Mode.Select:
                        label3.Text = "حالت جدید";
                        SelectedId = null;
                        RexaBind();
                        break;
                    case Mode.Update:
                        label3.Text = "حالت ویرایش";
                        break;
                    case Mode.Delete:
                        label3.Text = "هشدار!!! حذف";
                        break;
                }

                currentMode = value;

            }
        }


        public Crud()
        {
            InitializeComponent();
        }

        private void Crud_Load(object sender, EventArgs e)
        {
            CurrentMode = Mode.Select;

        }


        /// <summary>
        /// شناسه ی انتخاب شده توسط کاربر روی گرید
        /// </summary>
        public int? SelectedId { get; set; }

        /// <summary>
        /// اعمال تغییرات
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Done_Click(object sender, EventArgs e)
        {
            switch (CurrentMode)
            {

                case Mode.Select:
                    RexaInsert();
                    break;
                case Mode.Update:
                    RexaUpdate();
                    break;
                case Mode.Delete:
                    RexaDelete();
                    break;

            }
        }

        /// <summary>
        /// انتخاب توسط کاربر
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void RexaSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
                SelectedId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);
            else return;

            switch (e.ColumnIndex)
            {

                case 0:
                    CurrentMode = Mode.Update;
                    break;
                case 1:
                    CurrentMode = Mode.Delete;
                    break;

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RexaSelect();
        }

        public virtual void RexaBind()
        { 
        }

        /// <summary>
        /// When on insert
        /// </summary>
        public virtual void RexaInsert()
        {
            CurrentMode = Mode.Select;
            new RexaMessage("رکورد با موفقیت اضافه شد").ShowDialog();
        }

        /// <summary>
        /// When on new form or cancel
        /// </summary>
        public virtual void RexaSelect()
        {
            CurrentMode = Mode.Select;
        }
        /// <summary>
        /// When update done
        /// </summary>
        public virtual void RexaUpdate()
        {
            CurrentMode = Mode.Select;
            new RexaMessage("رکورد با موفقیت به روز رسانی شد").ShowDialog();
        }
        /// <summary>
        /// When delete done
        /// </summary>
        public virtual void RexaDelete()
        {
            CurrentMode = Mode.Select;
            new RexaMessage("رکورد با موفقیت حذف شد").ShowDialog();
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            var the_source = ((IEnumerable<object>)dataGridView1.DataSource);
            label1.Text = the_source.Count().ToString();
        }
    }
}
