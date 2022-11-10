using Microsoft.EntityFrameworkCore;
using MovieReviewService.Abstractions;
using MovieReviewService.Abstractions.Interfaces;
using MovieReviewService.Data.Interfaces;
using MovieReviewService.Data.Models;

namespace MovieReviewService.Data.Query;

public class ReviewQueries : IReviewQuery
{
    private readonly MainContext _mainContext;

    public ReviewQueries(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    public async Task<IList<Abstractions.Review>> GetReviewsByRatingAsync(int rating, CancellationToken cancellationToken)
    {
        var review = await _mainContext.Reviews
        .Where(r => r.Rating == rating)
        .ToListAsync(cancellationToken);

        return ReviewModelMapper.ToBusiness(review);
    }

    public async Task<IList<Abstractions.Review>> GetAllReviewsAsync(CancellationToken cancellationToken)
    {
        var review = await _mainContext.Reviews
         .ToListAsync(cancellationToken);

        return ReviewModelMapper.ToBusiness(review);
    }

    public async Task<Abstractions.Review> GetReviewByTitleAsync(string title, CancellationToken cancellationToken)
    {
        var reviews = await _mainContext.Reviews
        .Where(r => r.Title == title)
        .SingleAsync(cancellationToken);

        return ReviewModelMapper.ToBusiness(reviews);
    }

    public async Task<Abstractions.Review> GetReviewAsync(Guid id, CancellationToken cancellationToken)
    {
        var review = await _mainContext.Reviews
       .Where(r => r.Id == id)
       .SingleAsync(cancellationToken);

        return ReviewModelMapper.ToBusiness(review);
    }

    public async Task<IList<Abstractions.Review>> GetReviewByMovieAsync(Abstractions.Movie movie, CancellationToken cancellationToken)
    {
        var review = await _mainContext.Reviews
         .Where(r => r.Movie.Id == movie.Id)
         .ToListAsync(cancellationToken);

        return ReviewModelMapper.ToBusiness(review);
    }

    public async Task<IList<Abstractions.Review>> GetReviewsByUserAsync(Abstractions.User user, CancellationToken cancellationToken)
    {
        var reviews = await _mainContext.Reviews
       .Where(r => r.User.Id == user.Id)
       .ToListAsync(cancellationToken);

        return ReviewModelMapper.ToBusiness(reviews);
    }


    public async Task<Abstractions.Review> GetReviewByUserAsync(Abstractions.User user, CancellationToken cancellationToken)
    {
        var review = await _mainContext.Reviews
       .Where(r => r.User.Id == user.Id)
       .SingleAsync(cancellationToken);

        return ReviewModelMapper.ToBusiness(review);
    }
}



