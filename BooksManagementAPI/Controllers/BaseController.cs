using BooksManagementAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagementAPI.Controllers
{
    public class BaseController : ControllerBase
    {

        public IActionResult ThrowBadRequestError(string errorMessage)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new CustomBadRequestErrorActionResult
            {
                Message= errorMessage
            });
        }

        public IActionResult ThrowInternalServerError(string errorMessage)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new CustomInternalServerErrorActionResult
            {
                Message = errorMessage
            });
        }

        public IActionResult ThrowNullReferenceError(string errorMessage)
        {
            return StatusCode(StatusCodes.Status404NotFound, new CustomNullReferenceErrorActionResult
            {
                Message = errorMessage
            });
        }
    }

}
