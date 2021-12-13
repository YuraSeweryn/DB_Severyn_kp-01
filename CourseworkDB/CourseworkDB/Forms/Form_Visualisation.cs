using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;


namespace CourseworkDB
{
    public partial class Form_Visualisation : Form
    {
        public Form_Visualisation()
        {
            InitializeComponent();

            using (dbContext db = new dbContext())
            {
                comboBoxGood.DataSource = db.Goods.Select(f => f.Name).ToList();
                comboBoxShop.DataSource = db.Availabilities.Include(c => c.Shop).Include(c => c.Good)
                    .Where(f => f.Good.Name == (string)comboBoxGood.SelectedValue)
                    .Select(f => f.Shop.Name + " | " + f.Shop.Adress).ToList();

            }

        }

        private void comboBoxGood_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                comboBoxShop.DataSource = db.Availabilities.Include(c => c.Shop).Include(c=>c.Good)
                    .Where(f => f.Good.Name == (string)comboBoxGood.SelectedItem)
                    .Select(f => f.Shop.Name + " | " + f.Shop.Adress).ToList();
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Series.Add("Price");
            chart1.Series["Price"].BorderWidth = 3;
            chart1.Series["Price"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            using (dbContext db = new dbContext())
            {
                var data = db.Prices.Include(i => i.Available.Good).Include(i => i.Available.Shop)
                    .Where(f => f.Available.Good.Name == (string)comboBoxGood.SelectedItem)
                    .Where(f => (f.Available.Shop.Name + " | " + f.Available.Shop.Adress) == (string)comboBoxShop.SelectedItem).ToList();

                foreach (var a in data)
                {
                    chart1.Series["Price"].Points.AddXY(a.Date.ToShortDateString(), a.Price1.ToString());
                }
            }
        }
    }
}
