using AutoMapper;
using Booky.DataAccess.UnitOfWorks;
using Booky.Domain.Entities;
using Booky.Domain.Models.Book;
using Booky.Service.Exceptions;
using Booky.Service.Extensions;

namespace Booky.Service.Services.Books;

public class BookService(IUnitOfWork unitOfWork, IMapper mapper) : IBookService
{
    public async ValueTask<BookViewModel> CreateAsync(BookCreateModel book)
    {
        var existBook = await unitOfWork.Books.SelectAsync(
            expression: b => (b.Title == book.Title && b.Genre == book.Genre) && !b.IsDeleted);

        if (existBook is not null)
            throw new AlreadyExistException($"Book with Title ({book.Title}) and Genre ({book.Genre}) already exists!");

        var existPublisher = await unitOfWork.Publishers.SelectAsync(
            expression: p => p.Id == book.PublisherId && !p.IsDeleted)
            ?? throw new NotFoundException($"Publisher with ID ({book.PublisherId}) does not exist!");

        var createdBook = mapper.Map<Book>(book);
        createdBook.ISBN = ISBNGenerator.GenerateISBN13();
        createdBook.PublishedDate = DateTime.UtcNow;

        var authors = await unitOfWork.Authors.SelectAsEnumerableAsync(
            expression: a => book.AuthorsId.Contains(a.Id) && !a.IsDeleted);

        var existingAuthorIds = authors.Select(a => a.Id).ToHashSet();
        var missingAuthorIds = book.AuthorsId.Where(id => !existingAuthorIds.Contains(id)).ToList();

        if (missingAuthorIds.Any())
            throw new NotFoundException($"Authors with IDs ({string.Join(", ", missingAuthorIds)}) do not exist!");

        createdBook = await unitOfWork.Books.InsertAsync(createdBook);
        createdBook.Book_Authors = authors.Select(a => new BookAuthor { BookId = createdBook.Id, AuthorId = a.Id }).ToList();
        await unitOfWork.SaveAsync();

        var result = new BookViewModel
        {
            Id = createdBook.Id,
            Title = createdBook.Title,
            Genre = createdBook.Genre,
            ISBN = createdBook.ISBN,
            PublisherId = existPublisher.Id,
            AuthorsId = authors.Select(a => a.Id).ToList()
        };

        return result;
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

    public async ValueTask<IEnumerable<BookViewModel>> GetAllAsync()
    {
        var Books = await unitOfWork.Books.SelectAsEnumerableAsync(
            expression: b => !b.IsDeleted,
            isTracked: false,
            includes: ["Book_Authors.Author"]);

        var result = Books.Select(book => new BookViewModel
        {
            Id = book.Id,
            Title = book.Title,
            Genre = book.Genre,
            PublishedDate = book.PublishedDate,
            ISBN = book.ISBN,
            PublisherId = book.PublisherId,
            AuthorsId = book.Book_Authors.Where(ba => ba.Author != null).Select(ba => ba.Author.Id).ToList()
        }).ToList();

        return result;
    }

    public async ValueTask<BookWithAouthorsViewModel> GetByIdAsync(long id)
    {
        var existBook = await unitOfWork.Books.SelectAsync(
          expression: b => b.Id == id && !b.IsDeleted,
          includes: ["Book_Authors.Author", "Publisher"])
          ?? throw new NotFoundException($"Book with Id ({id}) is not found!");

        var result = new BookWithAouthorsViewModel()
        {
            Id = existBook.Id,
            Genre = existBook.Genre,
            ISBN = existBook.ISBN,
            Title = existBook.Title,
            PublishedDate = existBook.PublishedDate,
            PublisherName = existBook.Publisher.Name,

            AuthorsName = existBook.Book_Authors.Select(a => a.Author.FirstName + " " + a.Author.LastName).ToList(),
        };
        return result;
    }

    public async ValueTask<BookViewModel> UpdateAsync(long id, BookUpdateModel book)
    {
        var existBook = await unitOfWork.Books.SelectAsync(
          expression: b => b.Id == id && !b.IsDeleted)
          ?? throw new NotFoundException($"Book with Id ({id}) is not found!");

        if (book.Title != "" || book.Title is not null)
            existBook.Genre = book.Genre;

        if (book.Genre != "" || book.Genre is not null)
            existBook.Genre = book.Genre;

        existBook.UpdatedAt = DateTime.UtcNow;

        var updated = await unitOfWork.Books.UpdateAsync(existBook);
        await unitOfWork.SaveAsync();

        return mapper.Map<BookViewModel>(updated);
    }
}