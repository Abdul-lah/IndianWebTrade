using IndianWebTradeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndianWebTradeWeb.Controllers
{
    public class SellerController : Controller
    {
     
        private readonly IItem _ProductItem;

        public SellerController( IItem item)
        {
            _ProductItem = item;
        }


        public IActionResult AddProductItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProductItem(ProductItemViewModel model)
        {
            return View();
        }

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
