using Quizy.User.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Quizy.User.Domain.Dtos
{
    public class UserDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public UserDto(UserEntity user)
        {
            Id = user.Id.Value;
            Name = user.Name;
            Email = user.Email;
        }
    }

}
