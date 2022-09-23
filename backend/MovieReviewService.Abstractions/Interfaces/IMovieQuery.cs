using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewService.Abstractions;
using MovieReviewService.Abstractions.Models;
using MovieReviewService.Data.Interfaces;

namespace MovieReviewService.Data.Interfaces
{
    public interface IMovieQuery
    {
        Task<Movie> GetMovieAsync(Guid id, CancellationToken cancellationToken);
        Task<IList<Movie>> GetMoviesAsync(MovieType movieType, CancellationToken cancellationToken);
    }
}
