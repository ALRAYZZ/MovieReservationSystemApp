using Microsoft.EntityFrameworkCore;
using MovieReservationSystem.Models;

namespace MovieReservationSystem.DataAccess
{
	public class MovieReservationDbContext : DbContext
	{
		public MovieReservationDbContext(DbContextOptions<MovieReservationDbContext> options) : base(options) { }

		public DbSet<UserModel> Users { get; set; }
		public DbSet<ShowtimeModel> Showtimes { get; set; }
		public DbSet<MovieModel> Movies { get; set; }
		public DbSet<SeatModel> Seats { get; set; }
		public DbSet<ReservationModel> Reservations { get; set; }
		public DbSet<GenreModel> Genres { get; set; }
		public DbSet<ShowtimeSeat> ShowtimeSeats { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ReservationModel>()
				.HasOne(r => r.User)
				.WithMany(u => u.Reservations)
				.HasForeignKey(r => r.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ReservationModel>()
				.HasOne(r => r.Showtime)
				.WithMany(s => s.Reservations)
				.HasForeignKey(r => r.ShowtimeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ReservationModel>()
				.HasOne(r => r.Seat)
				.WithMany()
				.HasForeignKey(r => r.SeatId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ShowtimeModel>()
				.HasOne(s => s.Movie)
				.WithMany(m => m.Showtimes)
				.HasForeignKey(s => s.MovieId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ShowtimeSeat>()
				.HasKey(ss => new { ss.ShowtimeId, ss.SeatId });

			modelBuilder.Entity<ShowtimeSeat>()
				.HasOne(ss => ss.Showtime)
				.WithMany(s => s.ShowtimeSeats)
				.HasForeignKey(ss => ss.ShowtimeId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ShowtimeSeat>()
				.HasOne(ss => ss.Seat)
				.WithMany(s => s.ShowtimeSeats)
				.HasForeignKey(ss => ss.SeatId)
				.OnDelete(DeleteBehavior.Restrict);

			// Seed data
			modelBuilder.Entity<GenreModel>().HasData(
				new GenreModel { Id = 1, Name = "Action" },
				new GenreModel { Id = 2, Name = "Comedy" },
				new GenreModel { Id = 3, Name = "Drama" },
				new GenreModel { Id = 4, Name = "Horror" },
				new GenreModel { Id = 5, Name = "Sci-Fi" }
			);

			modelBuilder.Entity<MovieModel>().HasData(
				new MovieModel { Id = 1, Title = "The Matrix", GenreId = 5, Description = "An action movie", PosterImage = "action.jpg" },
				new MovieModel { Id = 2, Title = "The Hangover", GenreId = 2, Description = "A comedy movie", PosterImage = "comedy.jpg" },
				new MovieModel { Id = 3, Title = "The Notebook", GenreId = 3, Description = "A drama movie", PosterImage = "drama.jpg" }
			);

			modelBuilder.Entity<ShowtimeModel>().HasData(
				new ShowtimeModel { Id = 1, StartTime = new DateTime(2025, 2, 2, 10, 0, 0), EndTime = new DateTime(2025, 2, 2, 12, 0, 0), MovieId = 1 },
				new ShowtimeModel { Id = 2, StartTime = new DateTime(2025, 2, 2, 14, 0, 0), EndTime = new DateTime(2025, 2, 2, 16, 0, 0), MovieId = 2 },
				new ShowtimeModel { Id = 3, StartTime = new DateTime(2025, 2, 2, 18, 0, 0), EndTime = new DateTime(2025, 2, 2, 20, 0, 0), MovieId = 3 }
			);

			modelBuilder.Entity<SeatModel>().HasData(
				new SeatModel { Id = 1, Number = 1 },
				new SeatModel { Id = 2, Number = 2 },
				new SeatModel { Id = 3, Number = 3 },
				new SeatModel { Id = 4, Number = 4 },
				new SeatModel { Id = 5, Number = 5 },
				new SeatModel { Id = 6, Number = 6 },
				new SeatModel { Id = 7, Number = 7 },
				new SeatModel { Id = 8, Number = 8 },
				new SeatModel { Id = 9, Number = 9 },
				new SeatModel { Id = 10, Number = 10 }
			);

			modelBuilder.Entity<ShowtimeSeat>().HasData(
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 1, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 2, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 3, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 4, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 5, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 6, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 7, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 8, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 9, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 1, SeatId = 10, IsReserved = false },

				new ShowtimeSeat { ShowtimeId = 2, SeatId = 1, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 2, SeatId = 2, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 2, SeatId = 3, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 2, SeatId = 4, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 2, SeatId = 5, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 2, SeatId = 6, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 2, SeatId = 7, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 2, SeatId = 8, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 2, SeatId = 9, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 2, SeatId = 10, IsReserved = false },

				new ShowtimeSeat { ShowtimeId = 3, SeatId = 1, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 3, SeatId = 2, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 3, SeatId = 3, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 3, SeatId = 4, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 3, SeatId = 5, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 3, SeatId = 6, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 3, SeatId = 7, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 3, SeatId = 8, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 3, SeatId = 9, IsReserved = false },
				new ShowtimeSeat { ShowtimeId = 3, SeatId = 10, IsReserved = false }
			);

			modelBuilder.Entity<UserModel>().HasData(
				new UserModel()
				{
					Id = 1,
					Name = "Admin User",
					Username = "admin",
					Password = BCrypt.Net.BCrypt.HashPassword("admin"),
					Role = "Admin",
					Email = "admin@example.com"
				},
				new UserModel()
				{
					Id = 2,
					Name = "Regular User",
					Username = "user",
					Password = BCrypt.Net.BCrypt.HashPassword("user"),
					Role = "User",
					Email = "user@example.com"
				}
			);

		}	
	}
}

