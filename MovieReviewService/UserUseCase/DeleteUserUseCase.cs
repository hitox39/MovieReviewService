using Microsoft.Extensions.Logging;
using MovieReviewService.Abstractions;
using MovieReviewService.Data;

namespace MovieReviewService.Application.UserUseCase;


public class DeleteUserUseCase
{
    
    private readonly ILogger<DeleteUserUseCase> _logger;
    private readonly IUserRepository _userRepository;
    
    public DeleteUserUseCase(IUserRepository userRepository, ILogger<DeleteUserUseCase> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Attempting to delete user: [{userId}]", userId);
        await _userRepository.DeleteUserAsync(userId, cancellationToken);
    }
}
