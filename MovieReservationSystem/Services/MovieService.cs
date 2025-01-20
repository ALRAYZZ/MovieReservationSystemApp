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

		public List<MovieModel> getMoviesWithShowtimesForDate(DateTime date)
		{
			return _dbContext.Movies
				.Include(m => m.Showtimes)
				.ThenInclude(s => s.Seats)
				.Where(m => m.Showtimes.Any(s => s.StartTime.Date == date))
				.ToList();
		}
	}
}
