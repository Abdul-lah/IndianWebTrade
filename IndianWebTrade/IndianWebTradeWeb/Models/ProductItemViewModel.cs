using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndianWebTradeWeb.Models
{

    public class ProductItemViewModel
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string SellerId { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public int? CatogeryId { get; set; }
        public bool? IsDelete { get; set; }
        public string Discription { get; set; }
        public List<string> ImageUrl { get; set; }
    }
}
