using MovieReviewService.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewService.Data.Models;

public static class ReviewModelMapper
{
    public static Abstractions.Review ToBusiness(Review review)
    {
        return new Abstractions.Review
        {
            Id = review.Id,
            Movie = MovieModelMapper.ToBusiness(review.Movie),
            Rating = review.Rating,
            Text = review.Text,
            Title = review.Title,
            User = UserModelMapper.ToBusiness(review.User)
        };
    }
    public static Abstractions.Review ToBusiness(AddReviewRequest review)
    {
        return new Abstractions.Review
        {
            Id = review.Id,
            Movie = review.Movie,
            Rating = review.Rating,
            Text = review.Text,
            Title = review.Title,
            User = review.User
        };


    }
    public static Review ToDatabase(Abstractions.Review review)
    {
        return new Review
        {
            Id = review.Id,
            Movie = MovieModelMapper.ToDatabase(review.Movie),
            Rating = review.Rating,
            Text = review.Text,
            Title = review.Title,
            User = UserModelMapper.ToDatabase(review.User)
        };
    }

    public static IList<Abstractions.Review> ToBusiness(List<Review> reviews)
    {
        var abstractionReviews = new List<Abstractions.Review>();

        foreach (var review in reviews)
        {
            abstractionReviews.Add(ToBusiness(review));
        }

        return abstractionReviews;
    }

}



