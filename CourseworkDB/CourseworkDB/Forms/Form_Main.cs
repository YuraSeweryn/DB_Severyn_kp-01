using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CourseworkDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread replicationThread = new Thread(Replication);
            replicationThread.IsBackground = true;
            replicationThread.Start();
            using (dbContext db = new dbContext())
            {
                db.SaveChanges();
            }


            Form_Categories f = new Form_Categories();
            f.Show();
            f.Close();
        }

        #region replica
        private void Replication()
        {
            try
            {

                if (Directory.Exists(@".\DB_replica(16466)"))
                {
                    Directory.Delete(@".\DB_replica(16466)", true);
                }
                Copy(@"C:\Program Files\PostgreSQL\12\data\base\16466", @".\DB_replica(16466)");
            }
            catch
            {

            }

            Thread.Sleep(10_000);
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        #endregion
        private void buttonClearData_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                using (dbContext db = new dbContext())
                {

                    db.RemoveRange(db.Prices);
                    db.RemoveRange(db.Availabilities);
                    db.RemoveRange(db.Goods);
                    db.RemoveRange(db.Shops);
                    db.RemoveRange(db.Categories);

                    db.Database.ExecuteSqlRaw("ALTER SEQUENCE prices_price_id_seq RESTART WITH 1;");
                    db.Database.ExecuteSqlRaw("ALTER SEQUENCE availability_available_id_seq RESTART WITH 1;");
                    db.Database.ExecuteSqlRaw("ALTER SEQUENCE goods_good_id_seq RESTART WITH 1;");
                    db.Database.ExecuteSqlRaw("ALTER SEQUENCE categories_category_id_seq RESTART WITH 1;");
                    db.SaveChanges();

                    db.SaveChanges();

                }
                MessageBox.Show("Database cleared", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region RandomGeneration
        private void button_Random_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            using (dbContext db = new dbContext())
            {
                if (!db.Categories.Select(f => f.Name).ToList().Contains("Fruit"))
                {
                    db.Categories.Add(new Category { Name = "Fruit" }); ;
                }
                db.SaveChanges();

                int categoryID = 1;
                categoryID = db.Categories.FirstOrDefault(f => f.Name == "Fruit").CategoryId;
                List<string> fruitsnames = new List<string> { "Orange", "Apple", "Peach", "Banana", "Apricot", "Grapefruit", "Lemon", "Pear", "Pineapple", "Plum" };

                for (int i = 0; i < 10; i++)
                {
                    if (!db.Goods.Select(f => f.Name).ToList().Contains(fruitsnames[i]))
                    {
                        db.Goods.Add(new Good(0, fruitsnames[i], "", categoryID, RandomString(10)));
                    }
                }
                db.SaveChanges();

                db.Shops.Add(new Shop(0, "ATB", "Kyiv, Chreschatyk 2", (decimal)9.9));
                db.SaveChanges();

                int shopID = db.Shops.FirstOrDefault(f => f.Name == "ATB").ShopId;
                var avList = new List<Availability>();
                for (int i = 0; i < 10; i++)
                {
                    avList.Add(new Availability(0, db.Goods.FirstOrDefault(f => f.Name == fruitsnames[i]).GoodId, shopID, random.Next(1, 1000)));
                }
                db.Availabilities.AddRange(avList);
                db.SaveChanges();


                for (int i = 0; i < 10; i++)
                {
                    var prices = new List<Price>();
                    decimal price = random.Next(10, 1000);
                    for (int j = 0; j < 5; j++)
                    {
                        price += random.Next(-100, 100);
                        prices.Add(new Price { AvailableId = avList[i].AvailableId, Date = new DateTime(DateTime.Now.Ticks - 1000000000000 * (j + 1)), Price1 = price });
                    }
                    db.Prices.AddRange(prices);
                    db.SaveChanges();
                }

                MessageBox.Show("Data succesfuly generated", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        #endregion

        #region Windows Openings
        private void button_Categories_Click(object sender, EventArgs e)
        {
            Form_Categories f = new Form_Categories();
            f.Show();
        }

        private void button_Goods_Click(object sender, EventArgs e)
        {
            Form_Goods f = new Form_Goods();
            f.Show();
        }

        private void button_Shops_Click(object sender, EventArgs e)
        {
            Form_Shops f = new Form_Shops();
            f.Show();
        }

        private void button_Availability_Click(object sender, EventArgs e)
        {
            Form_Availabilities f = new Form_Availabilities();
            f.Show();
        }

        private void button_Prices_Click(object sender, EventArgs e)
        {
            Form_Prices f = new Form_Prices();
            f.Show();
        }

        private void buttonVilualisation_Click(object sender, EventArgs e)
        {
            Form_Visualisation f = new Form_Visualisation();
            f.Show();
        }

        private void button_Analysis_Click(object sender, EventArgs e)
        {
            Form_Analys f = new Form_Analys();
            f.Show();
        }

        #endregion

    }
}
