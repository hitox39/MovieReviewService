using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewService.Abstractions;

namespace MovieReviewService.Data.Models;

public static class MovieModelMapper
{
    public static Abstractions.Movie ToBusiness(Movie movie)
    {
        return new Abstractions.Movie
        {
            Title = movie.Title,
            Id = movie.Id,
            MovieTypes = movie.MovieTypes,
            ReleaseDate = movie.ReleaseDate
        };


        
    }

    /// <summary>
    /// converting a list of data movies to abstraction movies
    /// </summary>
    /// <param name="movies"></param>
    /// <returns></returns>
    public static IList<Abstractions.Movie> ToBusiness(IList<Movie> movies) 
    {
        var result = new List<Abstractions.Movie>();
        foreach (var movie in movies)
        {
            result.Add(ToBusiness(movie));
        }
        
        return result;
    }

    public static Abstractions.Movie ToBusiness(AddMovieRequest addMovieRequest)
    {
        return new Abstractions.Movie
        {
            MovieTypes = addMovieRequest.MovieTypes,
            ReleaseDate = addMovieRequest.ReleaseDate,
            Title = addMovieRequest.Title,
           
    };
    }
    public static Movie ToDatabase(Abstractions.Movie movie)
    {
        return new Movie
        {
            Id = movie.Id,
            ReleaseDate = movie.ReleaseDate,
            Title = movie.Title,
            MovieTypes = movie.MovieTypes

        };
    }
}
