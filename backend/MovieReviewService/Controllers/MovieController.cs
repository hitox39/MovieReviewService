using Microsoft.AspNetCore.Mvc;
using MovieReviewService.Abstractions;
using MovieReviewService.Application.MovieUseCase;
using MovieReviewService.Application.MovieUseCases;
using MovieReviewService.Application.UseCase;
using MovieReviewService.Data.Models;

namespace MovieReviewService.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{

    private readonly ILogger<MovieController> _logger;
    private readonly IServiceProvider _serviceProvider;

    public MovieController(ILogger<MovieController> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetUserById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var getMovieUseCase = _serviceProvider.GetRequiredService<GetMovieUseCase>();

        var movie = await getMovieUseCase.GetMovieAsync(id, cancellationToken);

        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie([FromBody] AddMovieRequest movie, CancellationToken cancellationToken)
    {
        var addMovieUseCase = _serviceProvider.GetRequiredService<AddMovieUseCase>();

        var createdMovie = await addMovieUseCase.AddMovieAsync(MovieModelMapper.ToBusiness(movie), cancellationToken);

        return Created($"{createdMovie.Id}", createdMovie);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMovieAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        var deleteMovieUseCase = _serviceProvider.GetRequiredService<DeleteMovieUseCase>();

        await deleteMovieUseCase.DeleteMovieAsync(id, cancellationToken);

        return NoContent();

    }

    [HttpPut]
    public async Task<IActionResult> UpdateMovie([FromBody] Abstractions.Movie movie, CancellationToken cancellationToken)
    {

        var updateMovieUseCase = _serviceProvider.GetRequiredService<UpdateMovieUseCase>();

        var updatedMovie = await updateMovieUseCase.UpdateMovieAsync(movie, cancellationToken);

        return Ok();
    }
}

