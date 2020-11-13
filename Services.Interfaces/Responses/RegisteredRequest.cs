using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces.Responses
{
    public class RegisteredRequest
    {
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public String CreateDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public String GoalDate { get; set; }
        public String AttentionDate { get; set; }
        public DateTime AttentionDateFormatDate { get; set; }
        public int AttentionUserId { get; set; }
        public string AttentionUserName { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }
        public string SourceFile { get; set; }
        public string FileName { get; set; }
    }
}
