using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Requests
{
    public class UpdateRequestState
    {
        public int RequestStateId { get; set; }
        public string Name { get; set; }
    }
}
