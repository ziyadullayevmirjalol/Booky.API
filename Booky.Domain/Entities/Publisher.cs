using Booky.Domain.Commons;

namespace Booky.Domain.Entities;

public class Publisher : Auditable
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactNumber { get; set; }

    public List<Book> Books { get; set; }
}
