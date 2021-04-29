using System;
using System.Collections.Generic;

namespace DAL.IndianTradeDb
{
    public partial class TblItem
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public bool? IsDelete { get; set; }
        public string Discription { get; set; }
        public int? CategoryId { get; set; }
        public int? SellerId { get; set; }
        public bool? IsAvailable { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ImageUrl { get; set; }

        public virtual MstCatogery Category { get; set; }
        public virtual TblUser Seller { get; set; }
    }
}
