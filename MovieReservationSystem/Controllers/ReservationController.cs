using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservationSystem.Models;
using MovieReservationSystem.Services;

namespace MovieReservationSystem.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize]
	public class ReservationController : ControllerBase
	{
		private readonly ReservationService _reservationService;

		public ReservationController(ReservationService reservationService)
		{
			_reservationService=reservationService;
		}

		[HttpPost("reserve")]
		public ActionResult<ReservationModel> CreateReservation(ReservationDTO reservation)
		{
			var result = _reservationService.CreateReservation(reservation);
			if (!result)
			{
				return BadRequest("Unable to create reservation");
			}
			return Ok("Reservation created successfully");
		}

		[HttpGet("user-reservations")]
		public ActionResult<ReservationModel> GetAllUserReservations()
		{
			var reservation = _reservationService.GetUserReservations();
			return Ok(reservation);
		}

		[HttpDelete("cancel/{reservationId}")]
		public IActionResult CancelReservation(int id)
		{
			var result = _reservationService.CancelReservation(id);
			if (!result)
			{
				return BadRequest("Unable to cancel reservation");
			}
			return Ok("Reservation cancelled successfully");
		}
	}
}
