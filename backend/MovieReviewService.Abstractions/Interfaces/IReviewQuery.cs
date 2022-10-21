using MovieReviewService.Abstractions;

namespace MovieReviewService.Data.Interfaces;

public interface IReviewQuery
{
    Task<Review> GetUserAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<Review>> GetAllReviewsAsync(CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewByTitleAsync(string title, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewByTextAsync(string text, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewAsync(int rating, CancellationToken cancellationToken);
    Task<Review> GetReviewAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewAsync(Movie movie, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewAsync(User user, CancellationToken cancellationToken);


}