using Booky.Domain.Commons;

namespace Booky.Domain.Entities;

public class Book : Auditable
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public DateTime PublishedDate { get; set; }
    public string ISBN { get; set; }

    public long PublisherId { get; set; }
    public Publisher Publisher { get; set; }

    public List<BookAuthor> Book_Authors { get; set; }
}

