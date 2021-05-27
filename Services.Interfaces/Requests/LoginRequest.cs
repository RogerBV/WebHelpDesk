using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Requests
{
    public class LoginRequest
    {
        public string User { get; set; }
        public string Pass { get; set; }
    }
}
