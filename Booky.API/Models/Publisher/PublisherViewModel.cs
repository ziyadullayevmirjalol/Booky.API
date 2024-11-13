using Booky.API.Models.Book;

namespace Booky.API.Models.Publisher;

public class PublisherViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }

    public List<BookViewModel> Books { get; set; }
}
