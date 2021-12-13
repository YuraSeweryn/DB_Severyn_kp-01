using System;
using System.Collections.Generic;

#nullable disable

namespace net6_coursework
{
    public partial class Category
    {
        public Category()
        {
            Goods = new HashSet<Good>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
