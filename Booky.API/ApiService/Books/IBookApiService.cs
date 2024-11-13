using Booky.Domain.Models.Book;

namespace Booky.API.ApiService.Books;

public interface IBookApiService
{
    public ValueTask<BookViewModel> PostAsync(BookCreateModel model);
    public ValueTask<BookViewModel> PutAsync(long id, BookUpdateModel model);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<BookWithAouthorsViewModel> GetAsync(long id);
    public ValueTask<IEnumerable<BookViewModel>> GetAsync();
}
