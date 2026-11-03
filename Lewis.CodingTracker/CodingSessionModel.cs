namespace Lewis.CodingTracker
{
    public class CodingSession
    {
        public int Id { get; set; }
        public SessionTimings sessionTimings { get; set; }
    }

    public class SessionTimings
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}