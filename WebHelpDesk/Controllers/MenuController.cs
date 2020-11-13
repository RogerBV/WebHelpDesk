using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Implementation.SQL;
using Services.Interfaces.Declarations;
using Services.Interfaces.Responses;
using System.Text.Json;
namespace WebHelpDesk.Controllers
{
    public class MenuController : Controller
    {
        private IUserService _userService;
        public MenuController()
        {
            this._userService = new UserServiceSQL();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ShowUserLogged() {
            var objJsonUser = HttpContext.Session.GetString("UserLogged");
            var objUserLogged = JsonSerializer.Deserialize<RegisteredUser>(objJsonUser);
            return Json(objUserLogged);
        }

    }
}