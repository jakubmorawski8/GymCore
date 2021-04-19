using System.Collections.Generic;

namespace GymCore.Domain.Entities
{
    public class ExerciseEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<WorkoutAreaExerciseEntity> WorkoutAreasExercise { get; set; }
    }
}
