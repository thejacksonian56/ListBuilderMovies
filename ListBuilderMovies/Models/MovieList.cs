using System.Collections.Generic;

namespace ListBuilderMovies.Models
{
    public class MovieList
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
