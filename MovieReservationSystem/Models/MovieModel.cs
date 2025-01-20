namespace MovieReservationSystem.Models
{
	public class MovieModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string PosterImage { get; set; }
		public GenreModel Genre { get; set; }
		public List<ShowtimeModel> Showtimes { get; set; }
	}
}
