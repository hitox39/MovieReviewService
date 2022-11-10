using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewService.Abstractions;
using MovieReviewService.Data.Models;
using MovieReviewService.Data.Interfaces;

namespace MovieReviewService.Data.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly MainContext _dbContext;
        public ReviewRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Abstractions.Review> AddAsync(Abstractions.Review review, CancellationToken cancellationToken)
        {
            await _dbContext.Reviews.AddAsync(ReviewModelMapper.ToDatabase(review), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return review;
        }

        public async Task DeleteReviewAsync(Guid id, CancellationToken cancellationToken)
        {
            var review = _dbContext.Reviews.Select(r => r.Id == id);
            _dbContext.Remove(review);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Abstractions.Review> UpdateReviewAsync(Abstractions.Review review, CancellationToken cancellationToken)
        {
            await DeleteReviewAsync(review.Id, cancellationToken);
            await _dbContext.Reviews.AddAsync(ReviewModelMapper.ToDatabase(review), cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return review;
        }

        
    }
}
