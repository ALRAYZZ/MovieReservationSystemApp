using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieReservationSystem.DataAccess;
using MovieReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
				.Include(r => r.Showtime)
				.Include(r => r.Seat)
				.SingleOrDefault(r => r.Id == reservationId && r.UserId == userId);

			if (reservation == null || reservation.Showtime.StartTime <= DateTime.Now)
			{
				return false; // Reservation not found or showtime has already started
			}

			var showtimeSeat = _dbContext.ShowtimeSeats
				.SingleOrDefault(ss => ss.ShowtimeId == reservation.ShowtimeId && ss.SeatId == reservation.SeatId);

			if (showtimeSeat != null)
			{
				showtimeSeat.IsReserved = false;
			}

			reservation.Status = "Cancelled";
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

		public bool CreateReservation(int showtimeId, int seatId)
		{
			int userId = _roleService.GetUserId();
			var showtimeSeat = _dbContext.ShowtimeSeats
				.SingleOrDefault(ss => ss.ShowtimeId == showtimeId && ss.SeatId == seatId && !ss.IsReserved);

			if (showtimeSeat == null)
			{
				return false; // Showtime or seat not found or seat is already reserved
			}

			var reservation = new ReservationModel()
			{
				UserId = userId,
				ShowtimeId = showtimeId,
				SeatId = seatId,
				ReservationTime = DateTime.Now,
				ReservationCode = Guid.NewGuid().ToString(),
				Status = "Confirmed"
			};

			showtimeSeat.IsReserved = true;

			_dbContext.Reservations.Add(reservation);
			_dbContext.SaveChanges();
			return true;
		}

		public decimal GetTotalRevenue()
		{
			if (!_roleService.IsAdmin())
			{
				throw new UnauthorizedAccessException("You are not authorized to view total revenue");
			}
			decimal ticketPrice = _config.GetValue<decimal>("TicketPrice");
			return _dbContext.Reservations
				.Count(r => r.Status == "Confirmed") * ticketPrice;
		}
	}
}

