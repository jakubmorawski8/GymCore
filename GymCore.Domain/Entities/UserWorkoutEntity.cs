using System;

namespace GymCore.Domain.Entities
{
    public class UserWorkoutEntity : BaseEntity
    {
        public UserEntity User { get; set; }
        public Guid UserId { get; set; }
        public Guid WorkoutId { get; set; }
        public WorkoutEntity Workout { get; set; }
    }
}
