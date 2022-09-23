using MovieReviewService.Abstractions;

namespace MovieReviewService.Data.Interfaces;

public interface IReviewQuery
{
    Task<Review> GetUserAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewAsync(CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewByTitleAsync(string Title, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewByTextAsync(string Text, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewAsync(int Rating, CancellationToken cancellationToken);
    Task<Review> GetReviewAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewAsync(Movie movie, CancellationToken cancellationToken);
    Task<IList<Review>> GetReviewAsync(User user, CancellationToken cancellationToken);


}