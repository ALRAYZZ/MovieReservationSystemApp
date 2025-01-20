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
			return _dbContext.Seats
				.Where(s => s.ShowtimeId == showtimeId && !s.IsReserved)
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
	}
}
