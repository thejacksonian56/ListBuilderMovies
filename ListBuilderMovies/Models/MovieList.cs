using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListBuilderMovies.Models
{
    public class MovieList
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int movieListId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
