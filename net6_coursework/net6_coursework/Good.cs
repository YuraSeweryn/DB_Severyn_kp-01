using System;
using System.Collections.Generic;

#nullable disable

namespace net6_coursework
{
    public partial class Good
    {
        public Good()
        {
            Availabilities = new HashSet<Availability>();
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
