using TripExperienceAPI.DTOs;

namespace TripExperienceAPI.Repositories
{
    public interface ITripService
    {
        Task<TripResponse> CreateTripAsync(TripCreateRequest request);
    }
}
