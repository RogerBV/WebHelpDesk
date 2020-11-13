using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Declarations.Common;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
namespace Services.Interfaces.Declarations
{
    public interface IRequestService:
        ICRUDService<CreateRequest,UpdateRequest,RegisteredRequest,DeletedRequest>
    {
        public RegisteredRequestFile CreateFile(CreateRequestFile createRequestFile);
        public RegisteredRequest AssignRequest(UpdateRequest registeredRequest);
        public List<RegisteredRequest> ListRequestsByState(int State);
        public List<RegisteredRequest> ListRequestByAttentionUser(int UserId, int State);
        public List<RegisteredRequest> ListRequestsByStateAndUser(int UserId, int State);
        public RegisteredRequest CloseRequest(UpdateRequest updateRequest);
    }
}
