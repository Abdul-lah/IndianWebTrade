using System;
using System.Collections.Generic;

namespace DAL.IndianTradeDb
{
    public partial class MstUserRole
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public string RoleName { get; set; }
    }
}
