namespace MovieReservationSystem.Models
{
	public class ShowtimeDTO
	{
		public int Id { get; set; }
		public string MovieTitle  { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public List<SeatDTO> AvailableSeats { get; set; }
	}
}
