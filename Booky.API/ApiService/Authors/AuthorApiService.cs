using Booky.API.Extensions;
using Booky.API.Validators.Authors;
using Booky.Domain.Models.Author;
using Booky.Service.Services.Authors;

namespace Booky.API.ApiService.Authors;

public class AuthorApiService(
    IAuthorService authorService,
    AuthorCreateModelValidator createModelValidator,
    AuthorUpdateModelValidator updateModelValidator) : IAuthorApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await authorService.DeleteAsync(id);
    }

    public async ValueTask<AuthorWithBooksViewModel> GetAsync(long id)
    {
        return await authorService.GetByIdAsync(id);

    }

    public async ValueTask<IEnumerable<AuthorViewModel>> GetAsync()
    {
        return await authorService.GetAllAsync();
    }

    public async ValueTask<AuthorViewModel> PostAsync(AuthorCreateModel model)
    {
        await createModelValidator.EnsureValidatedAsync(model);
        return await authorService.CreateAsync(model);
    }

    public async ValueTask<AuthorViewModel> PutAsync(long id, AuthorUpdateModel model)
    {
        await updateModelValidator.EnsureValidatedAsync(model);
        return await authorService.UpdateAsync(id, model);
    }
}
