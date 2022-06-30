namespace ListBuilderMovies.Models
{
    public class Movie
    {
        public int movieId { get; set; }
        public int movieListId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLocation { get; set; }
        public string Url { get; set; }

    }
}
