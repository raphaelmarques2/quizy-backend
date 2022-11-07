using Quizy.Shared.DDD;
using Quizy.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizy.Tag.Domain.Entities
{
    public class TagEntity : BaseEntity
    {
        public string Name { get; set; }
        public Id UserId { get; set; }

        public TagEntity(
            Id id,
            string name,
            Id userId,
            DateTime? createdAt = null,
            DateTime? updatedAt = null
            ) : base(id, createdAt, updatedAt)
        {
            Id = id;
            Name = name;
            UserId = userId;
        }
    }
}
