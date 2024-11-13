using Booky.Domain.Models.Publisher;

namespace Booky.Service.Services.Publishers;

public interface IPublisherService
{
    public ValueTask<PublisherViewModel> CreateAsync(PublisherCreateModel publisher);
    public ValueTask<PublisherViewModel> UpdateAsync(long id, PublisherUpdateModel publisher);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<PublisherViewModel> GetByIdAsync(long id);
    public ValueTask<IEnumerable<PublisherViewModel>> GetAllAsync();
}
