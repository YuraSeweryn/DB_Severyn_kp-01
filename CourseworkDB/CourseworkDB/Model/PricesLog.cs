using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB
{
    public partial class PricesLog
    {
        public PricesLog(int priceId, int availableId, DateTime date, decimal price)
        {
            PriceId = priceId;
            AvailableId = availableId;
            Date = date;
            Price = price;
        }

        public static implicit operator PricesLog(Price d) => new PricesLog(d.PriceId, d.AvailableId, d.Date, d.Price1);

        [Key]
        public int PriceId { get; set; }
        public int AvailableId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
