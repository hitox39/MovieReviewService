using MovieReviewService.Abstractions;
using MovieReviewService.Data.Interfaces;

namespace MovieReviewService.Application.MovieUseCase
{
    public class UpdateMovieUseCase
    {
        private readonly IMovieRepository _movieRepository;

        public UpdateMovieUseCase(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }


        public async Task<Movie> UpdateMovieAsync(Movie movie, CancellationToken cancellationToken)
        {
            
            var updatedMovie = await _movieRepository.UpdateUserAsync(movie, cancellationToken);

            return updatedMovie;
        }

        
    }
}
