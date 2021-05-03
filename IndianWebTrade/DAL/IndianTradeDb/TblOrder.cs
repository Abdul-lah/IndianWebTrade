using System;
using System.Collections.Generic;

namespace DAL.IndianTradeDb
{
    public partial class TblOrder
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public int PricePerItem { get; set; }
        public int PriceTotal { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual TblItem Item { get; set; }
        public virtual TblUser User { get; set; }
    }
}
