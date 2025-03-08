using CodeFirstMigrations.Domain.Authors;

namespace CodeFirstMigrations.Domain.Books;

public class Book
    : BaseEntity
{
    public Guid? AuthorId { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateOnly? ReleasedOn { get; set; }
    public BookStatus Status { get; set; }

    public virtual Author? Author { get; set; }
}
