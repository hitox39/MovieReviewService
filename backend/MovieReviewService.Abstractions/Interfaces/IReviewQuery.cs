namespace MovieReviewService.Abstractions.Interfaces;

public interface IReviewQuery
{
    Task<IList<Review>> GetAllReviewsAsync(CancellationToken cancellationToken);
    Task<Review> GetReviewByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewsByRatingAsync(int rating, CancellationToken cancellationToken);
    Task<Review> GetReviewAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewByMovieAsync(Movie movie, CancellationToken cancellationToken);
    Task<Review> GetReviewByUserAsync(User user, CancellationToken cancellationToken);


}