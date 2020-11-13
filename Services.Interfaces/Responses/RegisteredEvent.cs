using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Responses
{
    public class RegisteredEvent
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int RequestId { get; set; }
        public string CreateDate { get; set; }
        public int State { get; set; }
        public string UserName { get; set; }
        public String EventTypeName { get; set; }
    }
}
