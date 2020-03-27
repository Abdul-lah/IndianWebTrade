using System;
using System.Collections.Generic;
using System.Text;

namespace INFASTRUCTURE.Dto
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int? SellerId { get; set; }
    }
    public  class SellerDto
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerEmail { get; set; }
        public string SellerImageUrl { get; set; }
        public string SellerAddress { get; set; }
    }

}
