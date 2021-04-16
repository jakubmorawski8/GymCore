using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace GymCore.Domain.Entities
{
    public class UserEntity : IdentityUser<long>
    {
        public IList<UserWorkoutEntity> UserWorkouts { get; set; }
    }
}
