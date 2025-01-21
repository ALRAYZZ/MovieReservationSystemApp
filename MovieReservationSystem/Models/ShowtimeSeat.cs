namespace MovieReservationSystem.Models
{
	public class ShowtimeSeat
	{
		public int ShowtimeId { get; set; }
		public ShowtimeModel Showtime { get; set; }
		public int SeatId { get; set; }
		public SeatModel Seat { get; set; }
		public bool IsReserved { get; set; }
	}
}
