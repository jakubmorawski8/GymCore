using System.Collections.Generic;
namespace GymCore.Domain.Entities
{
    public class WorkoutEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public UserEntity CreatedBy { get; set; }
        public IList<UserWorkoutEntity> UserWorkouts { get; set; }
    }
}
