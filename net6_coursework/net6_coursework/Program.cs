using System;
using Npgsql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace net6_coursework
{
    class Program
    {
        static void Main(string[] args)
        {
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


        }
    }
}
