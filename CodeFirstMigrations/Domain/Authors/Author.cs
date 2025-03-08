using CodeFirstMigrations.Domain.Books;

namespace CodeFirstMigrations.Domain.Authors;

public class Author
    : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public AuthorStatus Status { get; set; }

    public virtual ICollection<Book>? Books { get; set; }
}
