using MovieReviewService.Abstractions;

namespace MovieReviewService.Data.Models;

public class User
{
    public Guid Id { get; set; }
    public string? GivenName { get; set; } = "";
    public string? FamilyName { get; set; } = "";
    public string? Email { get; set; } = "";
    public DateTime DateOfBirth { get; set; }

    public string? Country { get; set; } = "";
    public string? Address { get; set; } = "";
    public State State { get; set; } = State.None;
    public string? ZipCode { get; set; } = "";
    public string? FavoriteMovie { get; set; } = "";
}
