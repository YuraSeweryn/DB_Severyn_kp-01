﻿using System;
using System.Collections.Generic;

#nullable disable

namespace net6_coursework
{
    public partial class Price
    {
        public int PriceId { get; set; }
        public int AvailableId { get; set; }
        public DateTime Date { get; set; }
        public decimal Price1 { get; set; }

        public virtual Availability Available { get; set; }
    }
}
