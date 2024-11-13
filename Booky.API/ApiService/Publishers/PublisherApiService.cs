using Booky.API.Extensions;
using Booky.API.Validators.Publishers;
using Booky.Domain.Models.Publisher;
using Booky.Service.Services.Publishers;

namespace Booky.API.ApiService.Publishers;

public class PublisherApiService(
    IPublisherService publisherService,
    PublisherCreateModelValidator createModelValidator,
    PublisherUpdateModelValidator updateModelValidator) : IPublisherApiServce
{
    public async ValueTask<bool> DeleteAsync(long id)
    {
        return await publisherService.DeleteAsync(id);
    }

    public async ValueTask<PublisherViewModel> GetAsync(long id)
    {
        return await publisherService.GetByIdAsync(id);
    }

    public async ValueTask<IEnumerable<PublisherViewModel>> GetAsync()
    {
        return await publisherService.GetAllAsync();
    }

    public async ValueTask<PublisherViewModel> PostAsync(PublisherCreateModel model)
    {
        await createModelValidator.EnsureValidatedAsync(model);
        return await publisherService.CreateAsync(model);
    }

    public async ValueTask<PublisherViewModel> PutAsync(long id, PublisherUpdateModel model)
    {
        await updateModelValidator.EnsureValidatedAsync(model);
        return await publisherService.UpdateAsync(id, model);
    }
}
