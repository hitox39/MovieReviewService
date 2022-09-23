using Microsoft.Extensions.Logging;
using MovieReviewService.Abstractions;
using MovieReviewService.Data.Interfaces;

namespace MovieReviewService.Application.MovieUseCases;

public class GetMovieUseCase
{
    private readonly ILogger<GetMovieUseCase> _logger;
    private readonly IMovieQuery _movieQuery;

    public GetMovieUseCase(ILogger<GetMovieUseCase> logger, IMovieQuery movieQuery)
    {
        _logger = logger;
        _movieQuery = movieQuery;
    }

    public async Task<Movie> GetMovieAsync(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Attempting to get user: [{movieId}]", id);
        return await _movieQuery.GetMovieAsync(id, cancellationToken);
    }

    
}