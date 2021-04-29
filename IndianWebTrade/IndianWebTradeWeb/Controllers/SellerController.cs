using IndianWebTradeWeb.Models;
using INFASTRUCTURE.Dto;
using INFASTRUCTURE.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IndianWebTradeWeb.Controllers
{
    public class SellerController : Controller
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
                SellerId =Convert.ToString(1),
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
        public IActionResult Index()
        {
            return View();
        }
    }
}
