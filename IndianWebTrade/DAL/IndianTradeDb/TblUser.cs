using System;
using System.Collections.Generic;

namespace DAL.IndianTradeDb
{
    public partial class TblUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public int? Role { get; set; }
    }
}
