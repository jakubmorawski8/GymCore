namespace GymCore.Core.Entities
{
    public class UserWorkoutEntity : BaseEntity
    {
        public long UserId { get; set; }
        public long WorkoutId { get; set; }
    }
}
