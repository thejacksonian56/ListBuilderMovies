using ListBuilderMovies.Models;
using System.Collections.Generic;

namespace ListBuilderMovies.Services
{
    public class DBMovieListData : IMovieListData
    {
        private MovieListContext _movieListContext;

        public DBMovieListData(MovieListContext movieListContext)
        {
            _movieListContext = movieListContext;
        }


        public List<MovieList> getMovieLists { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void addMovie(Movie movie)
        {
            _movieListContext.movies.Add(movie);
            _movieListContext.SaveChanges();
        }

        public void deleteMovieList(int? movieListId)
        {
            var obj = _movieListContext.movieLists.Find(movieListId);
            if (obj != null)
            {
                _movieListContext.movieLists.Remove(obj);
                _movieListContext.SaveChanges();
            }
        }

        public void editMovieList(MovieList movieList)
        {
            var obj = _movieListContext.movieLists.Find(movieList.movieListId);
            if (obj != null)
            {
                obj.movieListId = movieList.movieListId;
                obj.User = movieList.User;
                obj.Description = movieList.Description;
                obj.Name = movieList.Name;
                obj.Movies = movieList.Movies;
                _movieListContext.SaveChanges();
            }
        }

        public MovieList getMovieListById(int? movieListId)
        {
            var obj = _movieListContext.movieLists.Find(movieListId);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public List<Movie> getMovies()
        {
            return new List<Movie>(_movieListContext.movies);
        }

        public void newMovieList(MovieList movieList)
        {
            _movieListContext.movieLists.Add(movieList);
            _movieListContext.SaveChanges();
        }

        public List<MovieList> ReadAll()
        {
            return new List<MovieList>(_movieListContext.movieLists);
        }
    }
}
