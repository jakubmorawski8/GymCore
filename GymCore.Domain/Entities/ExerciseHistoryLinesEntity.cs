namespace GymCore.Domain.Entities
{
    public class ExerciseHistoryLinesEntity : BaseEntity
    {
        public ExerciseHistoryHeaderEntity ExerciseHistoryHeader { get; set; }
        public ExerciseEntity Exercise { get; set; }
        public double Load { get; set; }
        public int QtyRepetitions { get; set; }
    }
}
