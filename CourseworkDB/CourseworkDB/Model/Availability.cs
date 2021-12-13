using System;
using System.Collections.Generic;


namespace CourseworkDB
{
    public partial class Availability
    {
        public Availability()
        {
            Prices = new HashSet<Price>();
        }

        public Availability(int availableId, int goodId, int shopId, int amount)
        {
            AvailableId = availableId;
            GoodId = goodId;
            ShopId = shopId;
            Amount = amount;
        }

        public int AvailableId { get; set; }
        public int GoodId { get; set; }
        public int ShopId { get; set; }
        public int Amount { get; set; }

        public virtual Good Good { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
