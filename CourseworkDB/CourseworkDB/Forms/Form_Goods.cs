using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CourseworkDB
{
    public partial class Form_Goods : Form
    {
        bool isCreatingEntity = false;
        Good temporary;
        public Form_Goods()
        {
            InitializeComponent();

            using (dbContext db = new dbContext())
            {
                List<string> data = db.Categories.Select(f => f.Name).Distinct().ToList();
                var column = new DataGridViewComboBoxColumn(); column.HeaderText = "Category";
                column.DataSource = data;
                dataGridView.Columns.Insert(3, column);
            }
            GetData();
        }
        void GetData()
        {
            using (dbContext db = new dbContext())
            {
                var goodsList = db.Goods.ToList();
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

                foreach (var a in goodsList)
                {
                    dataGridView.Rows.Add(a.GoodId, a.Name, a.Comment, (string)db.Categories.ToList().Find(c => c.CategoryId == a.CategoryId).Name, a.Barcode, "Delete");
                }
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string n = (string)dataGridView.Rows[e.RowIndex].Cells[1].Value;
            string b = (string)dataGridView.Rows[e.RowIndex].Cells[4].Value;

            if (n != null && b != null && dataGridView.Rows[e.RowIndex].Cells[4].Value != null)
            {
                using (dbContext db = new dbContext())
                {
                    if (!db.Goods.Select(f => f.Barcode).ToList().Contains(b))
                    {
                        if (!isCreatingEntity)
                        {
                            var result = db.Goods.SingleOrDefault(d => d.GoodId == temporary.GoodId);
                            if (result != null)
                            {
                                result.Name = (string)dataGridView.Rows[e.RowIndex].Cells[1].Value;
                                result.Comment = (string)dataGridView.Rows[e.RowIndex].Cells[2].Value;
                                result.CategoryId = db.Categories.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[3].Value).CategoryId;
                                result.Barcode = (string)dataGridView.Rows[e.RowIndex].Cells[4].Value;

                                db.SaveChanges();
                                GetData();
                            }
                        }
                        else
                        {
                            db.Goods.Add(new Good
                            {
                                Name = (string)dataGridView.Rows[e.RowIndex].Cells[1].Value,
                                Comment = (string)dataGridView.Rows[e.RowIndex].Cells[2].Value,
                                CategoryId = db.Categories.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[3].Value).CategoryId,
                                Barcode = (string)dataGridView.Rows[e.RowIndex].Cells[4].Value
                            });
                            db.SaveChanges();
                            GetData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Good Barcode already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        GetData();
                    }

                }
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView[e.ColumnIndex, e.RowIndex] is DataGridViewButtonCell)
            {
                using (dbContext db = new dbContext())
                {
                    var temp = new Good((int)dataGridView.Rows[e.RowIndex].Cells[0].Value,
                        (string)dataGridView.Rows[e.RowIndex].Cells[1].Value,
                        (string)dataGridView.Rows[e.RowIndex].Cells[2].Value,
                        db.Categories.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[3].Value).CategoryId,
                        (string)dataGridView.Rows[e.RowIndex].Cells[4].Value);db.GoodsLogs.Add(temp);

                    var goodID = temp.GoodId;
                    db.Prices.RemoveRange(db.Prices.Include(t => t.Available).Where(t => t.Available.GoodId == goodID));
                    db.Availabilities.RemoveRange(db.Availabilities.Where(t => t.GoodId == goodID));
                    db.Goods.Remove(temp);


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
                    temporary = new Good((int)dataGridView.Rows[e.RowIndex].Cells[0].Value,
                            (string)dataGridView.Rows[e.RowIndex].Cells[1].Value,
                            (string)dataGridView.Rows[e.RowIndex].Cells[2].Value,
                            db.Categories.ToList().Find(c => c.Name == (string)dataGridView.Rows[e.RowIndex].Cells[3].Value).CategoryId,
                            (string)dataGridView.Rows[e.RowIndex].Cells[4].Value);
                }
            }
        }
    }
}
