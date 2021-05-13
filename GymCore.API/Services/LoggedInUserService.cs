using System;
using System.Security.Claims;
using GymCore.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GymCore.API.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = Guid.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public Guid UserId { get; }
    }
}
