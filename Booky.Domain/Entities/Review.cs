using Booky.Domain.Commons;

namespace Booky.Domain.Entities;

public class Review : Auditable
{
    public string Content { get; set; }
    public int Rating { get; set; }

    public long BookId { get; set; }
    public Book Book { get; set; }
}
