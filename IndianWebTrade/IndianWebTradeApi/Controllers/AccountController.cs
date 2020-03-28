using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndianWebTradeApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndianWebTradeApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpPost, Route("AccountRegistration")]
        public IActionResult UserAccountRegistration(UserModel model)
        {
            try
            {

            }
            catch
            {

            }
            return Ok();
        }
    }
}