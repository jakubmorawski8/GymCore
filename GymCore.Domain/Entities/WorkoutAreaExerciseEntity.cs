namespace GymCore.Domain.Entities
{
    public class WorkoutAreaExerciseEntity : BaseEntity
    {
        public long WorkoutAreaId { get; set; }
        public WorkoutAreaEntity WorkoutArea { get; set; }
        public long ExerciseId { get; set; }
        public ExerciseEntity Exercise { get; set; }
        public double Load { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
