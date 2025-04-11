using System.ComponentModel.DataAnnotations;
using TripExperienceAPI.Models;

namespace TripExperienceAPI.DTOs
{
    public class TripCreateRequest
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "At least one activity is required.")]
        public List<ActivityCreateRequest> Activities { get; set; }
    }
   //[SwaggerSchema("Nested activity info used only inside trip creation.")]
    public class ActivityCreateRequest
    {
        [Required]
        public int DestinationId { get; set; }
        [Range(1, 1000)]
        public int Duration { get; set; }

        [EnumDataType(typeof(DurationUnit))]
        public DurationUnit DurationUnit { get; set; } // e.g., Day, Hour

        // Optional scheduling 
        public DateTime? PreferredStartTime { get; set; }

        [Range(0.01, double.MaxValue)]
        public double Cost { get; set; }

        // Optional field to hint order (only if needed)
        public int? Sequence { get; set; }
    }


}
