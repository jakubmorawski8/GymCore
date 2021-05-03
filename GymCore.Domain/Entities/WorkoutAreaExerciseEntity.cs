using System;

namespace GymCore.Domain.Entities
{
    public class WorkoutAreaExerciseEntity : BaseEntity
    {
        public Guid WorkoutAreaId { get; set; }
        public WorkoutAreaEntity WorkoutArea { get; set; }
        public Guid ExerciseId { get; set; }
        public ExerciseEntity Exercise { get; set; }
        public double Load { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
