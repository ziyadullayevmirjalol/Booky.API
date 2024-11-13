namespace Booky.API.Models.Review;

public class ReviewCreateModel
{
    public string Content { get; set; }
    public int Rating { get; set; }

    public long BookId { get; set; }
}
