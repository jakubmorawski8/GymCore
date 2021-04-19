using System;

namespace GymCore.Domain.Entities
{
    public class ExerciseHistoryHeaderEntity : BaseEntity
    {
        public WorkoutEntity Workout { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public UserEntity User { get; set; }
    }
}
