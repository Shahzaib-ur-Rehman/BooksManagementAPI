using BooksManagementAPI.Models.DTOs;
using BooksManagementAPI.Models.Entities;
using BooksManagementAPI.ThirdPartyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BooksManagementAPI.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IEMailSender _mailSender;

        public AccountRepository(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IEMailSender mailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mailSender = mailSender;
        }

        public async Task<IdentityResult> Signup(SignupModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName=model.Email
            };

            return  await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<string> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) {

                return null;
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }

            var token = await GenerateJsonWebToken(user);

            return token;
        }

        public async Task<string> ForgotPassowrd(ForgotModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user==null)
            {
                return null;
            }

            var optCode = await _userManager.GeneratePasswordResetTokenAsync(user);

            await _mailSender.SendMail("shaahzaibrehman@gmail.com","OTP Code",user.Email,optCode);
            return "Check Your Email For Forgot Password OTP";
        }

        public async Task<string> ResetPassword(ResetPasswordDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return null;
            }
            var result = await _userManager.ResetPasswordAsync(user, model.OtpCode, model.Password);
            if (!result.Succeeded)
            {
                return "Otp Incorrect";
            }
            return "Password Reset Successfully";
        }
        private async Task<string> GenerateJsonWebToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[] { 
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Sub,user.FirstName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
       _configuration["Jwt:Issuer"],
       claims,
       expires: DateTime.Now.AddDays(1),
       signingCredentials: credentials);

            var handler = new JwtSecurityTokenHandler();
            return  handler.WriteToken(token);

        }




    }
}
