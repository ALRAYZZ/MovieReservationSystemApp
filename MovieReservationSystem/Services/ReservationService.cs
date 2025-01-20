using Microsoft.EntityFrameworkCore;
using MovieReservationSystem.DataAccess;
using MovieReservationSystem.Models;

namespace MovieReservationSystem.Services
{
	public class ReservationService
	{
		private readonly UserRoleService _roleService;
		private readonly MovieReservationDbContext _dbContext;
		private readonly IConfiguration _config;

		public ReservationService(MovieReservationDbContext dbContext, UserRoleService roleService, IConfiguration config)
		{
			_roleService = roleService;
			_dbContext = dbContext;
			_config = config;
		}


		public List<ReservationModel> GetUserReservations(UserModel user)
		{
			int userId = _roleService.GetUserId();
			if (user.Id != userId)
			{
				throw new UnauthorizedAccessException("You are not authorized to view this user's reservations");
			}
			return _dbContext.Reservations
				.Include(r => r.Showtime)
				.Include(r => r.Seat)
				.Where(r => r.UserId == userId)
				.ToList();
		}

		public bool CancelReservation(int reservationId)
		{
			int userId = _roleService.GetUserId();
			var reservation = _dbContext.Reservations
				.Include(r => r.Seat)
				.SingleOrDefault(r => r.Id == reservationId && r.UserId == userId);
			
			if (reservation == null || reservation.Showtime.StartTime <= DateTime.Now)
			{
				return false; // Reservation not found or showtime has already started
			}

			reservation.Status = "Cancelled";
			reservation.Seat.IsReserved = false;
			reservation.Seat.Reservation = null;
			_dbContext.Reservations.Update(reservation);
			_dbContext.SaveChanges();
			return true;
		}

		public List<ReservationModel> GetAllReservations()
		{
			if (!_roleService.IsAdmin())
			{
				throw new UnauthorizedAccessException("You are not authorized to view all reservations");
			}

			return _dbContext.Reservations
				.Include(r => r.User)
				.Include(r => r.Showtime)
				.Include(r => r.Seat)
				.ToList();
		}

		public int GetTheaterCapacity()
		{
			return _dbContext.Seats.Count();
		}

		public int GetReservedSeatsCount()
		{
			return _dbContext.Reservations.Count(s => s.Status == "Confirmed");
		}
		public decimal GetTotalRevenue()
		{
			if (!_roleService.IsAdmin())
			{
				throw new UnauthorizedAccessException("You are not authorized to view total revenue");
			}
			decimal ticketPrice = _config.GetValue<decimal>("TicketPrice");
			return _dbContext.Reservations.Count(s => s.Status == "Confirmed") * ticketPrice;
		}
	}
}
