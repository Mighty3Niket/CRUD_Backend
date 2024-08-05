using System.Net;

namespace CRUDAPI.Helper
{
    public class ApiResponse<T>
    {
        public T? Result { get; set; }
        public HttpStatusCode? StatusCode { get; set; } = HttpStatusCode.InternalServerError;
        public string? Message { get; set; }
        /*public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(bool success, T data, string message)
        {
            Success = true;
            Message = message;
            Data = data;
        }*/

        /*public ApiResponse(string message)
        {
            Success = false;
            Message = message;
            Data = default;
        }*/
    }
}

