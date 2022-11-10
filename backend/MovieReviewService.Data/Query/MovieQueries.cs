using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieReviewService.Abstractions;
using MovieReviewService.Abstractions.Models;
using MovieReviewService.Data.Interfaces;
using MovieReviewService.Data.Models;

namespace MovieReviewService.Data.Query;

public class MovieQueries : IMovieQuery
{
    private readonly MainContext _mainContext;
    public MovieQueries(MainContext mainContext)
    {
        _mainContext = mainContext;
    }

    public async Task<Abstractions.Movie> GetMovieAsync(Guid id, CancellationToken cancellationToken)
    {
        var movie = await _mainContext.Movies
                 .Where(m => m.Id == id)
             .SingleAsync(cancellationToken);

        return MovieModelMapper.ToBusiness(movie);
    }

    public async Task<IList<Abstractions.Movie>> GetMoviesAsync(MovieType movieType, CancellationToken cancellationToken)
    {
        var movie = await _mainContext.Movies
               .ToListAsync(cancellationToken);

        return MovieModelMapper.ToBusiness(movie);
    }
}
