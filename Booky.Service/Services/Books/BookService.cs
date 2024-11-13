using Booky.Domain.Entities;

namespace Booky.Service.Services.Books;

public class BookService : IBookService
{
    public ValueTask<Book> CreateAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<Book> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Book> UpdateAsync(long id, Book book)
    {
        throw new NotImplementedException();
    }
}