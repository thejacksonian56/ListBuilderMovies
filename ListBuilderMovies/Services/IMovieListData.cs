using ListBuilderMovies.Models;
using System.Collections.Generic;

namespace ListBuilderMovies.Services
{
    public interface IMovieListData
    {
        List<MovieList> getMovieLists { get; set; }
        List<MovieList> ReadAll();
        MovieList getMovieListById(int? id);
        void newMovieList(MovieList movieList);
        void editMovieList(MovieList movieList);
        void deleteMovieList(int? id);
        void addMovie(Movie movie);


    }
}
