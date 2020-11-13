using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Responses
{
    public class RegisteredModule
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int State { get; set; }
    }
}
