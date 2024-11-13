namespace Booky.Domain.Models.Book;

public class BookCreateModel
{
    public string Title { get; set; }
    public string Genre { get; set; }

    public long PublisherId { get; set; }

    public List<long> AuthorsId { get; set; }
}
