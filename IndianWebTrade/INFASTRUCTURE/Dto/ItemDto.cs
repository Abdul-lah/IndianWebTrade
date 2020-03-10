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

}
