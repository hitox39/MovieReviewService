using Microsoft.Extensions.Logging;
using MovieReviewService.Data;

namespace MovieReviewService.Application.RevewUseCase;


public class DeleteReviewUseCase
{

    private readonly ILogger<DeleteReviewUseCase> _logger;
    private readonly IReviewRepository _reviewRepository;

    public DeleteReviewUseCase(IReviewRepository reviewRepository, ILogger<DeleteReviewUseCase> logger)
    {
        _reviewRepository = reviewRepository;
        _logger = logger;
    }

    public async Task DeleteReviewAsync(Guid reviewId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Attempting to delete review: [{reviewId}]", reviewId);
        await _reviewRepository.DeleteReviewAsync(reviewId, cancellationToken);
    }
}
