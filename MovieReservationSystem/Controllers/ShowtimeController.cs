using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservationSystem.Models;
using MovieReservationSystem.Services;

namespace MovieReservationSystem.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class ShowtimeController : ControllerBase
	{
		private readonly MovieService _movieService;

		public ShowtimeController(MovieService movieService)
		{
			_movieService=movieService;
		}

		[HttpGet("showtimes")]
		public ActionResult<IEnumerable<ShowtimeDTO>> GetShowtimes()
		{
			var showtimes = _movieService.GetShowtimesWithDetails();
			return Ok(showtimes);
		}

		[HttpGet("showtime/{id}")]
		public ActionResult<ShowtimeDTO> GetShowtime(int id)
		{
			var showtime = _movieService.GetShowtimeWithDetails(id);
			return Ok(showtime);
		}
	}
}
