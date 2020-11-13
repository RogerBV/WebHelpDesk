using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int State { get; set; }
    }
}
