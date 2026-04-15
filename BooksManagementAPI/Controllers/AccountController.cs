using BooksManagementAPI.Models.DTOs;
using BooksManagementAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

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
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDTO<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomBadRequestErrorActionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomNullReferenceErrorActionResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomInternalServerErrorActionResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = await _accountRepository.Login(model);
                if (result == null)
                {
                    return BadRequest();
                }
                var response = new ResponseDTO<string>()
                {
                    Message = "Login Successfull",
                    Data = result
                };
                return Ok(response);
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


        [HttpPost]
        [Route("signup")]
        [ProducesResponseType(typeof(ResponseDTO<string>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomBadRequestErrorActionResult),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CustomNullReferenceErrorActionResult),StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomInternalServerErrorActionResult),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUp([FromBody] SignupModel model)
        {
            

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = await _accountRepository.Signup(model);

                if (!result.Succeeded)
                {
                    return BadRequest();
                }
                var response = new ResponseDTO<string>()
                {
                    Message= "User Created Successfully",
                    Data = ""
                };
                return Ok(response);
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
