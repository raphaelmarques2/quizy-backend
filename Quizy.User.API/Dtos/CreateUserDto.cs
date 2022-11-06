using System.ComponentModel.DataAnnotations;

namespace Quizy.User.API.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
