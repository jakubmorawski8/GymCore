using System.Collections.Generic;
using FluentValidation.Results;

namespace GymCore.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }

        public BaseResponse(string message)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public BaseResponse(bool success, string message, string status)
        {
            Success = success;
            Message = message;
            Status = status;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public List<string> ValidationErrors { get; set; }

        public void InitializeErrorResponse(IList<ValidationFailure> errors)
        {
            Success = false;
            ValidationErrors = new List<string>();
            foreach (var error in errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }

    }
}
