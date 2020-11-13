using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Requests
{
    public class UpdateUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string UserPassword { get; set; }
        public int Type { get; set; }
    }
}
