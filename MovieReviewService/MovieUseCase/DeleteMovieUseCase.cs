using Microsoft.Extensions.Logging;
using MovieReviewService.Abstractions;
using MovieReviewService.Data;
using MovieReviewService.Data.Interfaces;

namespace MovieReviewService.Application.MovieUseCase;


public class DeleteMovieUseCase
{

    private readonly ILogger<DeleteMovieUseCase> _logger;
    private readonly IMovieRepository _movieRepository;

    public DeleteMovieUseCase(IMovieRepository movieRepository, ILogger<DeleteMovieUseCase> logger)
    {
        _movieRepository = movieRepository;
        _logger = logger;
    }

    public async Task DeleteMovieAsync(Guid movieId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Attempting to delete user: [{movieId}]", movieId);
        await _movieRepository.DeleteMovieAsync(movieId, cancellationToken);
    }
}
