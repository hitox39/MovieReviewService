using Microsoft.EntityFrameworkCore;
using MovieReviewService.Abstractions;
using MovieReviewService.Data.Interfaces;
using MovieReviewService.Data.Models;

namespace MovieReviewService.Data;

public class UserQueries : IUserQuery
{
    private readonly MainContext _dbContext;
    public UserQueries(MainContext dbContext)
    {
        _dbContext = dbContext;
    }

   
    public async Task<Abstractions.User> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Where(u => u.Id == id)
            .SingleOrDefaultAsync(cancellationToken)
            ?? throw new ArgumentNullException(nameof(id));

        return UserModelMapper.ToBusiness(user);
    }

    
    public async Task<IList<Abstractions.User>> GetUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users
            .ToListAsync(cancellationToken);

        return UserModelMapper.ToBusiness(users);
    }

   
    public async Task<IList<Abstractions.User>> GetUsersAsync(string zipCode, CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users
            .Where(u => u.ZipCode == zipCode)
            .ToListAsync(cancellationToken);

        return UserModelMapper.ToBusiness(users);
    }


    public async Task<IList<Abstractions.User>> GetUsersAsync(State state, CancellationToken cancellationToken)
    {
        var users = await _dbContext.Users
            .Where(u => u.State == state)
            .ToListAsync(cancellationToken);

        return UserModelMapper.ToBusiness(users);
    }

    
}

