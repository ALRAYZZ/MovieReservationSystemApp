namespace MovieReservationSystem.Models
{
	public class GenreModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<MovieModel> Movies { get; set; }
	}
}
