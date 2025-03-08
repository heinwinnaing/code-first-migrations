namespace CodeFirstMigrations.Domain;

public class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
