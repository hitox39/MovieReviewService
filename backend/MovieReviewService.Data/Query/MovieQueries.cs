using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewService.Abstractions;
using MovieReviewService.Abstractions.Models;
using MovieReviewService.Data.Interfaces;

namespace MovieReviewService.Data.Query;

public class MovieQueries : IMovieQuery
{
    private readonly MainContext _mainContext;
    public MovieQueries(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public Task<Movie> GetMovieAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Movie>> GetMoviesAsync(MovieType movieType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
