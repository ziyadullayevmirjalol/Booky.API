using Booky.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booky.DataAccess.Contexts;

public class BookyDbContext : DbContext
{

    public BookyDbContext(DbContextOptions<BookyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new
            {
                ba.BookId,
                ba.AuthorId
            });

        modelBuilder.Entity<BookAuthor>()
            .HasOne(b => b.Book)
            .WithMany(ba => ba.Book_Authors)
            .HasForeignKey(bi => bi.BookId);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(b => b.Author)
            .WithMany(ba => ba.Book_Authors)
            .HasForeignKey(bi => bi.AuthorId);
    }


    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<BookAuthor> Book_Authors { get; set; }
}
