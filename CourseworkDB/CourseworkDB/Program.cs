using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseworkDB
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            /*
            using (course_dbContext db = new course_dbContext())
            {
                Category cat1 = new Category { Name = "Fruits"};
                Good good1 = new Good { Name = "Ananas", Comment = "So so", CategoryId = 1, Barcode = "abobus" };
                db.Categories.Add(cat1);
                db.Goods.Add(good1);
                db.SaveChanges();
            }

            using (course_dbContext db = new course_dbContext())
            {
                var categories = db.Categories.ToListAsync().Result;
                var goods = db.Goods.ToListAsync().Result;
                Console.ReadKey();
            }
            */
        }
    }
}
