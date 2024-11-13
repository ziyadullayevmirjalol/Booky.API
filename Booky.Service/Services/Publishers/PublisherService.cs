using Booky.DataAccess.UnitOfWorks;
using Booky.Domain.Entities;
using Booky.Service.Services.Books;

namespace Booky.Service.Services.Publishers;

public class PublisherService(IBookService bookService, IUnitOfWork unitOfWork) : IPublisherService
{
    public ValueTask<Publisher> CreateAsync(Publisher publisher)
    {
        
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
