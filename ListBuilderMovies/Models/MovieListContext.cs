using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ListBuilderMovies.Models
{
    public class MovieListContext : DbContext
    {
        public MovieListContext(DbContextOptions<MovieListContext> options) : base(options)
        {


        }
        public DbSet<MovieList> movieLists { get; set; }
        public DbSet<Movie> movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieList>().HasData(
                new MovieList
                {
                    movieListId = 1,
                    Name = "Placeholder",
                    Description = "A standard dummy movielist",
                    User = "Admin"
                });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    movieId = 1,
                    movieListId = 1,
                    Name = "Placeholder movie",
                    Description = "A standard dummy movie",
                    ImageLocation = "https://images.pexels.com/photos/11577405/pexels-photo-11577405.jpeg",
                    Url = "null"
                });
        }
    }
}
