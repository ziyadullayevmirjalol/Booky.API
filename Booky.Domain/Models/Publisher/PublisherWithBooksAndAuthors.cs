namespace Booky.Domain.Models.Publisher;

public class PublisherWithBooksAndAuthors
{

    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }

    public List<BookAuthorsViewModel> BookAuthors { get; set; }
}
