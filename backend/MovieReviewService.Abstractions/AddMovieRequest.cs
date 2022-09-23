using MovieReviewService.Abstractions.Models;

namespace MovieReviewService.Abstractions;

public class AddMovieRequest
{
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<MovieType> MovieTypes { get; set; }


}
