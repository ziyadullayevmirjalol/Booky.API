using Booky.API.Models.Book;

namespace Booky.API.Models.Review;

public class ReviewViewModel
{
    public long Id { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }

    public BookViewModel Book { get; set; }
}
