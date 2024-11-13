using Booky.API.Extensions;
using Booky.API.Validators.Books;
using Booky.Domain.Models.Book;
using Booky.Service.Services.Books;

namespace Booky.API.ApiService.Books;

public class BookApiService(
    IBookService bookService,
    BookCreateModelValidator createModelValidator,
    BookUpdateModelValidator updateModelValidator) : IBookApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await bookService.DeleteAsync(id);
    }

    public async ValueTask<BookWithAouthorsViewModel> GetAsync(long id)
    {
        return await bookService.GetByIdAsync(id);
    }

    public async ValueTask<IEnumerable<BookViewModel>> GetAsync()
    {
        return await bookService.GetAllAsync();
    }

    public async ValueTask<BookViewModel> PostAsync(BookCreateModel model)
    {
        await createModelValidator.EnsureValidatedAsync(model);
        return await bookService.CreateAsync(model);
    }

    public async ValueTask<BookViewModel> PutAsync(long id, BookUpdateModel model)
    {
        await updateModelValidator.EnsureValidatedAsync(model);
        return await bookService.UpdateAsync(id, model);
    }
}