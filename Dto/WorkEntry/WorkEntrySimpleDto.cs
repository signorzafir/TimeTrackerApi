namespace TimeTrackerAPI.Dto.WorkEntry
{
    public class WorkEntrySimpleDto
    {
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal WageForEntry { get; set; }
    }
}
