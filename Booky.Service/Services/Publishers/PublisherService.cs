using Booky.Domain.Entities;

namespace Booky.Service.Services.Publishers;

public class PublisherService : IPublisherService
{
    public ValueTask<Publisher> CreateAsync(Publisher publisher)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<Publisher>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<Publisher> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Publisher> UpdateAsync(long id, Publisher publisher)
    {
        throw new NotImplementedException();
    }
}
