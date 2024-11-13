using Booky.Domain.Models.Publisher;

namespace Booky.API.ApiService.Publishers;

public class PublisherApiService : IPublisherApiServce
{
    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PublisherViewModel> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<PublisherViewModel>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<PublisherViewModel> PostAsync(PublisherCreateModel model)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PublisherViewModel> PutAsync(long id, PublisherUpdateModel model)
    {
        throw new NotImplementedException();
    }
}
