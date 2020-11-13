using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
namespace Infrastructure.DataMapping
{
    public static class RequestDataMapping
    {
        public static Request ToEntity(this CreateRequest newRegistry)
        {
            return new Request()
            {
                Name = newRegistry.Name
                ,Description = newRegistry.Description
                ,CreateDate = DateTime.Now
                ,GoalDate = DateTime.Now
                ,AttentionDate = DateTime.Now
                ,ModuleId = newRegistry.ModuleId
                ,UserId = newRegistry.UserId
                ,State = 1
                ,LastUpdateUserId = 0
            };
        }
        public static RequestFile ToEntity(this CreateRequestFile newRegistry)
        {
            return new RequestFile()
            {
                Source = newRegistry.Source
                ,FileName = newRegistry.FileName
                ,RequestId = newRegistry.RequestId
                ,CreateDate =DateTime.Now
                ,State = 1
            };
        }
        public static RegisteredRequestFile ToDTO(this RequestFile requestFileOnDb)
        {
            return new RegisteredRequestFile()
            {
                Source = requestFileOnDb.Source
                ,
                RequestId = requestFileOnDb.RequestId
                ,
            };
        }
        public static RegisteredRequest ToDTO(this Request requestOnDb)
        {
            return new RegisteredRequest()
            {
                Name = requestOnDb.Name
                , Description = requestOnDb.Description
                , CreateDate = requestOnDb.CreateDate.ToString("yyyy-MM-dd")
                , ModuleId = requestOnDb.ModuleId
                , UserName = requestOnDb.User != null ? requestOnDb.User.Name : ""
                , ModuleName = requestOnDb.Module != null ? requestOnDb.Module.Name: ""
                , AttentionUserName = requestOnDb.AttentionUser != null ? requestOnDb.AttentionUser.Name:""
                , AttentionUserId = requestOnDb.AttentionUserId != null ? requestOnDb.AttentionUserId.Value : 0
                , RequestId = requestOnDb.Id
                , GoalDate = requestOnDb.State == 1 ? "" : requestOnDb.GoalDate.ToString("yyyy-MM-dd")
                , AttentionDate = requestOnDb.AttentionDate.ToString("yyyy-MM-dd")
                , AttentionDateFormatDate = requestOnDb.AttentionDate
                , StateName = requestOnDb.RequestState != null ? requestOnDb.RequestState.Name:""
                , State = requestOnDb.State
                , SourceFile = requestOnDb.SourceFile
                , FileName = requestOnDb.FileName
            };
        }
        public static Request ToEntity(this RegisteredRequest requestDTO)
        {
            return new Request()
            {
                Id = requestDTO.RequestId
                ,Name = requestDTO.Name
                ,Description = requestDTO.Description
                ,CreateDate = Convert.ToDateTime(requestDTO.CreateDate)
                ,ModuleId = requestDTO.ModuleId
                ,UserId = requestDTO.UserId
                ,State = requestDTO.State
                ,GoalDate = Convert.ToDateTime(requestDTO.GoalDate)
            };
        }
        public static Request ToEntity(this UpdateRequest requestDTO)
        {
            return new Request()
            {
                 Id = requestDTO.RequestId
                ,Name = requestDTO.Name
                ,Description = requestDTO.Description
                ,CreateDate = requestDTO.CreateDate
                ,ModuleId = requestDTO.ModuleId
                ,UserId = requestDTO.UserId
                ,AttentionUserId = requestDTO.AttentionUserId
                ,AttentionDate = requestDTO.AttentionDate
                ,State = requestDTO.State
                ,GoalDate = Convert.ToDateTime(requestDTO.GoalDate)
                ,LastUpdateUserId = requestDTO.UserId
            };
        }
        public static Request ToEntityClose(this UpdateRequest updateRequest)
        {
            return new Request()
            {
                Id = updateRequest.RequestId
                ,Name = updateRequest.Name
                ,Description = updateRequest.Description
                ,CreateDate = DateTime.Now
                ,ModuleId = 0
                ,UserId = updateRequest.UserId
                ,AttentionUserId = updateRequest.AttentionUserId
                ,AttentionDate = DateTime.Now
                ,State = 5
                ,LastUpdateUserId = updateRequest.UserId
                ,GoalDate = DateTime.Now
            };
            
        }
    }
}
