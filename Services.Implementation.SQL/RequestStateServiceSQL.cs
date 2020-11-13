using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Declarations;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
using Infrastructure.SQLERepository;
using Infrastructure.DataMapping;
using System.Linq;
namespace Services.Implementation.SQL
{
    public class RequestStateServiceSQL : IRequestStateService
    {
        public RegisteredRequestState Create(CreateRequestState newRegistry)
        {
            throw new NotImplementedException();
        }

        public RegisteredRequestState Delete(DeletedRequestState Id)
        {
            throw new NotImplementedException();
        }

        public List<RegisteredRequestState> List()
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                return helpDeskDataContext.RequestStates.ToList().Select(x => x.ToDTO()).ToList();
            }
        }

        public RegisteredRequestState Update(UpdateRequestState updateRegistry)
        {
            throw new NotImplementedException();
        }
    }
}
