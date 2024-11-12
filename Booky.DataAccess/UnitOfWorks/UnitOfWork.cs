using Booky.DataAccess.Contexts;
using Booky.DataAccess.Repositories;
using Booky.Domain.Entities;

namespace Booky.DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookyDbContext context;

    public UnitOfWork(BookyDbContext context)
    {
        this.context = context;

        Authors = new Repository<Author>(context);
        Books = new Repository<Book>(context);
        Publishers = new Repository<Publisher>(context);
        Reviews = new Repository<Review>(context);
        Book_Authors = new Repository<BookAuthor>(context);
    }


    public IRepository<Author> Authors { get; }

    public IRepository<Book> Books { get; }

    public IRepository<Publisher> Publishers { get; }

    public IRepository<Review> Reviews { get; }

    public IRepository<BookAuthor> Book_Authors { get; }


    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
