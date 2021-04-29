using System;
using System.Collections.Generic;

namespace DAL.IndianTradeDb
{
    public partial class MstCatogery
    {
        public MstCatogery()
        {
            TblItem = new HashSet<TblItem>();
        }

        public int Id { get; set; }
        public string CatogeryName { get; set; }

        public virtual ICollection<TblItem> TblItem { get; set; }
    }
}
