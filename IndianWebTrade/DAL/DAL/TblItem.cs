using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class TblItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int? SellerId { get; set; }
    }
}
