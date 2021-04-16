using System.Collections.Generic;

namespace GymCore.Domain.Entities
{
    public class WorkoutAreaEntity : BaseEntity
    {
        public WorkoutEntity Workout { get; set; }
        public int QtyRepetitions { get; set; }
        public IList<WorkoutAreaExerciseEntity> WorkoutAreasExercise { get; set; }
    }
}
