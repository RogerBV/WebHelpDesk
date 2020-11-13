using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Implementation.SQL;
using Services.Interfaces.Declarations;
using System.Text.Json;
namespace WebHelpDesk.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;
        public LoginController()
        {
            this._userService = new UserServiceSQL();
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAuthenticate(string user, string pass)
        {
            var list = this._userService.Login(user, pass);
            
            if (list.Count > 0)
            {
                
                HttpContext.Session.SetString( "UserLogged", JsonSerializer.Serialize(list[0]).ToString());
                return Json("1");
            }
            else {
                return Json("0");
            }
            
        }
        [HttpPost]
        public ActionResult LogOut()
        {
            try
            {
                HttpContext.Session.Clear();
                return Json("1");
            }
            catch (Exception)
            {

                return Json("0");
            }
        }
    }
}