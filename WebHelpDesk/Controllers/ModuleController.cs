using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Declarations;
using Services.Interfaces.Requests;
using Services.Implementation.SQL;
namespace WebHelpDesk.Controllers
{
    public class ModuleController : Controller
    {
        private IModuleService _moduleService;

        public ModuleController()
        {
            _moduleService = new ModuleServiceSQL();
        }
        [HttpGet]
        public JsonResult ListModules()
        {
            var list = this._moduleService.List();

            return Json(list);
        }
        [HttpPost]
        public ActionResult SaveModule(CreateModule createModule)
        {
            var registeredModule = this._moduleService.Create(createModule);
            return Json(registeredModule);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}