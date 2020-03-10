using System;
using System.Collections.Generic;

namespace DAL.DAL
{
    public partial class TblMsg
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Message { get; set; }
        public bool IsDelete { get; set; }
    }
}
