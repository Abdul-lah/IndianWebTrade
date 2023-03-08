using INFASTRUCTURE.Dto;
using INFASTRUCTURE.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using IndianWebTradeWeb.Models;
using INFASTRUCTURE.GernalResult;
using System.Collections.Generic;

namespace IndianWebTradeWeb.Controllers
{
    public class SellerController: Controller
    {


        private readonly IItem _ProductItem;
        private readonly IMasterService _MasterService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public SellerController(IItem item, IMasterService masterService, IWebHostEnvironment hostEnvironment)
        {
            _ProductItem = item;
            _MasterService = masterService;
            webHostEnvironment = hostEnvironment;
        }

        [Authorize(Roles = "Seller")]
        public IActionResult AddProductItem()
        {
            ViewBag.categories = _MasterService.GetCategories().Select(s => new CategoryDto
            {
                Id = s.Id,
                CatogeryName = s.CatogeryName
            });
            return View();
        }
        [HttpPost]
        public IActionResult AddProductItem(ProductItemViewModel model)
        {
            var userId = HttpContext.Request.Cookies["user_id"];
            string imageurl = UploadedFile(model.Image);
            ViewBag.categories = _MasterService.GetCategories().Select(s => new CategoryDto
            {
                Id = s.Id,
                CatogeryName = s.CatogeryName
            });
            var result = _ProductItem.AddItem(new ItemDto
            {
                Name = model.Name,
                CatogeryId = model.CatogeryId,
                Discription = model.Discription,
                Image = imageurl,
                Price = model.Price,
                Quantity = model.Quantity,
                SellerId = userId,
            });
            ViewBag.msg = result.Message;
            return View();
        }

        private string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "ItemImages");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
        public IActionResult Index(SortModel model)
        {
            var userId = HttpContext.Request.Cookies["user_id"];
            var categories = _MasterService.GetCategories().Select(s => new CategoryDto
            {
                Id = s.Id,
                CatogeryName = s.CatogeryName
            }).ToList();
            categories.Add(new CategoryDto { Id = 0, CatogeryName = "All" });
            ViewBag.categories = categories.OrderBy(s => s.Id).ToList();


            IGernalResult result = new GernalResult();
            //result = _IItem.getAllItem();
            List<ItemDto> items = _ProductItem.getAllItem().Where(w=>w.SellerId==userId).ToList();
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
            if (model.CategoryId > 0)
            {
                modelListFilter = modelList.Where(x => x.CategoryId == model.CategoryId).ToList();
            }
            if (model.PriceFilter == "desc")
            {
                if (model.CategoryId > 0)
                {
                    modelListFilter = modelListFilter.OrderByDescending(x => Convert.ToInt32(x.Price)).ToList();
                }
                else
                {
                    modelListFilter = modelList.OrderByDescending(x => Convert.ToInt32(x.Price)).ToList();
                }

            }
            if (model.PriceFilter == "asec")
            {
                if (model.CategoryId > 0)
                {
                    modelListFilter = modelListFilter.OrderBy(x => Convert.ToInt32(x.Price)).ToList();
                }
                else
                {
                    modelListFilter = modelList.OrderBy(x => Convert.ToInt32(x.Price)).ToList();
                }
            }
            if (model.PriceFilter != null || model.CategoryId > 0)
            {
                return PartialView("_ProductItem", modelListFilter);
            }
            return View(modelList);
        }
    }
}
