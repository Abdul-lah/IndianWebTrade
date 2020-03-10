using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class TblSeller
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerEmail { get; set; }
        public string SellerImageUrl { get; set; }
        public string SellerAddress { get; set; }
    }
}
