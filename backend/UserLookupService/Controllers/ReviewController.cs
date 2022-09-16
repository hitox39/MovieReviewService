using Microsoft.AspNetCore.Mvc;
using UserLookupService.Abstractions;
using UserLookupService.Data.Models;
using UserLookupService.Domains.UserUseCase;

namespace UserLookupService.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{

    private readonly ILogger<ReviewController> _logger;
    private readonly IServiceProvider _serviceProvider;

    public ReviewController(ILogger<ReviewController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var getReviewUseCase = _serviceProvider.GetRequiredService<GetUserUseCase>();

        var review = await getReviewUseCase.GetReviewAsync(id, cancellationToken);

        return Ok(review);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] AddUserRequest user, CancellationToken cancellationToken)
    {
        var addUserUseCase = _serviceProvider.GetRequiredService<AddUserUseCase>();

        var createdUser = await addUserUseCase.AddUserAsync(UserModelMapper.ToBusiness(user), cancellationToken);

        return Created($"{createdUser.Id}", createdUser);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var deleteUserUseCase = _serviceProvider.GetRequiredService<DeleteUserUseCase>();

        await deleteUserUseCase.DeleteUserAsync(id, cancellationToken);

        return NoContent();

    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] Abstractions.User user, CancellationToken cancellationToken)
    {

        var updateUserUseCase = _serviceProvider.GetRequiredService<UpdateUserUseCase>();

        var updatedUser = await updateUserUseCase.UpdateUserAsync(user, cancellationToken);

        return Ok();
    }
}

