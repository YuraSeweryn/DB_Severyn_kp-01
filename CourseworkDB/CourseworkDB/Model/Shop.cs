using System;
using System.Collections.Generic;


namespace CourseworkDB
{
    public partial class Shop
    {
        public Shop()
        {
            Availabilities = new HashSet<Availability>();
        }

        public Shop(int shopId, string name, string adress, decimal rating)
        {
            ShopId = shopId;
            Name = name;
            Adress = adress;
            Rating = rating;
        }

        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<Availability> Availabilities { get; set; }
    }
}
