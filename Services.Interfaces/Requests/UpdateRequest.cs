using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Requests
{
    public class UpdateRequest
    {
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserId { get; set; }
        public int ModuleId { get; set; }
        public string UserName { get; set; }
        public int AttentionUserId { get; set; }
        public String GoalDate { get; set; }
        public DateTime AttentionDate { get; set; }
        public int State { get; set; }
    }
}
