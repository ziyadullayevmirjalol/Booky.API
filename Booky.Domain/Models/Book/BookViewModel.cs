namespace Booky.Domain.Models.Book;

public class BookViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ISBN { get; set; }

    public long PublisherId { get; set; }

    public List<long> AuthorsId { get; set; }
}