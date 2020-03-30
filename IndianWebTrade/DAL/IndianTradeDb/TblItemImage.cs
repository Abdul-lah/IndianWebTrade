using System;
using System.Collections.Generic;

namespace DAL.IndianTradeDb
{
    public partial class TblItemImage
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public string ImageUrl { get; set; }
    }
}
