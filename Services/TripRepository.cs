using TripExperienceAPI.Data;
using TripExperienceAPI.Models;
using TripExperienceAPI.Repositories;

namespace TripExperienceAPI.Services
{
    public class TripRepository(AppDbContext _context) : ITripRepository
    {
        
        public async Task AddTripAsync(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
        }
    }
}
