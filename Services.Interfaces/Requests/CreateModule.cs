using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Requests
{
    public class CreateModule
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int State { get; set; }

    }
}
