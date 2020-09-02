using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultStatusCodeMessage(statusCode);
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        private string GetDefaultStatusCodeMessage(int statusCode)
        {
            
            return statusCode switch
            {
                400 => "Requesting you to not send bad requests",
                401 => "u might be the king in ur area, but u r not authorized here",
                404 => "Note that all that can be found will be found, this i cannot",
                500 => "the internals of the server has been errored",
                _ => null
            };
        }
    }
}