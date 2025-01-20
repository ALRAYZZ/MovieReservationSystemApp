﻿namespace MovieReservationSystem.Models
{
	public class SeatModel
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public bool IsReserved { get; set; }
		public int ShowtimeId { get; set; } // Foreign key
		public ShowtimeModel Showtime { get; set; } // Navigation property
		public ReservationModel Reservation { get; set; }
		public List<ReservationModel> Reservations { get; set; }
	}
}
