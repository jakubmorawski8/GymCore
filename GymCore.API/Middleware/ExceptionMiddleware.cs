using System;
using System.Net;
using System.Threading.Tasks;
using GymCore.Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace GymCore.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var error = new ErrorDetails();

            switch (ex)
            {
                case BadRequestException e:
                {
                    error.StatusCode = (int)HttpStatusCode.BadRequest;
                    error.Message = e.Message;
                    break;
                }
                case ValidationException e:
                {
                    error.StatusCode = (int)HttpStatusCode.BadRequest;
                    error.Message = e.Message;
                    error.ErrorList = e.ValidationErrors;
                    break;
                }
                case NotFoundException e:
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    error.Message = e.Message;
                    break;
                }
                default:
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    error.Message = ex.Message;
                    break;
                }


            }

            await context.Response.WriteAsync(error.ToString());
        }
    }
}
