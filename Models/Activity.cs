namespace TripExperienceAPI.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public int TripId { get; set; }
        public int DestinationId { get; set; }

        public int Duration { get; set; }
        public DurationUnit DurationUnit { get; set; }

        public DateTime? StartDateTime { get; set; } // optional scheduling
        public DateTime? EndDateTime { get; set; }   // computed based on duration

        public int? Sequence { get; set; } // optional for manual ordering
        public double Cost { get; set; }

        public Trip Trip { get; set; }
    }
    public enum DurationUnit { Hour, Day }

}
