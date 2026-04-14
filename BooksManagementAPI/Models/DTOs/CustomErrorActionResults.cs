namespace BooksManagementAPI.Models.DTOs
{
    public class CustomBadRequestErrorActionResult
    {
        public  string Message { get; set; }
        public string ExceptionType { get; set; } = "Bad Request Error";
        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
    }

    public class CustomInternalServerErrorActionResult
    {
        public string Message { get; set; }
        public string ExceptionType { get; set; } = "Internal Server Error";
        public int StatusCode { get; set; } = StatusCodes.Status500InternalServerError;
    }

    public class CustomNullReferenceErrorActionResult
    {
        public string Message { get; set; }
        public string ExceptionType { get; set; } = "Not Found Error";
        public int StatusCode { get; set; } = StatusCodes.Status404NotFound;
    }
}
