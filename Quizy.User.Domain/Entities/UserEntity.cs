using Quizy.Shared.DDD;

namespace Quizy.User.Domain.Entities
{
    public class UserEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public UserEntity(
            Id id,
            string name,
            string email,
            DateTime? createdAt = null,
            DateTime? updatedAt = null
            )
        {
            Id = id;
            Name = name;
            Email = email;
            CreatedAt = createdAt ?? DateTime.UtcNow;
            UpdatedAt = createdAt ?? DateTime.UtcNow;
        }

    }
}