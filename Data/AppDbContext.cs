namespace TripExperienceAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using TripExperienceAPI.Models;

    public class AppDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
