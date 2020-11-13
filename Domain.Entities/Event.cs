using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    public class Event : BaseEntity
    {
        public int Type { get; set; }
        [ForeignKey("Type")]
        public EventType EventType { get; set; }
        public string Description { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int RequestId { get; set; }
        [ForeignKey("RequestId")]
        public Request Request { get; set; }
    }
}
