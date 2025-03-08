using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeFirstMigrations.Persistence;

internal sealed class BookStoreDbContextFactory
    : IDesignTimeDbContextFactory<BookStoreDbContext>
{
    public BookStoreDbContext CreateDbContext(string[] args)
    {
        var modelBuilder = new DbContextOptionsBuilder<BookStoreDbContext>();
        string connectionString = args[0];
        modelBuilder.UseMySQL(connectionString);
        return new BookStoreDbContext(modelBuilder.Options);
    }
}
