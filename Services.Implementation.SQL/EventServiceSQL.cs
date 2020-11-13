using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Declarations;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
using Infrastructure.SQLERepository;
using Infrastructure.DataMapping;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.Implementation.SQL
{
    public class EventServiceSQL : IEventService
    {
        public RegisteredEvent Create(CreateEvent newRegistry)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                var eEvent = newRegistry.ToEntity();
                helpDeskDataContext.Events.Add(eEvent);
                helpDeskDataContext.SaveChanges();
                return eEvent.ToDTO();
            }
        }

        public RegisteredEvent CreateRejectionByUser(CreateEvent newRegistry)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                using (var transaction = helpDeskDataContext.Database.BeginTransaction())
                {
                    try
                    {
                        var eEvent = newRegistry.ToEntityRejection();
                        helpDeskDataContext.Events.Add(eEvent);
                        helpDeskDataContext.SaveChanges();

                        var eRequest = helpDeskDataContext.Requests.Where(x => x.Id == eEvent.RequestId).First();
                        eRequest.State = 4;

                        helpDeskDataContext.Requests.Attach(eRequest);
                        helpDeskDataContext.Entry(eRequest).Property(x => x.State).IsModified = true;
                        helpDeskDataContext.SaveChanges();

                        transaction.Commit();

                        return eEvent.ToDTO();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return new RegisteredEvent();
                    }

                }
            }
        }
        public RegisteredEvent CreateRejectionByAdministrator(CreateEvent newRegistry)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                using (var transaction = helpDeskDataContext.Database.BeginTransaction())
                {
                    try
                    {
                        var eEvent = newRegistry.ToEntityRejectionByAdministrator();
                        helpDeskDataContext.Events.Add(eEvent);
                        helpDeskDataContext.SaveChanges();

                        var eRequest = helpDeskDataContext.Requests.Where(x => x.Id == eEvent.RequestId).First();
                        eRequest.State = 6;

                        helpDeskDataContext.Requests.Attach(eRequest);
                        helpDeskDataContext.Entry(eRequest).Property(x => x.State).IsModified = true;
                        helpDeskDataContext.SaveChanges();

                        transaction.Commit();

                        return eEvent.ToDTO();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return new RegisteredEvent();
                    }

                }
            }
        }
        public RegisteredEvent CreateReview(CreateEvent newRegistry)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                using (var transaction = helpDeskDataContext.Database.BeginTransaction())
                {
                    try
                    {
                        var eEvent = newRegistry.ToEntityReview();
                        helpDeskDataContext.Events.Add(eEvent);
                        helpDeskDataContext.SaveChanges();

                        var eRequest = helpDeskDataContext.Requests.Where(x => x.Id == eEvent.RequestId).First();
                        eRequest.State = 3;

                        helpDeskDataContext.Requests.Attach(eRequest);
                        helpDeskDataContext.Entry(eRequest).Property(x => x.State).IsModified = true;
                        helpDeskDataContext.SaveChanges();

                        transaction.Commit();

                        return eEvent.ToDTO();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return new RegisteredEvent();
                    }

                }
            }
        }
            

        public RegisteredEvent Delete(DeletedEvent Id)
        {
            throw new NotImplementedException();
        }

        public List<RegisteredEvent> List()
        {
            throw new NotImplementedException();
        }

        public RegisteredEvent Update(UpdateEvent updateRegistry)
        {
            throw new NotImplementedException();
        }

        public List<RegisteredEvent> ListEventsByRequest(int RequestId)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                return helpDeskDataContext.Events
                    .Include("User")
                    .Include("EventType")
                    .Where(x => x.RequestId == RequestId).ToList().Select(x => x.ToDTO()).ToList();
            }
        }
    }
}
