using UserLookupService.Abstractions;
using UserLookupService.Data.Models;

namespace UserLookupService.Data;

public interface IReviewRepository
{
    Task<Models.Review> AddAsync(Abstractions.Review review, CancellationToken cancellationToken);
    Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken);
    Task<Abstractions.Review> UpdateReviewAsync(Abstractions.Review review, CancellationToken cancellationToken);

}


