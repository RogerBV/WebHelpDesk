using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Declarations;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
using Infrastructure.DataMapping;
using Infrastructure.SQLERepository;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Services.Implementation.SQL
{
    public class RequestServiceSQL : IRequestService
    {

        public RegisteredRequest CloseRequest(UpdateRequest updateRequest)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                using (var transaction = helpDeskDataContext.Database.BeginTransaction())
                {
                    var request = updateRequest.ToEntityClose();
                    helpDeskDataContext.Requests.Attach(request);
                    helpDeskDataContext.Entry(request).Property(x => x.State).IsModified = true;
                    helpDeskDataContext.Entry(request).Property(x => x.LastUpdateUserId).IsModified = true;
                    helpDeskDataContext.SaveChanges();
                    transaction.Commit();
                    return request.ToDTO();
                }
            }
        }

        public RegisteredRequest AssignRequest(UpdateRequest updateRequest)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                using (var transaction = helpDeskDataContext.Database.BeginTransaction())
                {
                    var request = updateRequest.ToEntity();
                    helpDeskDataContext.Requests.Attach(request);
                    helpDeskDataContext.Entry(request).Property(x => x.AttentionUserId).IsModified = true;
                    helpDeskDataContext.Entry(request).Property(x => x.State).IsModified = true;
                    helpDeskDataContext.Entry(request).Property(x => x.GoalDate).IsModified = true;
                    helpDeskDataContext.Entry(request).Property(x => x.LastUpdateUserId).IsModified = true;
                    helpDeskDataContext.SaveChanges();
                    transaction.Commit();
                    return request.ToDTO();
                }
            }
        }
        public RegisteredRequest Create(CreateRequest newRegistry)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                var newRequest = newRegistry.ToEntity();
                helpDeskDataContext.Requests.Add(newRequest);
                helpDeskDataContext.SaveChanges();
                return newRequest.ToDTO();
            }
            
        }

        public RegisteredRequestFile CreateFile(CreateRequestFile createRequestFile)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                var newRequestFile = createRequestFile.ToEntity();
                helpDeskDataContext.Files.Add(newRequestFile);
                helpDeskDataContext.SaveChanges();
                return newRequestFile.ToDTO();
            }
        }

        public RegisteredRequest Delete(DeletedRequest Id)
        {
            throw new NotImplementedException();
        }

        public List<RegisteredRequest> List()
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                return helpDeskDataContext.Requests
                    .Include(x => x.User)
                    .Include(x => x.Module)
                    .Include(x => x.RequestState)
                    .Include(x => x.AttentionUser).ToList().Select(x => x.ToDTO()).ToList();
            }
        }
        public List<RegisteredRequest> ListRequestsByStateAndUser(int UserId,int State)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                return helpDeskDataContext.Requests
                    .Include(x => x.User)
                    .Include(x => x.Module)
                    .Include(x => x.RequestState)
                    .Include(x => x.AttentionUser).ToList()
                    .Where(x=>x.State ==  (State == 0 ? x.State : State )  && x.UserId == UserId )
                    .Select(x => x.ToDTO()).ToList();
            }
        }
        public List<RegisteredRequest> ListRequestByAttentionUser(int UserId,int State)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {

                return helpDeskDataContext.Requests
                    .Include(x => x.User)
                    .Include(x => x.Module)
                    .Include(x => x.AttentionUser)
                    .Include(x => x.RequestState)
                    .Where(x => x.AttentionUserId == UserId && x.State == (State == 0 ? x.State : State )  )
                    .ToList().Select(x => x.ToDTO()).ToList();
            }
        }

        public List<RegisteredRequest> ListRequestsByState(int State)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                return helpDeskDataContext.Requests
                    .Include(x => x.User)
                    .Include(x => x.Module)
                    .Include(x => x.AttentionUser)
                    .Include(x => x.RequestState)
                    .Where(x => x.State == (State == 0 ? x.State : State))
                    .ToList().Select(x => x.ToDTO()).ToList();
            }
        }

        public RegisteredRequest Update(UpdateRequest updateRegistry)
        {
            throw new NotImplementedException();
        }
        
    }
}
