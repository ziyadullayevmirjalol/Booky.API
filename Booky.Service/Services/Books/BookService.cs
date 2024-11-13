using Booky.DataAccess.UnitOfWorks;
using Booky.Domain.Entities;
using Booky.Service.Exceptions;
using Booky.Service.Extensions;
using Booky.Service.Services.Authors;

namespace Booky.Service.Services.Books;

public class BookService(IAuthorService authorService, IUnitOfWork unitOfWork) : IBookService
{
    public async ValueTask<Book> CreateAsync(Book book)
    {
        var existBook = await unitOfWork.Books.SelectAsync(
            expression: b => (b.Title == book.Title && b.Genre == book.Genre) && !b.IsDeleted);

        if (existBook is not null)
            throw new AlreadyExistException($"Book with Title ({book.Title} and Genere ({book.Genre}) is already exists!)");

        book.ISBN = ISBNGenerator.GenerateISBN13();
        var created = await unitOfWork.Books.InsertAsync(book);
        await unitOfWork.SaveAsync();

        return created;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existBook = await unitOfWork.Books.SelectAsync(
            expression: b => b.Id == id && !b.IsDeleted)
            ?? throw new NotFoundException($"Book with Id ({id}) is not found!");

        await unitOfWork.Books.DeleteAsync(existBook);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<Book>> GetAllAsync()
    {
        var Books = await unitOfWork.Books.SelectAsEnumerableAsync(
            expression: b => !b.IsDeleted,
            isTracked: false);

        return Books;
    }

    public async ValueTask<Book> GetByIdAsync(long id)
    {
        var existBook = await unitOfWork.Books.SelectAsync(
          expression: b => b.Id == id && !b.IsDeleted)
          ?? throw new NotFoundException($"Book with Id ({id}) is not found!");

        return existBook;
    }

    public async ValueTask<Book> UpdateAsync(long id, Book book)
    {
        var existBook = await unitOfWork.Books.SelectAsync(
          expression: b => b.Id == id && !b.IsDeleted)
          ?? throw new NotFoundException($"Book with Id ({id}) is not found!");

        if (book.Title != "" || book.Title is not null)
            existBook.Genre = book.Genre;

        if (book.Genre != "" || book.Genre is not null)
            existBook.ISBN = book.ISBN;
        existBook.UpdatedAt = DateTime.UtcNow;

        var updated = await unitOfWork.Books.UpdateAsync(existBook);
        await unitOfWork.SaveAsync();

        return updated;
    }
}