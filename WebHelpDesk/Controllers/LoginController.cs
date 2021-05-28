using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Implementation.SQL;
using Services.Interfaces.Declarations;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
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
        public ActionResult LoginAuthenticate(LoginRequest loginRequest)
        {
            var list = this._userService.Login(loginRequest.User, loginRequest.Pass);
            
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
        public ActionResult LoginReturnUser(LoginRequest loginRequest)
        {
            var list = this._userService.Login(loginRequest.User, loginRequest.Pass);
            if (list.Count > 0)
            {
                return Json(list.First());
            }
            else {
                return Json(new RegisteredUser());
            }
        }
        [HttpGet]
        public IActionResult ShowUserLogged()
        {
            var objJsonUser = HttpContext.Session.GetString("UserLogged");
            var objUserLogged = JsonSerializer.Deserialize<RegisteredUser>(objJsonUser);
            return Json(objUserLogged);
        }
        /*[HttpPost]
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
        }*/
    }
}