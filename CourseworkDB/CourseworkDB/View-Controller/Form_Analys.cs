using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CourseworkDB
{
    public partial class Form_Analys : Form
    {
        public Form_Analys()
        {
            InitializeComponent();

            using (dbContext db = new dbContext())
            {
                comboBoxShops.DataSource = db.Shops.Select(f => f.Name + " | " + f.Adress).ToList();
            }
        }

        private void button_Analysis_Click(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                var popular = db.Availabilities.Include(t => t.Shop).Include(t => t.Good)
                    .Where(t => t.Shop.Name + " | " + t.Shop.Adress == (object)comboBoxShops.SelectedItem)
                    .OrderByDescending(t => t.Amount).First();
                richTextBoxGood.Text += $"\n\n\"{popular.Good.Name}\" in {popular.Amount} copies.";

                var vategory = db.Availabilities.Include(t => t.Shop).Include(t => t.Good)
                    .Where(t => t.Shop.Name + " | " + t.Shop.Adress == (object)comboBoxShops.SelectedItem)
                    .ToList();

                var dict = new Dictionary<int, int>();
                foreach(var a in vategory)
                {
                    if(!dict.ContainsKey(a.Good.CategoryId))
                    {
                        dict.Add(a.Good.CategoryId, a.Amount);
                    }
                    else
                    {
                        dict[a.Good.CategoryId] += a.Amount;
                    }
                }
                (int, int) temp = (0, 0);
                foreach(var a in dict)
                {
                    if (a.Value > temp.Item2)
                    {
                        temp.Item2 = a.Value;
                        temp.Item1 = a.Key;
                    }

                }
                richTextBoxCategory.Text += $"\n\nThe most popular category is \"{db.Categories.Single(t => t.CategoryId == temp.Item1).Name}\" in amount of {temp.Item2}.";
            }
            richTextBoxGood.Visible = true;
            richTextBoxCategory.Visible = true;

        }
    }
}
