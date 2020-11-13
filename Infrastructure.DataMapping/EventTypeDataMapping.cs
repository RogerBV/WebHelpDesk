using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Responses;
using Domain.Entities;
namespace Infrastructure.DataMapping
{
    public static class EventTypeDataMapping
    {
        public static RegisteredEventType ToDTO(this EventType eventTypeOnDb)
        {
            return new RegisteredEventType()
            {
                EventTypeId = eventTypeOnDb.Id
                ,Name = eventTypeOnDb.Name
            };
        }
    }
}
