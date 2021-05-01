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
using INFASTRUCTURE.GernalResult;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

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
                RoleId = 1,
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
                RoleId = 2,
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



        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {

            IGernalResult result = new GernalResult();
            if (ModelState.IsValid)
            {
                try
                {
                    result = _iAccount.userLogin(new UserDto
                    {
                        Email = model.Email,
                        Password = model.Password,
                    });
                    if (result.Succsefully)

                    {
                        var data = result.value as UserDto;
                        var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, data.Email),
                    new Claim(ClaimTypes.Role, data.Role),
                    new Claim(ClaimTypes.PrimarySid,data.Id.ToString())

                 };
                        HttpContext.Response.Cookies.Append("user_id", Convert.ToString(data.Id));
                        HttpContext.Response.Cookies.Append("Email", data.Email);
                        var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

                        var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                        HttpContext.SignInAsync(userPrincipal);

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.message = result.Message;
                        return View();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return View();

        }


        public IActionResult ChangePassword()
        {
            var userId = HttpContext.Request.Cookies["user_id"];
            if (userId == null)
            {
                return Redirect("Login");
            }

            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword password)
        {
            IGernalResult result = new GernalResult();
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = HttpContext.Request.Cookies["user_id"];
                    result = _iAccount.ChangePassword(Convert.ToInt32(userId), password.ConfirmPassword);
                    ViewBag.msg = result.Succsefully ? "Your password has been changed" : "your password did not change";
                }
                catch
                {
                    ViewBag.msg = "Server error";
                }
            }
            return View();
        }
    }
}