using System;

namespace GymCore.Domain.Entities
{
    public class ExerciseHistoryHeaderEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public WorkoutEntity Workout { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
