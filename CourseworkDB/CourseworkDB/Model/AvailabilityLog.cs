using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB
{
    public partial class AvailabilityLog
    {
        public AvailabilityLog(int availableId, int goodId, int shopId, int amount)
        {
            AvailableId = availableId;
            GoodId = goodId;
            ShopId = shopId;
            Amount = amount;
        }

        public static implicit operator AvailabilityLog(Availability d) => new AvailabilityLog(d.AvailableId, d.GoodId, d.ShopId, d.Amount);

        [Key]
        public int AvailableId { get; set; }
        public int GoodId { get; set; }
        public int ShopId { get; set; }
        public int Amount { get; set; }
    }
}
