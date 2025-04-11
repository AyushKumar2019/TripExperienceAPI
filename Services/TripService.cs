using TripExperienceAPI.DTOs;
using TripExperienceAPI.Models;
using TripExperienceAPI.Repositories;

namespace TripExperienceAPI.Services
{
    public class TripService(ITripRepository _tripRepository) : ITripService
    {

        public async Task<TripResponse> CreateTripAsync(TripCreateRequest request)
        {
            ValidateTripRequest(request);

            double totalCost = request.Activities.Sum(a => a.Cost);

            var trip = new Trip
            {
                Title = request.Title,
                UserId = request.UserId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TotalCost = totalCost,
                Activities = MapActivities(request)
            };

            await _tripRepository.AddTripAsync(trip);

            return new TripResponse
            {
                TripId = trip.TripId,
                Title = trip.Title,
                TotalCost = trip.TotalCost
            };
        }

        // helper: validate trip request
        private void ValidateTripRequest(TripCreateRequest request)
        {
            if (request.StartDate >= request.EndDate)
                throw new ArgumentException("Trip start date must be before end date.");

            if (request.Activities == null || request.Activities.Count == 0)
                throw new ArgumentException("At least one activity is required.");

            ValidateActivityDurationAgainstTrip(request.StartDate, request.EndDate, request.Activities);

        }
        // helper: validate total duration
        private void ValidateActivityDurationAgainstTrip(DateTime tripStart, DateTime tripEnd, List<ActivityCreateRequest> activities)
        {
            double tripDurationDays = (tripEnd - tripStart).TotalDays;
            double totalActivityDays = 0;

            foreach (var activity in activities)
            {
                totalActivityDays += activity.DurationUnit switch
                {
                    DurationUnit.Day => activity.Duration,
                    DurationUnit.Hour => activity.Duration / 24.0,
                    _ => throw new ArgumentOutOfRangeException(nameof(activity.DurationUnit), "Invalid duration unit.")
                };
            }

            if (totalActivityDays > tripDurationDays)
                throw new ArgumentException("Total activity duration exceeds the trip duration.");
        }

        //helper: map from DTO to Activity model
        private List<Activity> MapActivities(TripCreateRequest request)
        {
            DateTime current = request.StartDate;

            var orderedActivities = request.Activities
                .OrderBy(a => a.Sequence ?? int.MaxValue)
                .ToList();

            var mappedActivities = new List<Activity>();

            foreach (var activityDto in orderedActivities)
            {
                TimeSpan duration = activityDto.DurationUnit switch
                {
                    DurationUnit.Day => TimeSpan.FromDays(activityDto.Duration),
                    DurationUnit.Hour => TimeSpan.FromHours(activityDto.Duration),
                    _ => throw new ArgumentOutOfRangeException(nameof(activityDto.DurationUnit), "Invalid duration unit.")
                };

                var start = activityDto.PreferredStartTime ?? current;
                var end = start + duration;

                mappedActivities.Add(new Activity
                {
                    DestinationId = activityDto.DestinationId,
                    Duration = activityDto.Duration,
                    DurationUnit = activityDto.DurationUnit,
                    Cost = activityDto.Cost,
                    Sequence = activityDto.Sequence,
                    StartDateTime = start,
                    EndDateTime = end
                });

                current = end.AddHours(1); // Optional buffer between activities
            }

            return mappedActivities;
        }
    }
}
