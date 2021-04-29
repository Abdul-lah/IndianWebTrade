using System;
using System.Collections.Generic;

namespace DAL.IndianTradeDb
{
    public partial class TblCart
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string PricePerItem { get; set; }
        public string TotalPrice { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual TblItem Item { get; set; }
        public virtual TblUser User { get; set; }
    }
}
