using Microsoft.AspNetCore.Mvc;
using MovieReviewService.Abstractions;
using MovieReviewService.Application.ReviewUseCase;
using MovieReviewService.Application.MovieUseCases;
using MovieReviewService.Application.UseCase;
using MovieReviewService.Data.Models;
using MovieReviewService.Application.AddReviewUseCase;
using MovieReviewService.Application.RevewUseCase;

namespace MovieReviewService.Controllers;

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
    public async Task<IActionResult> GetReviewByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var getReviewUseCase = _serviceProvider.GetRequiredService<GetReviewUseCase>();

        var review = await getReviewUseCase.GetReviewAsync(id, cancellationToken);

        return Ok(review);
    }

    [HttpPost]
    public async Task<IActionResult> AddReviewAsync([FromBody] AddReviewRequest review, CancellationToken cancellationToken)
    {
        var addReviewUseCase = _serviceProvider.GetRequiredService<AddReviewUseCase>();

        var createdReview = await addReviewUseCase.AddReviewAsync(ReviewModelMapper.ToBusiness(review), cancellationToken);

        return Created($"{createdReview.Id}", createdReview);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteReviewAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var deleteReviewUseCase = _serviceProvider.GetRequiredService<DeleteReviewUseCase>();

        await deleteReviewUseCase.DeleteReviewAsync(id, cancellationToken);

        return NoContent();

    }

    [HttpPut]
    public async Task<IActionResult> UpdateReviewAsync([FromBody] Abstractions.Review review, CancellationToken cancellationToken)
    {

        var updateReviewUseCase = _serviceProvider.GetRequiredService<UpdateReviewUseCase>();

        var updatedReview = await updateReviewUseCase.UpdateReviewAsync(review, cancellationToken);

        return Ok();
    }
}

