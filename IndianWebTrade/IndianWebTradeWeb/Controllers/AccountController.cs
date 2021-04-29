using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using INFASTRUCTURE.Dto;
using INFASTRUCTURE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Microsoft.AspNetCore.Hosting;


namespace IndianWebTradeWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _iAccount;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AccountController(IAccount iAccount, IWebHostEnvironment hostEnvironment)
        {
            _iAccount = iAccount;
            webHostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserRegistration(UserViewModel model)
        {
            //string uniqueFileName;
            //if (model.ProfileImage != null)
            //{
            //    uniqueFileName = UploadedFile(model.ProfileImage);
            //}
            //else
            //{
            //    uniqueFileName = "";
            //}
            _iAccount.UserRegistration(new UserDto
            {
                Name = model.Name,
                Address = model.Address,
                Email = model.Email,
                Password = model.Password,
                Role = 1,
            });
            return View();
        }

        public IActionResult SellerRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SellerRegistration(UserViewModel model)
        {
            string uniqueFileName;
            //if (model.ProfileImage != null)
            //{
            //    uniqueFileName = UploadedFile(model.ProfileImage);
            //}
            //else
            //{
            //    uniqueFileName = "";
            //}
            var result = _iAccount.UserRegistration(new UserDto
            {
                Name = model.Name,
                Address = model.Address,
                Email = model.Email,
                Password = model.Password,
                Role = 2,
                MobileNo = model.MobileNo
            });
            ViewBag.msg = result.Message;
            return View();
        }



        private string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;


            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "ProfileImages");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}