using System;

namespace GymCore.Application.Interfaces
{
    public interface ILoggedInUserService
    {
        public Guid UserId { get; }
    }
}
