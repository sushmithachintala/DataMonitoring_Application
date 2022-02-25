using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Entity;
using TestApplication.Services;

namespace TestApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginService;
       public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;
        }
        public JsonResult LoginUser(string userName,string password)
        {          
            return new JsonResult(loginService.IsUserValid(userName,password));
        }
    }
}
