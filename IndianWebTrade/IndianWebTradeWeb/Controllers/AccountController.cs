using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFASTRUCTURE.Dto;
using INFASTRUCTURE.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace IndianWebTradeWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount _iAccount;
        public AccountController(IAccount iAccount)
        {
            _iAccount = iAccount;
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
        public IActionResult UserRegistration(UserViewModel model, IFormFile file)
        {
            _iAccount.UserRegistration(new UserDto
            {
                Name = model.Name,
                Address = model.Address,
                Email = model.Email,
                Password = model.Password,
                Role = 1
            });
            return View();
        }
    }
}