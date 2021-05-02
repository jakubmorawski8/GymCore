using Microsoft.AspNetCore.Identity;

namespace GymCore.Domain.Entities
{
    public class RoleEntity : IdentityRole<long>
    {
        public string Description { get; set; }
    }
}
