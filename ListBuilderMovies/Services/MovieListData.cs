using ListBuilderMovies.Models;
using System.Collections.Generic;

namespace ListBuilderMovies.Services
{
    public class MovieListData : IMovieListData
    {
        public List<MovieList> getMovieLists { get; set; }

        public MovieListData()
        {
            getMovieLists = new List<MovieList>()
            {
                new MovieList()
                {
                    id = 5,
                    Name = "Test",
                    Description = "Test movie list for the project",
                    User = "Admin",
                    Movies = new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Movie",
                            Description = "A movie description",
                            ImageLocation = "https://images.pexels.com/photos/11577405/pexels-photo-11577405.jpeg",
                            Url = "null"
                        }
                    }
                }
            };
        }

        public void deleteMovieList(int? id)
        {
            var obj = getMovieLists.Find(x => x.id == id);
            if (obj != null)
            {
                getMovieLists.Remove(obj);
            }
        }

        public void editMovieList(MovieList bonk)
        {
            var obj = getMovieLists.Find(x => x.id == bonk.id);
            if (obj != null)
            {
                obj.id = bonk.id;
                obj.Name = bonk.Name;
                obj.Description = bonk.Description;
                obj.User = bonk.User;
            }
        }
        public List<MovieList> ReadAll()
        {
            return getMovieLists;
        }
        public void newMovieList(MovieList movieList)
        {
            if(movieList != null)
            {
                movieList.Movies = new List<Movie>();
                getMovieLists.Add(movieList);
            }
        }

        public MovieList getMovieListById(int? id)
        {
            var obj = getMovieLists.Find(x => x.id == id);
            if (obj != null)
            {
                return obj;
            }
            return null;
        }

        public void addMovie(Movie movie)
        {
            var obj = getMovieLists.Find(x => x.id == movie.Id);
            if (obj != null)
            {
                obj.Movies.Add(movie);
            }
        }
    }
}
