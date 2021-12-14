using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CourseworkDB
{
    public partial class Form_Shops : Form
    {
        bool isCreatingEntity = false;
        Shop temporary;
        public Form_Shops()
        {
            InitializeComponent();
            GetData();
        }
        void GetData()
        {
            using (dbContext db = new dbContext())
            {

                var shopsList = db.Shops.ToList();
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
                    return;
                }
                foreach (var a in shopsList)
                {
                    dataGridView.Rows.Add(a.ShopId, a.Name, a.Adress, a.Rating.ToString(), "Delete");
                }
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[1].Value != null &&
                dataGridView.Rows[e.RowIndex].Cells[2].Value != null &&
                dataGridView.Rows[e.RowIndex].Cells[3].Value != null)
            {
                if (decimal.TryParse((string)dataGridView.Rows[e.RowIndex].Cells[3].Value, out decimal r))
                {

                    using (dbContext db = new dbContext())
                    {
                        if (!isCreatingEntity)
                        {
                            var result = db.Shops.SingleOrDefault(b => b.ShopId == temporary.ShopId);
                            if (result != null)
                            {
                                result.Name = (string)dataGridView.Rows[e.RowIndex].Cells[1].Value;
                                result.Adress = (string)dataGridView.Rows[e.RowIndex].Cells[2].Value;
                                result.Rating = r;

                                db.SaveChanges();
                            }
                            GetData();
                        }

                        else
                        {
                            db.Shops.Add(new Shop
                            {
                                Name = (string)dataGridView.Rows[e.RowIndex].Cells[1].Value,
                                Adress = (string)dataGridView.Rows[e.RowIndex].Cells[2].Value,
                                Rating = Convert.ToDecimal((string)dataGridView.Rows[e.RowIndex].Cells[3].Value)
                            });
                            db.SaveChanges();
                            GetData();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Rating must be decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var temp = new Shop((int)dataGridView.Rows[e.RowIndex].Cells[0].Value,
                        (string)dataGridView.Rows[e.RowIndex].Cells[1].Value,
                        (string)dataGridView.Rows[e.RowIndex].Cells[2].Value,
                        Convert.ToDecimal((string)dataGridView.Rows[e.RowIndex].Cells[3].Value));db.ShopsLogs.Add(temp);

                    var shopID = temp.ShopId;
                    db.Prices.RemoveRange(db.Prices.Include(t => t.Available).Where(t => t.Available.ShopId == shopID));
                    db.Availabilities.RemoveRange(db.Availabilities.Where(t => t.ShopId == shopID));
                    db.Shops.Remove(temp);

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
                    temporary = new Shop((int)dataGridView.Rows[e.RowIndex].Cells[0].Value,
                        (string)dataGridView.Rows[e.RowIndex].Cells[1].Value,
                        (string)dataGridView.Rows[e.RowIndex].Cells[2].Value,
                        Convert.ToDecimal((string)dataGridView.Rows[e.RowIndex].Cells[3].Value));
                }
            }
        }
    }
}
