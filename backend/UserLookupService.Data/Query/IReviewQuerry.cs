using UserLookupService.Abstractions;

namespace UserLookupService.Data;

public interface IReviewQuery
{
    Task<Abstractions.Review> GetUserAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<Abstractions.Review>> GetReviewAsync(CancellationToken cancellationToken);
    Task<IList<Abstractions.Review>> GetReviewAsync(string Title, CancellationToken cancellationToken);
    Task<IList<Abstractions.Review>> GetReviewAsync(string Text, CancellationToken cancellationToken);
    Task<IList<Abstractions.Review>> GetReviewAsync(int Rating, CancellationToken cancellationToken);
    Task<Review> GetReviewAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<Abstractions.Review>> GetReviewAsync(Movie movie, CancellationToken cancellationToken);
    Task<IList<Abstractions.Review>> GetReviewAsync(User user, CancellationToken cancellationToken);
    

}