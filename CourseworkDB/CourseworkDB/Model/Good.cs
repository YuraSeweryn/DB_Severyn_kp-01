using System;
using System.Collections.Generic;


namespace CourseworkDB
{
    public partial class Good
    {
        public Good()
        {
            Availabilities = new HashSet<Availability>();
        }

        public Good(int goodId, string name, string comment, int categoryId, string barcode)
        {
            GoodId = goodId;
            Name = name;
            Comment = comment;
            CategoryId = categoryId;
            Barcode = barcode;
        }

        public int GoodId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int CategoryId { get; set; }
        public string Barcode { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
    }
}
