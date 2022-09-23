using MovieReviewService.Abstractions;
using MovieReviewService.Data;

namespace MovieReviewService.Application.AddReviewUseCase;

public class AddReviewUseCase
{
    private readonly IReviewRepository _reviewRepository;
    public AddReviewUseCase(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<Review> AddReviewAsync(Review review, CancellationToken cancellationToken)
    {
        review.Id = Guid.NewGuid();

        await _reviewRepository.AddAsync(review, cancellationToken);

        return review;
    }
}
