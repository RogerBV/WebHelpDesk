using System;
using System.Collections.Generic;
using System.Text;
namespace Services.Interfaces.Requests
{
    public class CreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }
        
    }
}
