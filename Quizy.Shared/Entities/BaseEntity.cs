using Quizy.Shared.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Quizy.Shared.Entities
{
    public abstract class BaseEntity
    {
        public Id Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseEntity(Id id, DateTime? createdAt = null, DateTime? updatedAt = null)
        {
            Id = id;
            CreatedAt = createdAt ?? DateTime.UtcNow;
            UpdatedAt = createdAt ?? DateTime.UtcNow;
        }
    }
}
