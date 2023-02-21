using System;

namespace FootballService.ErrorResponse
{
    public class CustomErrorResponse
    {
        public string Message { get; set; }
        public int Code { get; set; }

        public CustomErrorResponse(int code, string message)
        {
            Message = message;
            Code = code;
        }
    }
}
