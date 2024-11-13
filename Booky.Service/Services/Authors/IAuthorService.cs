using Booky.Domain.Entities;

namespace Booky.Service.Services.Authors;

public interface IAuthorService
{
    public ValueTask<Author> CreateAsync(Author author);
    public ValueTask<Author> UpdateAsync(long id, Author author);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<Author> GetByIdAsync(long id);
    public ValueTask<IEnumerable<Author>> GetAllAsync();
}

