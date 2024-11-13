using Booky.Domain.Models.Book;

namespace Booky.API.ApiService.Books;

public class BookApiService : IBookApiService
{
    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BookWithAouthorsViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<BookViewModel>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<BookViewModel> PostAsync(BookCreateModel model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<BookViewModel> PutAsync(long id, BookUpdateModel model)
    {
        throw new NotImplementedException();
    }
}