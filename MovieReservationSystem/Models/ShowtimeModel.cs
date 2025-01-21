namespace MovieReservationSystem.Models
{
	public class ShowtimeModel
	{
		public int Id { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }	
		public int MovieId { get; set; }
		public MovieModel Movie { get; set; }
		public List<ShowtimeSeat> ShowtimeSeats { get; set; }
		public List<ReservationModel> Reservations { get; set; }
	}
}
