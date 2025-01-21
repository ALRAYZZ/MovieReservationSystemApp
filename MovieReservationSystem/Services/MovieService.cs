using Microsoft.EntityFrameworkCore;
using MovieReservationSystem.DataAccess;
using MovieReservationSystem.Models;

namespace MovieReservationSystem.Services
{
	public class MovieService
	{
		private readonly MovieReservationDbContext _dbContext;

		public MovieService(MovieReservationDbContext dbContext)
		{
			_dbContext=dbContext;
		}

		public List<MovieModel> GetMoviesWithShowtimesForDate(DateTime date)
		{
			return _dbContext.Movies
				.Include(m => m.Showtimes)
				.ThenInclude(s => s.ShowtimeSeats)
				.Where(m => m.Showtimes.Any(s => s.StartTime.Date == date))
				.ToList();
		}

		public List<ShowtimeDTO> GetShowtimesWithDetails()
		{
			return _dbContext.Showtimes
				.Include(s => s.Movie)
				.Include(s => s.ShowtimeSeats)
				.ThenInclude(ss => ss.Seat)
				.Select(s => new ShowtimeDTO
				{
					Id = s.Id,
					MovieTitle = s.Movie.Title,
					StartTime = s.StartTime,
					EndTime = s.EndTime,
					AvailableSeats = s.ShowtimeSeats
						.Where(ss => !ss.IsReserved)
						.Select(ss => new SeatDTO
						{
							Id = ss.Seat.Id,
							Number = ss.Seat.Number
						})
						.ToList()
				})
				.ToList();
		}

		public ShowtimeDTO GetShowtimeWithDetails(int id)
		{
			return _dbContext.Showtimes
				.Include(s => s.Movie)
				.Include(s => s.ShowtimeSeats)
				.ThenInclude(ss => ss.Seat)
				.Where(s => s.Id == id)
				.Select(s => new ShowtimeDTO
				{
					Id = s.Id,
					MovieTitle = s.Movie.Title,
					StartTime = s.StartTime,
					EndTime = s.EndTime,
					AvailableSeats = s.ShowtimeSeats
						.Where(ss => !ss.IsReserved)
						.Select(ss => new SeatDTO
						{
							Id = ss.Seat.Id,
							Number = ss.Seat.Number
						})
						.ToList()
				})
				.SingleOrDefault();
		}
	}
}
