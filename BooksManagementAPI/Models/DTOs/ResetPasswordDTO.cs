namespace BooksManagementAPI.Models.DTOs
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string OtpCode { get; set; }
        public string Password { get; set; }
    }
}
