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
    public class UserServiceSQL : IUserService
    {
        public RegisteredUser Create(CreateUser newRegistry)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                var eUser = newRegistry.ToEntity();
                helpDeskDataContext.Users.Add(eUser);
                helpDeskDataContext.SaveChanges();
                return eUser.ToDTO();
            }
        }

        public RegisteredUser Delete(DeletedUser Id)
        {
            throw new NotImplementedException();
        }

        public List<RegisteredUser> List()
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                return helpDeskDataContext.Users.ToList().Select(x => x.ToDTO()).ToList();
            }
        }
        public RegisteredUser ListUsersById(int userId)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext())
            {
                return helpDeskDataContext.Users.Where(x => x.Id == userId).ToList().Select(x => x.ToDTO()).ToList().First();
            }
                
        }
        public List<RegisteredUser> Login(LoginRequest loginRequest)
        {
            using (HelpDeskDataContext helpDeskDataContext = new HelpDeskDataContext()) 
            {
                var list = helpDeskDataContext.Users.Where(x => x.UserName.Equals(loginRequest.User) && x.UserPassword.Equals(loginRequest.Pass)).ToList();
                return list.Select(x => x.ToDTO()).ToList();
            }
        }
        public RegisteredUser Update(UpdateUser updateRegistry)
        {
            throw new NotImplementedException();
        }
    }
}
