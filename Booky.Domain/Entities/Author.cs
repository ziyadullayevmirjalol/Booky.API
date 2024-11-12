using Booky.Domain.Commons;

namespace Booky.Domain.Entities;

public class Author : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }

    public List<BookAuthor> Book_Authors { get; set; }
}
