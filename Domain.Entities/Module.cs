using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
namespace Domain.Entities
{
    [Table("Module")]
    public class Module:BaseEntity
    {
        public string Name { get; set; }

    }
}
