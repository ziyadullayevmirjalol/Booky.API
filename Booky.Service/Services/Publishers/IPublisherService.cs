using Booky.Domain.Entities;

namespace Booky.Service.Services.Publishers;

public interface IPublisherService
{
    public ValueTask<Publisher> CreateAsync(Publisher publisher);
    public ValueTask<Publisher> UpdateAsync(long id, Publisher publisher);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<Publisher> GetByIdAsync(long id);
    public ValueTask<IEnumerable<Publisher>> GetAllAsync();
}
