using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.Requests;
namespace WebHelpDesk.Models
{
    public static class RequestModel
    {
        public static CreateRequest ToCreate(this IFormCollection ifcRequest)
        {

            return new CreateRequest()
            {
                 Name = ifcRequest["Name"]
                ,Description = ifcRequest["Description"]
                ,ModuleId = Convert.ToInt32(ifcRequest["ModuleId"])
            };
        }
        
    }
}
