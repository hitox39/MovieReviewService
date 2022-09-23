using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewService.Data.Interfaces;
using MovieReviewService.Data.Models;

namespace MovieReviewService.Data.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly MainContext _dbContext;


    public MovieRepository(MainContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Abstractions.Movie> AddAsync(Abstractions.Movie movie, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMovieAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Abstractions.Movie> GetMovieAsync(Guid id, CancellationToken cancellationToken)
    {
        var movie = await _dbContext.Movies
            .Where(m => m.Id == id)
            .SingleOrDefaultAsync(cancellationToken)
            ?? throw new ArgumentNullException(nameof(id));

        return MovieModelMapper.ToBusiness(movie);
    }

    public Task<Abstractions.Movie> UpdateUserAsync(Abstractions.Movie movie, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
