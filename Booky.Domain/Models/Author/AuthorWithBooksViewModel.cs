namespace Booky.Domain.Models.Author;

public class AuthorWithBooksViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }

    public List<string> BookTitles { get; set; }
}
