using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    public class RequestFile:BaseEntity
    {
        public string Source { get; set; }
        public string FileName { get; set; }
        public int RequestId { get; set; }
        [ForeignKey("RequestId")]
        public Request Request { get; set; }
    }
}
