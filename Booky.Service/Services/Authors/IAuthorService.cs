using Booky.Domain.Models.Author;

namespace Booky.Service.Services.Authors;

public interface IAuthorService
{
    public ValueTask<AuthorViewModel> CreateAsync(AuthorCreateModel author);
    public ValueTask<AuthorViewModel> UpdateAsync(long id, AuthorUpdateModel author);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<AuthorWithBooksViewModel> GetByIdAsync(long id);
    public ValueTask<IEnumerable<AuthorViewModel>> GetAllAsync();
}

