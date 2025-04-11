using TripExperienceAPI.Models;

namespace TripExperienceAPI.Repositories
{
    public interface ITripRepository
    {
        Task AddTripAsync(Trip trip);
    }
}
