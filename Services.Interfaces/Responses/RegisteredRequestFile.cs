using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Responses
{
    public class RegisteredRequestFile
    {
        public int RequestFile_Id { get; set; }
        public String Source { get; set; }
        public int RequestId { get; set; }
    }
}
