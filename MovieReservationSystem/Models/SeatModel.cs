namespace MovieReservationSystem.Models
{
	public class SeatModel
	{
		public int Id { get; set; }
		public int Number { get; set; }
		public bool IsReserved { get; set; }
		public List<ShowtimeSeat> ShowtimeSeats { get; set; }
	}
}
