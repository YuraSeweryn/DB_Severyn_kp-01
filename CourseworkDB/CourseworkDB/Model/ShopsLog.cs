using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB
{
    public partial class ShopsLog
    {
        public ShopsLog(int shopId, string name, string adress, decimal rating)
        {
            ShopId = shopId;
            Name = name;
            Adress = adress;
            Rating = rating;
        }

        public static implicit operator ShopsLog(Shop d) => new ShopsLog(d.ShopId, d.Name, d.Adress, d.Rating);

        [Key]
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public decimal Rating { get; set; }
    }
}
