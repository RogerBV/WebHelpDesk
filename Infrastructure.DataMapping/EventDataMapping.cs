using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
namespace Infrastructure.DataMapping
{
    public static class EventDataMapping
    {
        public static Event ToEntity(this CreateEvent newRegistry)
        {
            return new Event()
            {
                Description = newRegistry.Description
                , Type = newRegistry.Type
                , UserId = newRegistry.UserId
                , RequestId = newRegistry.RequestId
                , State = 1
                , CreateDate = DateTime.Now
            };
        }
        public static Event ToEntityReview(this CreateEvent newRegistry)
        {
            return new Event()
            {
                Description = newRegistry.Description
                ,Type = 3
                ,UserId = newRegistry.UserId
                ,RequestId = newRegistry.RequestId
                ,State = 1
                ,CreateDate= DateTime.Now
            };
        }
        public static Event ToEntityRejection(this CreateEvent newRegistry)
        {
            return new Event()
            {
                Description = newRegistry.Description
                ,Type = 4
                ,UserId = newRegistry.UserId
                ,RequestId = newRegistry.RequestId
                ,State = 1
                ,CreateDate = DateTime.Now
            };
        }
        
        public static Event ToEntityEventAssignUser(this CreateEvent newRegistry)
        {
            return new Event()
            {
                Description = newRegistry.Description
                ,Type = 2
                ,UserId = newRegistry.UserId
                ,State = 1
                ,CreateDate = DateTime.Now
            };
        }

        public static Event ToEntityRejectionByAdministrator(this CreateEvent newRegistry)
        {
            return new Event()
            {
                Description = newRegistry.Description
                ,Type = 5
                ,UserId = newRegistry.UserId
                ,RequestId = newRegistry.RequestId
                ,State = 1
                ,CreateDate = DateTime.Now
            };
        }
        public static RegisteredEvent ToDTO(this Event eventOnDb)
        {
            return new RegisteredEvent()
            {
                  Id = eventOnDb.Id
                , Description = eventOnDb.Description
                , State = eventOnDb.State
                , RequestId = eventOnDb.RequestId
                , Type = eventOnDb.Type
                , UserId = eventOnDb.UserId
                , UserName = eventOnDb.User != null ? eventOnDb.User.Name : ""
                , CreateDate = eventOnDb.CreateDate.ToString("yyyy-MM-dd")
                , EventTypeName = eventOnDb.EventType != null ? eventOnDb.EventType.Name : ""
            };
        }
    }
}
