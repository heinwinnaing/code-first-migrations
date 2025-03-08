using CodeFirstMigrations.Domain.Authors;
using CodeFirstMigrations.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstMigrations.Persistence;

public class BookStoreDbContext
    : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookEntityConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorEntityConfiguration).Assembly);
    }
}
