using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB
{
    public partial class Category
    {
        public Category()
        {
            Goods = new HashSet<Good>();
        }

        public Category(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
