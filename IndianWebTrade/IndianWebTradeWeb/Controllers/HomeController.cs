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
using INFASTRUCTURE.Model;
using INFASTRUCTURE.Dto;

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
            //result = _IItem.getAllItem();
            List<ItemDto> items = _IItem.getAllItem();
            List<ItemModel> modelList = new List<ItemModel>();

            foreach (var item in items)
            {
                ItemModel model = new ItemModel
                {
                    Discription = item.Discription,
                    Id = item.Id,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Image = item.Image,
                    Name = item.Name,
                    SellerId = item.SellerId,
                };
                modelList.Add(model);

            }


            return View(modelList);
        }

        public string AddTocart(CartViewModel model)
        {
            var userId = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);

            try
            {

                if (ModelState.IsValid)
                {
                    List<ItemDto> items = _IItem.getAllItem();
                    var item = items.Where(w => w.Id==model.ItemId).FirstOrDefault();
                    var result = _IItem.AddTocart(new CartDto
                    {
                        ItemId = model.ItemId,
                        Quantity = model.Quantity,
                        UserId = userId,
                        PricePerItem = Convert.ToInt32(item.Price)
                    });
                    return result.Id.ToString();
                }
                return "Model not valid";
            }
            catch
            {
                throw;
            }

        }
        public string RemoveTocart(int cartId)
        {
            try
            {
                if (cartId > 0)
                {
                    var userId = HttpContext.Request.Cookies["user_id"];

                    var data = _IItem.RemoveFromCart(cartId, Convert.ToInt32(userId));

                    return data ? "Item removed from cart" : "item does not remove from cart";
                }
                else
                {
                    return "please send valid cart id ";

                }
            }
            catch
            {
                return "server error";
            }
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
