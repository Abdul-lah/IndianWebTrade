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
using Microsoft.AspNetCore.Authorization;

namespace IndianWebTradeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItem _IItem;
        private readonly IMasterService _MasterService;
        public HomeController(ILogger<HomeController> logger, IItem item, IMasterService masterService)
        {
            _logger = logger;
            _IItem = item;
            _MasterService = masterService;
        }

        public IActionResult Index(SortModel model)
        {
            ViewBag.categories = _MasterService.GetCategories().Select(s => new CategoryDto
            {
                Id = s.Id,
                CatogeryName = s.CatogeryName
            });

            IGernalResult result = new GernalResult();
            //result = _IItem.getAllItem();
            List<ItemDto> items = _IItem.getAllItem();
            List<ItemModel> modelListFilter = new List<ItemModel>();
            List<ItemModel> modelList = new List<ItemModel>();
            foreach (var item in items)
            {
                ItemModel viewmodel = new ItemModel
                {
                    Discription = item.Discription,
                    Id = item.Id,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Image = item.Image,
                    Name = item.Name,
                    SellerId = item.SellerId,
                    CategoryId = item.CatogeryId,
                };
                modelList.Add(viewmodel);
            }
            if (model.PriceFilter == "desc")
            {
                modelListFilter = modelList.OrderByDescending(x => Convert.ToInt32(x.Price)).ToList();
            }
            if (model.PriceFilter == "asec")
            {
                modelListFilter = modelList.OrderBy(x => Convert.ToInt32(x.Price)).ToList();

            }
            if (model.CategoryId > 0)
            {
                modelListFilter = modelList.Where(x => x.CategoryId == model.CategoryId).ToList();
            }
            if (model.PriceFilter != null || model.CategoryId > 0)
            {
                return PartialView("_ProductItem", modelListFilter);
            }
            return View(modelList);
        }

        [Authorize(Roles = "Custumer")]
        public JsonResult AddTocart(CartViewModel model)
        {
            var userId = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);
            if (userId == 0)
            {
                return null;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    List<ItemDto> items = _IItem.getAllItem();
                    var item = items.Where(w => w.Id == model.ItemId).FirstOrDefault();
                    var result = _IItem.AddTocart(new CartDto
                    {
                        ItemId = model.ItemId,
                        Quantity = model.Quantity,
                        UserId = userId,
                        PricePerItem = Convert.ToInt32(item.Price)
                    });
                    return Json(result.Id);
                }

            }
            catch
            {
                throw;
            }
            return null;
        }
        [Authorize(Roles = "Custumer")]
        public JsonResult RemoveTocart(int cartId)
        {
            IGernalResult result = new GernalResult();
            try
            {
                if (cartId > 0)
                {
                    var userId = HttpContext.Request.Cookies["user_id"];
                    var data = _IItem.RemoveFromCart(cartId, Convert.ToInt32(userId));
                    result.Message = data ? "Item removed from cart" : "item does not remove from cart";
                    result.Succsefully = data ? true : false;
                }
                else
                {
                    result.Message = "please send valid cart id ";
                    result.Succsefully = false;
                }
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "Server error.";
            }
            return Json(result);
        }
        [Authorize(Roles = "Custumer")]
        public IActionResult GetUserCart(bool isAjax, bool isLayout)
        {
            var data = HttpContext.User.Claims.ToList();
            var data1 = HttpContext.User.Claims.ToList();
            var data3 = HttpContext.User.Identities.ToList();
            int totalPriceOfALl = 0;
            var userId = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);
            List<CartViewModel> viewmodel = new List<CartViewModel>();
            List<CartDto> result = _IItem.GetUsercartById(userId);
            foreach (var item in result)
            {
                totalPriceOfALl = totalPriceOfALl + Convert.ToInt32(item.TotalPrice);
            }
            viewmodel = result.Select(s => new CartViewModel
            {

                ItemId = s.ItemId,
                ItemName = s.ItemName,
                PricePerItem = s.PricePerItem,
                TotalPrice = Convert.ToInt32(s.TotalPrice),
                ImageUrl = s.ImageUrl,
                Discription = s.Discription,
                Quantity = s.Quantity,
                CartId = s.Id,
                IsAvilable = _IItem.IsAvilableItem(s.Id, s.Quantity, 0),
                totalPriceOfALl = totalPriceOfALl
            }).ToList();
            if (!isAjax)
            {
                return View(viewmodel);
            }
            if (isLayout)
            {
                return PartialView("_cartIcon", viewmodel);
            }
            else
            {
                return PartialView("_CartView", viewmodel);
            }
        }
        [Authorize(Roles = "Custumer")]
        public IActionResult _GetUserCart(bool isAjax, bool isLayout)
        {
            int totalPriceOfALl = 0;
            var userId = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);
            List<CartViewModel> viewmodel = new List<CartViewModel>();
            List<CartDto> result = _IItem.GetUsercartById(userId);
            foreach (var item in result)
            {
                totalPriceOfALl = totalPriceOfALl + Convert.ToInt32(item.TotalPrice);
            }
            viewmodel = result.Select(s => new CartViewModel
            {

                ItemId = s.ItemId,
                ItemName = s.ItemName,
                PricePerItem = s.PricePerItem,
                TotalPrice = Convert.ToInt32(s.TotalPrice),
                ImageUrl = s.ImageUrl,
                Discription = s.Discription,
                Quantity = s.Quantity,
                CartId = s.Id,
                IsAvilable = _IItem.IsAvilableItem(s.Id, s.Quantity, 0),
                totalPriceOfALl = totalPriceOfALl
            }).ToList();
            if (isLayout)
            {
                return PartialView("_cartIcon", viewmodel);
            }
            return PartialView("_CartView", viewmodel);
        }

        [Authorize(Roles = "Custumer")]
        public JsonResult GetUserCartForAjax()
        {
            int totalPriceOfALl = 0;
            var userId = Convert.ToInt32(HttpContext.Request.Cookies["user_id"]);
            List<CartViewModel> viewmodel = new List<CartViewModel>();
            List<CartDto> result = _IItem.GetUsercartById(userId);
            foreach (var item in result)
            {
                totalPriceOfALl = totalPriceOfALl + Convert.ToInt32(item.TotalPrice);
            }
            viewmodel = result.Select(s => new CartViewModel
            {

                ItemId = s.ItemId,
                ItemName = s.ItemName,
                PricePerItem = s.PricePerItem,
                TotalPrice = s.PricePerItem,
                ImageUrl = s.ImageUrl,
                Discription = s.Discription,
                Quantity = s.Quantity,
                CartId = s.Id,
                IsAvilable = _IItem.IsAvilableItem(s.Id, s.Quantity, 0),
                totalPriceOfALl = totalPriceOfALl
            }).ToList();
            return Json(viewmodel);
        }
        [Authorize(Roles = "Custumer")]
        public JsonResult EditCart(int cartId, int quantity)
        {
            IGernalResult result = new GernalResult();
            result = _IItem.EditFromCart(cartId, quantity);
            return Json(result);
        }

        public JsonResult GetUserRole()
        {
            int i = 1;
            string role = "gest";
            var result = "a";
            var data = HttpContext.User.Identity.Name;
            var data4 = HttpContext.User.Claims.ToList();
            var data1 = HttpContext.User.Claims.ToList();
            foreach (var item in data4)
            {
                i++;
                if (i == 3)
                {
                    role = item.Value;
                }

                result = result + " " + item.Value;
            }
            // resut = data4[0];
            //var data3 = HttpContext.User.Identities.ToList();
            return Json(role);
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
