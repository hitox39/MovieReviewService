using Microsoft.EntityFrameworkCore;
using MovieReviewService.Abstractions;
using MovieReviewService.Data.Interfaces;
using MovieReviewService.Data.Models;

namespace MovieReviewService.Data.Query;

public class ReviewQueries : IReviewQuery
{
    private readonly MainContext _dbContext;

    public ReviewQueries(MainContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IList<Abstractions.Review>> GetAllReviewsAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Abstractions.Review>> GetReviewAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Abstractions.Review>> GetReviewAsync(int rating, CancellationToken cancellationToken)
    {
        var review = await _dbContext.Reviews
        .Where(r => r.Rating == rating)
        .ToListAsync(cancellationToken);

        return ReviewModelMapper.ToBusiness(review);
    }

    public Task<Abstractions.Review> GetReviewAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Abstractions.Review>> GetReviewAsync(Abstractions.Movie movie, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Abstractions.Review>> GetReviewAsync(Abstractions.User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Abstractions.Review>> GetReviewByTextAsync(string Text, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Abstractions.Review>> GetReviewByTitleAsync(string Title, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Abstractions.Review> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}



