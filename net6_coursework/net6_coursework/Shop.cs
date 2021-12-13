using System;
using System.Collections.Generic;

#nullable disable

namespace net6_coursework
{
    public partial class Shop
    {
        public Shop()
        {
            Availabilities = new HashSet<Availability>();
        }

        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<Availability> Availabilities { get; set; }
    }
}
