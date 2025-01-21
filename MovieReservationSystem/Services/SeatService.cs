using MovieReservationSystem.DataAccess;
using MovieReservationSystem.Models;

namespace MovieReservationSystem.Services
{
	public class SeatService
	{
		private readonly MovieReservationDbContext _dbContext;

		public SeatService(MovieReservationDbContext dbContext)
		{
			_dbContext=dbContext;
		}

		public List<SeatModel> GetAvailableSeatsForShowTime(int showtimeId)
		{
			return _dbContext.ShowtimeSeats
				.Where(ss => ss.ShowtimeId == showtimeId && !ss.Seat.IsReserved)
				.Select(ss => ss.Seat)
				.ToList();
		}
		public int GetTheaterCapacity()
		{
			return _dbContext.Seats.Count();
		}

		public int GetReservedSeatsCount(int showtimeId)
		{
			return _dbContext.ShowtimeSeats.Count(ss => ss.ShowtimeId == showtimeId && ss.IsReserved);
		}
	}
}
