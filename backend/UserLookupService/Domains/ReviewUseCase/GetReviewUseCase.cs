using UserLookupService.Abstractions;
using UserLookupService.Data;

namespace UserLookupService.Domains.ReviewUseCase;

public class GetReviewUseCase
{
    private readonly ILogger<GetReviewUseCase> _logger;
    private readonly IReviewQuery _reviewQuery;

    public GetReviewUseCase(ILogger<GetReviewUseCase> logger, IReviewQuery userQuery)
    {
        _logger = logger;
        _reviewQuery = userQuery;
    }

    public async Task<Review> GetReviewAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _reviewQuery.GetReviewAsync(id, cancellationToken);
    }
}