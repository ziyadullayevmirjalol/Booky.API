using Booky.Domain.Models.Book;

namespace Booky.Service.Services.Books;

public interface IBookService
{
    public ValueTask<BookViewModel> CreateAsync(BookCreateModel book);
    public ValueTask<BookViewModel> UpdateAsync(long id, BookUpdateModel book);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<BookWithAouthorsViewModel> GetByIdAsync(long id);
    public ValueTask<IEnumerable<BookViewModel>> GetAllAsync();
}
