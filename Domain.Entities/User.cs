using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain.Entities.Common;
namespace Domain.Entities
{
    [Table("User")]
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int Type { get; set; }
    }
}
