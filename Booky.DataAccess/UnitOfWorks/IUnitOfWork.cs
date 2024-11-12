using Booky.DataAccess.Repositories;
using Booky.Domain.Entities;

namespace Booky.DataAccess.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{

    IRepository<Author> Authors { get; }
    IRepository<Book> Books { get; }
    IRepository<Publisher> Publishers { get; }
    IRepository<Review> Reviews { get; }

    IRepository<BookAuthor> Book_Authors { get; }

    ValueTask<bool> SaveAsync();
}
