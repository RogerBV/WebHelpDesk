using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Common;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
namespace Services.Interfaces.Declarations
{
    public interface IModuleService:
        ICRUDService<CreateModule,UpdateModule,RegisteredModule,DeletedModule>
    {
    }
}
