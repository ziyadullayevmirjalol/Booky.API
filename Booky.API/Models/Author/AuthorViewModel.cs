using Booky.API.Models.Book;

namespace Booky.API.Models.Author;

public class AuthorViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }

    public List<BookViewModel> Books { get; set; }
}

