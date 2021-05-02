using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GymCore.Domain.Entities
{
    public class UserEntity : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<UserWorkoutEntity> UserWorkouts { get; set; }
    }
}
