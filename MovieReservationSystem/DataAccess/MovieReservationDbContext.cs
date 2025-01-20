using Microsoft.EntityFrameworkCore;
using MovieReservationSystem.Models;

namespace MovieReservationSystem.DataAccess
{
	public class MovieReservationDbContext : DbContext
	{
		public MovieReservationDbContext(DbContextOptions<MovieReservationDbContext> options) : base(options)
		{
		}

		public DbSet<UserModel> Users { get; set; }
		public DbSet<ShowtimeModel> Showtimes { get; set; }
		public DbSet<MovieModel> Movies { get; set; }
		public DbSet<SeatModel> Seats { get; set; }
		public DbSet<ReservationModel> Reservations { get; set; }
		public DbSet<GenreModel> Genres { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ReservationModel>()
				.HasOne(r => r.User)
				.WithMany(u => u.Reservations)
				.HasForeignKey(r => r.UserId);
			
			modelBuilder.Entity<ReservationModel>()
				.HasOne(r => r.Showtime)
				.WithMany(s => s.Reservations)
				.HasForeignKey(r => r.ShowtimeId);

			modelBuilder.Entity<ReservationModel>()
				.HasOne(r => r.Seat)
				.WithMany(s => s.Reservations)
				.HasForeignKey(r => r.SeatId);

			modelBuilder.Entity<SeatModel>()
				.HasOne(s => s.Showtime)
				.WithMany(s => s.Seats)
				.HasForeignKey(s => s.ShowtimeId);
		}
	}
}
