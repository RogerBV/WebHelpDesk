using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
using Domain.Entities;
namespace Infrastructure.DataMapping
{
    public static class RequestStateDataMapping
    {
        public static RequestState ToEntity(this CreateRequestState newRegistry)
        {
            return new RequestState()
            {
                Name = newRegistry.Name
                ,CreateDate = DateTime.Now
            };
        }
        public static RegisteredRequestState ToDTO(this RequestState requestStateOnDb)
        {
            return new RegisteredRequestState()
            {
                Name = requestStateOnDb.Name
                ,RequestStateId = requestStateOnDb.Id
            };
        }
    }
}
