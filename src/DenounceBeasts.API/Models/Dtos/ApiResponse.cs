namespace DenounceBeasts.API.Models.Dtos
{
    public class ApiResponse<T>
     where T : class
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, string message = null, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Data = data,
                Message = message,
                Success = true,
                StatusCode = statusCode
            };
        }
        public static ApiResponse<T> FailureResponse(string message, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                Data = null,
                Message = message,
                Success = false,
                StatusCode = statusCode
            };
        }
    }
}
