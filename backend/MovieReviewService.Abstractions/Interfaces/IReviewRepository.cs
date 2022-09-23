using MovieReviewService.Abstractions;

namespace MovieReviewService.Data;

public interface IReviewRepository
{
    Task<Review> AddAsync(Review review, CancellationToken cancellationToken);
    Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken);
    Task<Review> UpdateReviewAsync(Review review, CancellationToken cancellationToken);

}


