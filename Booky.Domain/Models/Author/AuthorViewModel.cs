using Booky.Domain.Models.Book;

namespace Booky.Domain.Models.Author;

public class AuthorViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }

    public List<long> BooksId { get; set; }
}

