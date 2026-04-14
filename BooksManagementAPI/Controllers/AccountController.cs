using BooksManagementAPI.Models.DTOs;
using BooksManagementAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BooksManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login(LoginModel model)
        {
            try
            {

                return Ok();
            }
            catch (BadHttpRequestException ex)
            {

                return ThrowBadRequestError(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return ThrowNullReferenceError(ex.Message);
            }
            catch (SqlException ex)
            {
                return ThrowInternalServerError(ex.Message);
            }
        }
    }
}
