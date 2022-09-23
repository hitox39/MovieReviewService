using Microsoft.Extensions.Logging;
using MovieReviewService.Abstractions;
using MovieReviewService.Data.Interfaces;

namespace MovieReviewService.Application.UserUseCase;

public class GetUserUseCase
{
    private readonly ILogger<GetUserUseCase> _logger;
    private readonly IUserQuery _userQuery;

    public GetUserUseCase(ILogger<GetUserUseCase> logger, IUserQuery userQuery)
    {
        _logger = logger;
        _userQuery = userQuery;
    }

    public async Task<User> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _userQuery.GetUserAsync(id, cancellationToken);
    }

  
}