using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
namespace Infrastructure.DataMapping
{
    public static class ModuleDataMapping
    {
        public static Module ToEntity(this CreateModule newRegistry)
        {
            return new Module()
            {
                Name = newRegistry.Name
                ,CreateDate = DateTime.Now
                ,State = 1
            };
        }
        public static Module ToEntity(this UpdateModule updateModule)
        {
            return new Module()
            {
                 Id = updateModule.ModuleId
                ,Name = updateModule.Name
                ,CreateDate = DateTime.Now
            };
        }
        public static RegisteredModule ToDTO(this Module moduleOnDb)
        {
            return new RegisteredModule()
            {
                ModuleId = moduleOnDb.Id
                ,CreateDate = moduleOnDb.CreateDate
                ,Name = moduleOnDb.Name
                ,State = moduleOnDb.State
            };
        }
    }
}
