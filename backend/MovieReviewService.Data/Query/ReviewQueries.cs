using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewService.Abstractions;
using MovieReviewService.Data.Interfaces;

namespace MovieReviewService.Data.Query
{
    internal class ReviewQueries : IReviewQuery

    {
        public Task<IList<Review>> GetReviewAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Review>> GetReviewAsync(int Rating, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetReviewAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Review>> GetReviewAsync(Movie movie, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Review>> GetReviewAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Review>> GetReviewByTextAsync(string Text, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Review>> GetReviewByTitleAsync(string Title, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetUserAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
