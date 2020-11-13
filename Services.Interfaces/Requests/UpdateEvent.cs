using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Requests
{
    public class UpdateEvent
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int RequestId { get; set; }
        public int State { get; set; }
    }
}
