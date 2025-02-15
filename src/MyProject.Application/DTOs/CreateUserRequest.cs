using System.ComponentModel.DataAnnotations;

namespace MyProject.Application.DTOs
{
    public class CreateUserRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}