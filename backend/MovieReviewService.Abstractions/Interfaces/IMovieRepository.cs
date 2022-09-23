using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewService.Data.Interfaces
{
    public interface IMovieRepository 
    {
        Task<Abstractions.Movie> AddAsync(Abstractions.Movie movie, CancellationToken cancellationToken);
        Task DeleteMovieAsync(Guid id, CancellationToken cancellationToken);
        Task<Abstractions.Movie> UpdateUserAsync(Abstractions.Movie movie, CancellationToken cancellationToken);
    }
}
