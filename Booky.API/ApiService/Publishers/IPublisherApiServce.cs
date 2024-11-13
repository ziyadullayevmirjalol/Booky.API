using Booky.API.Models.Publisher;

namespace Booky.API.ApiService.Publishers;

public interface IPublisherApiServce
{
    public ValueTask<PublisherViewModel> PostAsync(PublisherCreateModel model);
    public ValueTask<PublisherViewModel> PutAsync(long id, PublisherUpdateModel model);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<PublisherViewModel> GetAsync(long id);
    public ValueTask<IEnumerable<PublisherViewModel>> GetAsync();

}
