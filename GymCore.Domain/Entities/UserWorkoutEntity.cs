namespace GymCore.Domain.Entities
{
    public class UserWorkoutEntity : BaseEntity
    {
        public UserEntity User { get; set; }
        public long UserId { get; set; }
        public long WorkoutId { get; set; }
        public WorkoutEntity Workout { get; set; }
    }
}
