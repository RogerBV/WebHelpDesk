using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    [Table("Request")]
    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime GoalDate { get; set; }
        public DateTime AttentionDate { get; set; }
        public string SourceFile { get; set; }
        public string FileName { get; set; }
        public int? AttentionUserId { get; set; }
        [ForeignKey("AttentionUserId")]
        public User AttentionUser { get; set; }
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public Module Module { get; set; }

        public int LastUpdateUserId { get; set; }

        public List<RequestFile> RequestFiles { get; set; }

        public DateTime CreateDate { get; set; }
        public int State { get; set; }
        [ForeignKey("State")]
        public RequestState RequestState { get; set; }
    }
}
