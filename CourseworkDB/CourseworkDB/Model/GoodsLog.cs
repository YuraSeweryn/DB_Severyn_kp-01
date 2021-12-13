using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseworkDB
{
    public partial class GoodsLog
    {
        public GoodsLog(int goodId, string name, string comment, int categoryId, string barcode)
        {
            GoodId = goodId;
            Name = name;
            Comment = comment;
            CategoryId = categoryId;
            Barcode = barcode;
        }

        public static implicit operator GoodsLog(Good d) => new GoodsLog(d.GoodId, d.Name, d.Comment, d.CategoryId, d.Barcode);

        [Key]

        public int GoodId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public int CategoryId { get; set; }
        public string Barcode { get; set; }
    }
}
