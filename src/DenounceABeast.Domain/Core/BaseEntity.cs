using System;
using System.Collections.Generic;
using System.Text;

namespace DenounceBeasts.Domain.Core
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
