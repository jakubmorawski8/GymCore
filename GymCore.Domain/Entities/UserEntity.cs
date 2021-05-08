using System;
using Microsoft.AspNetCore.Identity;

namespace GymCore.Domain.Entities
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
