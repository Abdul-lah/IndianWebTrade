using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndianWebTradeApi.Model;
using INFASTRUCTURE.Dto;
using INFASTRUCTURE.GernalResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace IndianWebTradeApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _IAccount;
        public AccountController(IAccount account)
        {
            _IAccount = account;
        }

        [HttpGet, Route("AccountRegistration")]
        public IActionResult UserAccountRegistration()
        {
            IGernalResult result = new GernalResult();
            try
            {
                UserDto d= new UserDto();
               
                result = _IAccount.UserRegistration(d);

            }
            catch
            {

            }
            return Ok(result);
        }
    }
}