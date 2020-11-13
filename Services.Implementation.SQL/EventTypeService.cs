using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Declarations;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
using Infrastructure.SQLERepository;
using Infrastructure.DataMapping;
using Domain.Entities;
using System.Linq;
namespace Services.Implementation.SQL
{
    public class EventTypeService : IEventTypeService
    {
        public RegisteredEventType Create(CreateEventType newRegistry)
        {
            throw new NotImplementedException();
        }

        public RegisteredEventType Delete(DeletedEventType Id)
        {
            throw new NotImplementedException();
        }

        public List<RegisteredEventType> List()
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                return helpDeskDataContext.EventTypes.ToList().Select(x => x.ToDTO()).ToList();
            }
        }

        public RegisteredEventType Update(UpdateEventType updateRegistry)
        {
            throw new NotImplementedException();
        }
    }
}
