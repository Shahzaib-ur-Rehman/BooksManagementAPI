namespace BooksManagementAPI.Models.DTOs
{
    public class ResponseDTO<T>
    {
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; } = StatusCodes.Status200OK;

        public T? Data { get; set; }
    }
}
