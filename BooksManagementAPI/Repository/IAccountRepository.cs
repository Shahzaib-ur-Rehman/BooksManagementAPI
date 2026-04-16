using BooksManagementAPI.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace BooksManagementAPI.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Signup(SignupModel model);
        Task<string> Login(LoginModel model);

        Task<string> ForgotPassowrd(ForgotModel model);

        Task<string> ResetPassword(ResetPasswordDTO model);
    }
}
