using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Requests
{
    public class UpdateEventType
    {
        public int EventTypeId { get; set; }
        public string Name { get; set; }
    }
}
