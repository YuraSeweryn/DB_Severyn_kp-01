using System;
using System.Linq;
using System.Windows.Forms;

namespace CourseworkDB
{
    public partial class Form_Categories : Form
    {
        bool isCreatingEntity = false;
        Category temporary;

        public Form_Categories()
        {
            InitializeComponent();
            GetData();
        }

        void GetData()
        {
            using (dbContext db = new dbContext())
            {
                var categoriesList = db.Categories;
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
                foreach (var a in categoriesList)
                {
                    dataGridView.Rows.Add(a.CategoryId, a.Name, "Delete");
                }
            }
        }


        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string t = (string)dataGridView.Rows[e.RowIndex].Cells[1].Value;
            if (t != "")
            {
                using (dbContext db = new dbContext())
                {
                    if (!db.Categories.Select(f => f.Name).ToList().Contains(t))
                    {
                        if (!isCreatingEntity)
                        {
                            var result = db.Categories.SingleOrDefault(b => b.CategoryId == temporary.CategoryId);
                            if (result != null)
                            {
                                result.Name = (string)dataGridView.Rows[e.RowIndex].Cells[1].Value;
                                db.SaveChanges();
                                GetData();
                            }
                        }
                        else
                        {
                            db.Categories.Add(new Category { Name = (string)dataGridView.Rows[e.RowIndex].Cells[1].Value });
                            db.SaveChanges();
                            GetData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Category name already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    var t = new Category((int)dataGridView.Rows[e.RowIndex].Cells[0].Value, (string)dataGridView.Rows[e.RowIndex].Cells[1].Value); db.CategoriesLogs1.Add(t);
                    db.Categories.Remove(t); 
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
                isCreatingEntity = false;
                temporary = new Category((int)dataGridView.Rows[e.RowIndex].Cells[0].Value, (string)dataGridView.Rows[e.RowIndex].Cells[1].Value);
            }
        }
    }
}
