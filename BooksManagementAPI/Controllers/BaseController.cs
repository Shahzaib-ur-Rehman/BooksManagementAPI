using BooksManagementAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BooksManagementAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult ThrowBadRequestError(string errorMessage)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new CustomBadRequestErrorActionResult
            {
                Message = errorMessage
            });
        }

        protected IActionResult ThrowInternalServerError(string errorMessage)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new CustomInternalServerErrorActionResult
            {
                Message = errorMessage
            });
        }

        protected IActionResult ThrowNullReferenceError(string errorMessage)
        {
            return StatusCode(StatusCodes.Status404NotFound, new CustomNullReferenceErrorActionResult
            {
                Message = errorMessage
            });
        }
    }
}
