using AutoMapper;
using Booky.API.Models.Author;
using Booky.API.Validators.Authors;
using Booky.Service.Services.Authors;

namespace Booky.API.ApiService.Authors;

public interface IAuthorApiService
{
    public ValueTask<AuthorViewModel> PostAsync(AuthorCreateModel model);
    public ValueTask<AuthorViewModel> PutAsync(long id, AuthorUpdateModel model);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<AuthorViewModel> GetAsync(long id);
    public ValueTask<IEnumerable<AuthorViewModel>> GetAsync();

}
public class AuthorApiService(
    IMapper mapper,
    IAuthorService authorService,
    AuthorCreateModelValidator createModelValidator,
    AuthorUpdateModelValidator updateModelValidator) : IAuthorApiService
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await authorService.DeleteAsync(id);
    }

    public async ValueTask<AuthorViewModel> GetAsync(long id)
    {
        var author = await authorService.GetByIdAsync(id);
        var result=  mapper.Map<AuthorViewModel>(author);
        
    }

    public ValueTask<IEnumerable<AuthorViewModel>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<AuthorViewModel> PostAsync(AuthorCreateModel model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AuthorViewModel> PutAsync(long id, AuthorUpdateModel model)
    {
        throw new NotImplementedException();
    }
}
