using System.ComponentModel.DataAnnotations;

namespace BooksManagementAPI.Models.DTOs
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
