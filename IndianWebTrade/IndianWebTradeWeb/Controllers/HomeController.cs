using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IndianWebTradeWeb.Models;
using Service.Interface;
using INFASTRUCTURE.GernalResult;

namespace IndianWebTradeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItem _IItem;

        public HomeController(ILogger<HomeController> logger, IItem item)
        {
            _logger = logger;
            _IItem = item;
        }

        public IActionResult Index()
        {
            IGernalResult result = new GernalResult();
            result = _IItem.getAllItem();
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
