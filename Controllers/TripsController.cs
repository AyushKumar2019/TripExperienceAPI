using Microsoft.AspNetCore.Mvc;
using TripExperienceAPI.DTOs;
using TripExperienceAPI.Repositories;

namespace TripExperienceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // used Primary Constructor over here ( Inject Paramters directly into class )
    public class TripsController(ITripService _tripService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateTrip([FromBody] TripCreateRequest request)
        {
            // Validation via ModelState
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _tripService.CreateTripAsync(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", detail = ex.Message });
            }
        }
    }
}
