namespace Lewis.CodingTracker
{
    public class CodingSessionsModel
    {
        public List<CodingSessionModel> CodingSessions { get; set; }
    }

    public class CodingSessionModel
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }
    }   
}