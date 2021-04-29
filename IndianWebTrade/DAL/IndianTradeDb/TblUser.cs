using System;
using System.Collections.Generic;

namespace DAL.IndianTradeDb
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblItem = new HashSet<TblItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public int? RoleId { get; set; }
        public string MobileNo { get; set; }
        public bool? IsSeller { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TblItem> TblItem { get; set; }
    }
}
