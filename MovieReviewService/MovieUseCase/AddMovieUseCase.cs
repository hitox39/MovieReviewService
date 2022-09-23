using MovieReviewService.Abstractions;
using MovieReviewService.Data.Interfaces;

namespace MovieReviewService.Application.UseCase;

public class AddMovieUseCase
{
    private readonly IMovieRepository _movieRepository;
    public AddMovieUseCase(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public async Task<Movie> AddMovieAsync(Movie movie, CancellationToken cancellationToken)
    {
        movie.Id = Guid.NewGuid();

        await _movieRepository.AddAsync(movie, cancellationToken);

        return movie;
    }
}
