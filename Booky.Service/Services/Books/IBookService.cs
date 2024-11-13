using Booky.Domain.Entities;

namespace Booky.Service.Services.Books;

public interface IBookService
{
    public ValueTask<Book> CreateAsync(Book book);
    public ValueTask<Book> UpdateAsync(long id, Book book);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<Book> GetByIdAsync(long id);
    public ValueTask<IEnumerable<Book>> GetAllAsync();
}
