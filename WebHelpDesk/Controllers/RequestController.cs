using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Services.Interfaces.Declarations;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
using Services.Implementation.SQL;
using System.Text.Json;
using WebHelpDesk.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
namespace WebHelpDesk.Controllers
{
    public class RequestController : Controller
    {
        private IRequestService _requestService;
        private IRequestStateService _requestStateService;
        private IEventService _eventService;
        private IModuleService _moduleService;
        private IUserService _userService;
        private IWebHostEnvironment _hostingEnvironment;
        public RequestController(IWebHostEnvironment environment)
        {
            this._requestService = new RequestServiceSQL();
            this._moduleService = new ModuleServiceSQL();
            this. _userService = new UserServiceSQL();
            this._eventService = new EventServiceSQL();
            this._requestStateService = new RequestStateServiceSQL();
            _hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        private void FileUpload(RegisteredRequest registeredRequest, IFormCollection files)
        {
            try
            {
                var requerimientFiles = Path.Combine(_hostingEnvironment.WebRootPath, "RequerimientFiles");
                requerimientFiles = Path.Combine(requerimientFiles, registeredRequest.RequestId.ToString());

                Directory.CreateDirectory(requerimientFiles);
                foreach (var file in files.Files)
                {
                    if (file.Length > 0)
                    {
                        var filePath = Path.Combine(requerimientFiles, file.FileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyToAsync(fileStream);
                        }
                        this._requestService.CreateFile(new CreateRequestFile(filePath, file.FileName, registeredRequest.RequestId));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult Save(IFormCollection files)
        {
            CreateRequest createRequest = files.ToCreate();
            createRequest.UserId = getIdUserLogged();
            var registeredRequest = this._requestService.Create(createRequest);

            FileUpload(registeredRequest, files);
            
            return Json(createRequest);
        }
        [HttpGet]
        public JsonResult ListRequests()
        {
            var list = this._requestService.List();

            return Json(list);
        }
        [HttpGet]
        public JsonResult ListRequestsByStateAndUser(int State) 
        {
            var list = this._requestService.ListRequestsByStateAndUser(getIdUserLogged(), State);
            return Json(list);
        }
        [HttpGet]
        public JsonResult ListRequests(int State,int UserId)
        {
            var list = this._requestService.List();

            return Json(list);
        }
        [HttpGet]
        public JsonResult ListRequestsByState(int State)
        {
            var list = this._requestService.ListRequestsByState(State);

            return Json(list);
        }
        [HttpGet]
        public JsonResult ListRequestsByAttentionUser(int State)
        {
            var list = this._requestService.ListRequestByAttentionUser(getIdUserLogged(),State);

            return Json(list);
        }
        [HttpGet]
        public JsonResult ListUsers()
        {
            var list = this._userService.List();
            return Json(list);
        }

        [HttpGet]
        public JsonResult ListModules()
        {
            var list = this._moduleService.List();

            return Json(list);
        }
        [HttpPost]
        public IActionResult SaveRequest(CreateRequest newRegistry)
        {
            newRegistry.UserId = getIdUserLogged();
            return Json(this._requestService.Create(newRegistry));
        }
        [HttpPost]
        public IActionResult AssignRequest(UpdateRequest updateRequest)
        {
            updateRequest.UserId = getIdUserLogged();
            return Json(this._requestService.AssignRequest(updateRequest));
        }
        [HttpPost]
        public IActionResult CloseRequest(UpdateRequest updateRequest)
        {
            updateRequest.UserId = getIdUserLogged();
            return Json(this._requestService.CloseRequest(updateRequest));
        }

        [HttpPost]
        public IActionResult CreateReview(CreateEvent newRegistry)
        {
            newRegistry.UserId = getIdUserLogged();
            return Json(this._eventService.CreateReview(newRegistry));
        }
        [HttpPost]
        public IActionResult CreateRejectionByUser(CreateEvent newRegistry)
        {
            newRegistry.UserId = getIdUserLogged();
            return Json(this._eventService.CreateRejectionByUser(newRegistry));
        }
        [HttpPost]
        public IActionResult CreateRejectionByAdministrator(CreateEvent newRegistry)
        {
            newRegistry.UserId = getIdUserLogged();
            return Json(this._eventService.CreateRejectionByAdministrator(newRegistry));
        }
        [HttpGet]
        public IActionResult ListEventsByRequest(int RequestId)
        {
            return Json(this._eventService.ListEventsByRequest(RequestId));
        }
        [HttpGet]
        public IActionResult ListRequestStates()
        {
            return Json(this._requestStateService.List()  );
        }
        private int getIdUserLogged()
        {
            var objJsonUser = HttpContext.Session.GetString("UserLogged");
            var objUserLogged = JsonSerializer.Deserialize<RegisteredUser>(objJsonUser);
            return objUserLogged.UserId;
        }

    }
}