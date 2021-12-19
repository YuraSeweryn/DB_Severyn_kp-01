using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CourseworkDB
{
    public partial class Form_Availabilities : Form
    {
        bool isCreatingEntity = false;
        Availability temporary;
        public Form_Availabilities()
        {
            InitializeComponent();

            using (dbContext db = new dbContext())
            {
                List<string> data = db.Goods.Select(f => f.Name).Distinct().ToList();
                var column = new DataGridViewComboBoxColumn(); column.HeaderText = "Good";
                column.DataSource = data;
                column.Width = 175;
                dataGridView.Columns.Insert(2, column);

                List<string> data2 = db.Shops.Select(f => f.Name).Distinct().ToList();
                var column2 = new DataGridViewComboBoxColumn(); column2.HeaderText = "Shop";
                column2.DataSource = data2;
                column2.Width = 175;

                dataGridView.Columns.Insert(3, column2);

            }
            GetData();
        }
        void GetData()
        {
            using (dbContext db = new dbContext())
            {
                var availabilitiesList = db.Availabilities.Include(c => c.Good).Include(c => c.Shop).ToList();
                dataGridView.DataSource = null;
                try
                {
                    if (dataGridView.CurrentCell != null)
                    {
                        dataGridView.CurrentCell.Selected = false;
                    }
                    dataGridView.Rows.Clear();
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Press Enter to finish editing.", "Enter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Close();
                    return;
                }

                foreach (var a in availabilitiesList)
                {
                    dataGridView.Rows.Add(a.AvailableId, a.Amount, a.Good.Name, a.Shop.Name, "Delete");
                }
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView.Rows[e.RowIndex].Cells[1].Value != null &&
                dataGridView.Rows[e.RowIndex].Cells[2].Value != null &&
                dataGridView.Rows[e.RowIndex].Cells[3].Value != null)
            {
                if (int.TryParse((string)dataGridView.Rows[e.RowIndex].Cells[1].Value, out int a))
                {
                    using (dbContext db = new dbContext())
                    {
                        if (!isCreatingEntity)
                        {
                            var result = db.Availabilities.SingleOrDefault(b => b.AvailableId == temporary.AvailableId);
                            if (result != null)
                            {
                                result.Amount = a;
                                result.GoodId = db.Goods.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[2].Value).GoodId;
                                result.ShopId = db.Shops.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[3].Value).ShopId;

                                db.SaveChanges();
                                GetData();
                            }
                        }
                        else
                        {
                            db.Availabilities.Add(new Availability
                            {
                                Amount = Convert.ToInt32((string)dataGridView.Rows[e.RowIndex].Cells[1].Value),
                                GoodId = db.Goods.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[2].Value).GoodId,
                                ShopId = db.Shops.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[3].Value).ShopId,
                            });
                            db.SaveChanges();
                            GetData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Amount must be integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GetData();
                }

            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                using (dbContext db = new dbContext())
                {
                    var temp = new Availability
                    {AvailableId = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value,
                        Amount = Convert.ToInt32((string)dataGridView.Rows[e.RowIndex].Cells[1].Value),
                        GoodId = db.Goods.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[2].Value).GoodId,
                        ShopId = db.Shops.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[3].Value).ShopId};db.AvailabilityLogs.Add(temp);

                    var availableID = temp.AvailableId;
                    db.Prices.RemoveRange(db.Prices.Where(t => t.AvailableId == availableID));
                    db.Availabilities.Remove(temp);

                    db.SaveChanges();
                }
                GetData();
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[0].Value == null)
            {
                isCreatingEntity = true;
            }
            else
            {
                using (dbContext db = new dbContext())
                {
                    isCreatingEntity = false;
                    temporary = new Availability
                    {
                        AvailableId = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value,
                        Amount = (int)dataGridView.Rows[e.RowIndex].Cells[1].Value,
                        GoodId = db.Goods.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[2].Value).GoodId,
                        ShopId = db.Shops.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[3].Value).ShopId
                    };
                }
            }
        }
    }
}
