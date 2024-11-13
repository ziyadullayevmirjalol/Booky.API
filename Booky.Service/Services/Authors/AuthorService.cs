using AutoMapper;
using Booky.DataAccess.UnitOfWorks;
using Booky.Domain.Entities;
using Booky.Domain.Models.Author;
using Booky.Service.Exceptions;

namespace Booky.Service.Services.Authors;

public class AuthorService(IUnitOfWork unitOfWork, IMapper mapper) : IAuthorService
{
    public async ValueTask<AuthorViewModel> CreateAsync(AuthorCreateModel author)
    {
        var existAuthor = await unitOfWork.Authors.SelectAsync(
            expression: a => (a.FirstName == author.FirstName && a.LastName == author.LastName) && !a.IsDeleted);

        if (existAuthor is not null)
            throw new AlreadyExistException("This author is already exists!");

        var created = await unitOfWork.Authors.InsertAsync(mapper.Map<Author>(author));
        await unitOfWork.SaveAsync();

        return mapper.Map<AuthorViewModel>(created);
    }

    public async ValueTask<AuthorViewModel> UpdateAsync(long id, AuthorUpdateModel author)
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

        var updated = await unitOfWork.Authors.UpdateAsync(mapper.Map<Author>(existAuthor));
        await unitOfWork.SaveAsync();

        return mapper.Map<AuthorViewModel>(updated);
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

    public async ValueTask<AuthorWithBooksViewModel> GetByIdAsync(long id)
    {
        var existAuthor = await unitOfWork.Authors.SelectAsync(
           expression: a => a.Id == id && !a.IsDeleted,
           includes: ["Book_Authors.Book"])
           ?? throw new NotFoundException("Author is not found");

        var result = new AuthorWithBooksViewModel()
        {
            Id = existAuthor.Id,
            FirstName = existAuthor.FirstName,
            LastName = existAuthor.LastName,
            Biography = existAuthor.Biography,
            BookTitles = existAuthor.Book_Authors.Select(b => b.Book.Title).ToList(),
        };

        return result;
    }

    public async ValueTask<IEnumerable<AuthorViewModel>> GetAllAsync()
    {
        var Authors = await unitOfWork.Authors.SelectAsEnumerableAsync(
            expression: a => !a.IsDeleted,
            includes: ["Book_Authors.Book"],
            isTracked: false);


        var result = Authors.Select(author => new AuthorViewModel
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName,
            Biography = author.Biography,
            BooksId = author.Book_Authors.Where(ba => ba.Book != null).Select(ba => ba.Book.Id).ToList()
        }).ToList();

        return result;
    }
}
