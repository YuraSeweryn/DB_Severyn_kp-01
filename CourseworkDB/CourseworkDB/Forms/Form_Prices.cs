using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CourseworkDB
{
    public partial class Form_Prices : Form
    {
        bool isCreatingEntity = false;
        Price temporary;

        public Form_Prices()
        {
            InitializeComponent();

            using (dbContext db = new dbContext())
            {
                var availableList = db.Availabilities.Include(c => c.Shop).Include(c => c.Good);

                var data = availableList.Select(f => f.AvailableId.ToString()).ToList();
                var column = new DataGridViewComboBoxColumn(); column.HeaderText = "AvailableID";
                column.DataSource = data;
                dataGridView.Columns.Insert(3, column);
            }
            GetData();
        }
        void GetData()
        {

            using (dbContext db = new dbContext())
            {
                var pricesList = db.Prices.Include(c => c.Available.Shop).Include(c => c.Available.Good).ToList();
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

                foreach (var a in pricesList)
                {
                    dataGridView.Rows.Add(a.PriceId, a.Date.ToShortDateString(), a.Price1, a.AvailableId.ToString(), a.Available.Shop.Name, a.Available.Shop.Adress, a.Available.Good.Name, "Delete");
                }
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[1].Value != null &&
                dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[2].Value != null &&
                dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[3].Value != null)
            {
                if (decimal.TryParse(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString(), out decimal a) &&
                    DateTime.TryParse(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString(), out DateTime d))
                {

                    using (dbContext db = new dbContext())
                    {
                        if (!isCreatingEntity)
                        {
                            var result = db.Prices.SingleOrDefault(b => b.PriceId == temporary.PriceId);
                            if (result != null)
                            {
                                result.Date = d;
                                result.Price1 = a;
                                result.AvailableId = db.Availabilities.ToList().Find(c => c.AvailableId.ToString() == (string)dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[3].Value).AvailableId;

                                db.SaveChanges();
                                GetData();
                            }
                        }
                        else
                        {
                            db.Prices.Add(new Price
                            {
                                Date = Convert.ToDateTime(dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[1].Value),
                                Price1 = Convert.ToDecimal((string)dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[2].Value),
                                AvailableId = db.Availabilities.ToList().Find(c => c.AvailableId.ToString() == (string)dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[3].Value).AvailableId
                            });
                            db.SaveChanges();
                            GetData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Date or price are invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var t = new Price{
                        PriceId = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value,
                        Date = Convert.ToDateTime(dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[1].Value),
                        Price1 = ((decimal)dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[2].Value),
                        AvailableId = db.Availabilities.ToList().Find(c => c.AvailableId.ToString() == (string)dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[3].Value).AvailableId
                        };db.PricesLogs.Add(t);

                    db.Prices.Remove(t);
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
                    temporary = new Price
                    {
                        PriceId = (int)dataGridView.Rows[e.RowIndex].Cells[0].Value,
                        Date = Convert.ToDateTime(dataGridView.Rows[e.RowIndex].Cells[1].Value),
                        Price1 = ((decimal)dataGridView.Rows[e.RowIndex].Cells[2].Value),
                        AvailableId = db.Availabilities.ToList().Find(c => c.AvailableId.ToString() == (string)dataGridView.Rows[e.RowIndex].Cells[3].Value).AvailableId
                    };
                }
            }
        }
    }
}
