namespace GymCore.Domain.Entities
{
    public class LogEntity : BaseEntity
    {
        public string CallSite { get; set; }
        public string Exception { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Username { get; set; }
        public string Source { get; set; }

    }
}
