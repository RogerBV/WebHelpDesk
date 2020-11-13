using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Common;
using Services.Interfaces.Declarations;
using Services.Interfaces.Responses;
using Services.Interfaces.Requests;
namespace Services.Interfaces.Declarations
{
    public interface IEventTypeService:
        ICRUDService<CreateEventType,UpdateEventType,RegisteredEventType,  DeletedEventType >
    {
    }
}
