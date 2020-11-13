using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
using Domain.Entities;
namespace Infrastructure.DataMapping
{
    public static class UserDataMapping
    {
        public static User ToEntity(this CreateUser newRegistry)
        {
            return new User()
            {
                Name = newRegistry.Name
                ,State = 1
                ,CreateDate = DateTime.Now
                ,UserName = newRegistry.UserName
                ,UserPassword = newRegistry.UserPassword
                ,Type = newRegistry.Type
            };
        }
        public static RegisteredUser ToDTO(this User userOnDb)
        {
            return new RegisteredUser()
            {
                UserId = userOnDb.Id
                ,Name = userOnDb.Name
                ,UserName = userOnDb.UserName
                ,UserPassword = userOnDb.UserPassword
                ,Type = userOnDb.Type
            };
        }
    }
}
