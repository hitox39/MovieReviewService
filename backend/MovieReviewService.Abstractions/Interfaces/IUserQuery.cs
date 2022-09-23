using MovieReviewService.Abstractions;

namespace MovieReviewService.Data.Interfaces;

public interface IUserQuery
{
    Task<User> GetUserAsync(Guid id, CancellationToken cancellationToken);
    Task<IList<User>> GetUsersAsync(CancellationToken cancellationToken);
    Task<IList<User>> GetUsersAsync(State state, CancellationToken cancellationToken);
    Task<IList<User>> GetUsersAsync(string zipCode, CancellationToken cancellationToken);
}