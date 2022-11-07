using Quizy.Shared.DDD;
using Quizy.Shared.Entities;

namespace Quizy.User.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public UserEntity(
            Id id,
            string name,
            string email,
            DateTime? createdAt = null,
            DateTime? updatedAt = null
            ) : base(id, createdAt, updatedAt)
        {
            Name = name;
            Email = email;
        }

    }
}