

namespace MovieReviewService.Data.Models;


    public class Review
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public Movie Movie { get; set; }
        public User User { get; set; }
        
    }

