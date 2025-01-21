namespace MovieReservationSystem.Models
{
	public class ReservationModel
	{
		public int Id { get; set; }

		// Foreign keys
		public int UserId { get; set; }
		public int ShowtimeId { get; set; }
		public int SeatId { get; set; }

		// Navigation properties
		public UserModel User { get; set; }
		public ShowtimeModel Showtime { get; set; }
		public SeatModel Seat {get; set; }

		// Reservation details
		public DateTime ReservationTime { get; set; }
		public string Status { get; set; } = "Pending"; // Example: Pending, Confirmed, Cancelled
		public string ReservationCode { get; set; } // Unique code for customer reference
	}
}
