using Booky.Domain.Models.Book;

namespace Booky.Domain.Models.Review;

public class ReviewViewModel
{
    public long Id { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }

    public string BookTitle { get; set; }
}
