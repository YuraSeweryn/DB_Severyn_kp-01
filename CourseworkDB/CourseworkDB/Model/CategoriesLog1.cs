using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB
{
    public partial class CategoriesLog1
    {
        public CategoriesLog1(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public static implicit operator CategoriesLog1(Category d) => new CategoriesLog1(d.CategoryId, d.Name);

        [Key]

        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
