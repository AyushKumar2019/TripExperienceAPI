using System.Diagnostics;

namespace TripExperienceAPI.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalCost { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }

}
