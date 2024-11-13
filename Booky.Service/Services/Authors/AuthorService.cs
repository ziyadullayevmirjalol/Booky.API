using Booky.DataAccess.UnitOfWorks;
using Booky.Domain.Entities;
using Booky.Service.Exceptions;
using Booky.Service.Services.Books;

namespace Booky.Service.Services.Authors;

public class AuthorService(IBookService bookService, IUnitOfWork unitOfWork) : IAuthorService
{
    public async ValueTask<Author> CreateAsync(Author author)
    {
        var existAuthor = await unitOfWork.Authors.SelectAsync(
            expression: a => (a.FirstName == author.FirstName && a.LastName == author.LastName) && !a.IsDeleted);

        if (existAuthor is not null)
            throw new AlreadyExistException("This author is already exists!");

        var created = await unitOfWork.Authors.InsertAsync(author);
        await unitOfWork.SaveAsync();

        return created;
    }

    public async ValueTask<Author> UpdateAsync(long id, Author author)
    {
        var existAuthor = await unitOfWork.Authors.SelectAsync(
           expression: a => a.Id == id && !a.IsDeleted)
           ?? throw new NotFoundException("Author is not found");

        if (author.FirstName != "" || author.FirstName is not null)
            existAuthor.FirstName = author.FirstName;

        if (author.LastName != "" || author.LastName is not null)
            existAuthor.LastName = author.LastName;

        if (author.Biography != "" || author.Biography is not null)
            existAuthor.Biography = author.Biography;

        existAuthor.UpdatedAt = DateTime.UtcNow;

        var updated = await unitOfWork.Authors.UpdateAsync(existAuthor);
        await unitOfWork.SaveAsync();

        return updated;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existAuthor = await unitOfWork.Authors.SelectAsync(
            expression: a => a.Id == id && !a.IsDeleted)
            ?? throw new NotFoundException("Author is not found");

        await unitOfWork.Authors.DeleteAsync(existAuthor);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<Author> GetByIdAsync(long id)
    {
        var existAuthor = await unitOfWork.Authors.SelectAsync(
           expression: a => a.Id == id && !a.IsDeleted)
           ?? throw new NotFoundException("Author is not found");

        return existAuthor;
    }

    public async ValueTask<IEnumerable<Author>> GetAllAsync()
    {
        var Authors = await unitOfWork.Authors.SelectAsEnumerableAsync(
            expression: a => !a.IsDeleted,
            isTracked: false);

        return Authors;
    }
}
