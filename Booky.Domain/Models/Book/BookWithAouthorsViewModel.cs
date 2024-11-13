namespace Booky.Domain.Models.Book;

public class BookWithAouthorsViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ISBN { get; set; }

    public string PublisherName { get; set; }

    public List<string> AuthorsName { get; set; }
}
