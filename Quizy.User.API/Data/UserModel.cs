using Quizy.Shared.DDD;
using Quizy.User.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace Quizy.User.API.Data
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public DateTime? CreatedAt { get; set; }
        [Required]
        public DateTime? UpdatedAt { get; set; }

        public UserEntity toUserEntity()
        {
            
            if (Name == null) throw new Exception($"Invalid User model (Name={Name})");
            if (Email == null) throw new Exception($"Invalid User model (Email={Name})");

            return new UserEntity(
                id: new Id(Id),
                name: Name,
                email: Email,
                createdAt: CreatedAt,
                updatedAt: UpdatedAt
            );
        }
    }

    public static class UserModelExtensions
    {
        public static UserModel toUserModel(this UserEntity entity)
        {
            return new UserModel
            {
                Id = entity.Id.Value,
                Name = entity.Name,
                Email = entity.Email,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt,
            };
        }
    }

}
