using MovieReviewService.Abstractions;
using MovieReviewService.Data;


namespace MovieReviewService.Application.UserUseCase;


public class UpdateUserUseCase
{
    private readonly IUserRepository _userRepository;

    public UpdateUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<Abstractions.User> UpdateUserAsync(Abstractions.User user, CancellationToken cancellationToken)
    {
        
        var updatedUser = await _userRepository.UpdateUserAsync(user, cancellationToken);

        return updatedUser;
    }





}


