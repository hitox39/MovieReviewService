using MovieReviewService.Data;

namespace MovieReviewService.Application.ReviewUseCase
{
    public class UpdateReviewUseCase
    {
        private readonly IReviewRepository _reviewRepository;

        public UpdateReviewUseCase(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }


        public async Task<Abstractions.Review> UpdateReviewAsync(Abstractions.Review review, CancellationToken cancellationToken)
        {

            var updatedReview = await _reviewRepository.UpdateReviewAsync(review, cancellationToken);

            return updatedReview;
        }





    }

}
