using System;
using System.Collections.Generic;
using System.Text;
using Services.Interfaces.Declarations.Common;
using Services.Interfaces.Requests;
using Services.Interfaces.Responses;
namespace Services.Interfaces.Declarations
{
    public interface IUserService:
        ICRUDService<CreateUser,UpdateUser,RegisteredUser,DeletedUser>
    {
        public List<RegisteredUser> Login(String user, string pass);
    }
}
