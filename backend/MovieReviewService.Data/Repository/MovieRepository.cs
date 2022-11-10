using Microsoft.EntityFrameworkCore;
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

    public async Task<Abstractions.Movie> AddAsync(Abstractions.Movie movie, CancellationToken cancellationToken)
    {
        await _dbContext.Movies.AddAsync(MovieModelMapper.ToDatabase(movie), cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return movie;
    }

    public async Task DeleteMovieAsync(Guid id, CancellationToken cancellationToken)
    {
        _dbContext.Movies.Remove(new Movie
        {
            Id = id
        });
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Abstractions.Movie> GetMovieAsync(Guid id, CancellationToken cancellationToken)
    {
        var movie = await _dbContext.Movies
            .Where(m => m.Id == id)
            .SingleOrDefaultAsync(cancellationToken)
            ?? throw new ArgumentNullException(nameof(id));

        return MovieModelMapper.ToBusiness(movie);
    }

    public async Task<Abstractions.Movie> UpdateMovieAsync(Abstractions.Movie movie, CancellationToken cancellationToken)
    {
        await DeleteMovieAsync(movie.Id, cancellationToken);
        await _dbContext.Movies.AddAsync(MovieModelMapper.ToDatabase(movie), cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
        return movie;
    }
}
