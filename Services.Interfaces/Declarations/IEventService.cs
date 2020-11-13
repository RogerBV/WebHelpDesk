using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
using Services.Interfaces.Declarations.Common;
namespace Services.Interfaces.Declarations
{
    public interface IEventService:
        ICRUDService<CreateEvent,UpdateEvent,RegisteredEvent,DeletedEvent>
    {
        RegisteredEvent CreateReview(CreateEvent newRegistry);
        RegisteredEvent CreateRejectionByUser(CreateEvent newRegistry);
        RegisteredEvent CreateRejectionByAdministrator(CreateEvent newRegistry);
        List<RegisteredEvent> ListEventsByRequest(int RequestId);
    }
}
