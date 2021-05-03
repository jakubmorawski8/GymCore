using System;
using Microsoft.AspNetCore.Identity;

namespace GymCore.Domain.Entities
{
    public class RoleEntity : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
