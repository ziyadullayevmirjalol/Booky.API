using Booky.Domain.Models.Author;

namespace Booky.API.ApiService.Authors;

public interface IAuthorApiService
{
    public ValueTask<AuthorViewModel> PostAsync(AuthorCreateModel model);
    public ValueTask<AuthorViewModel> PutAsync(long id, AuthorUpdateModel model);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<AuthorWithBooksViewModel> GetAsync(long id);
    public ValueTask<IEnumerable<AuthorViewModel>> GetAsync();
}
