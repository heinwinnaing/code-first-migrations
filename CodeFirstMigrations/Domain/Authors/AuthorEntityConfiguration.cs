using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirstMigrations.Domain.Authors;

public class AuthorEntityConfiguration
    : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("authors");
        builder.HasKey(a => a.Id);
        builder.HasIndex(i => i.Email, "idx_authors_email")
            .IsUnique();

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("char(36)")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(a => a.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(a => a.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Phone)
            .HasColumnName("phone")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("datetime(4)")
            .HasDefaultValueSql("(utc_timestamp)")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("datetime(4)");

        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasColumnType("enum('active','inactive')")
            .IsRequired();

        builder.HasMany(p => p.Books)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId);

        //var authors = new Author[]
        //{
        //    new Author { Name = "John", Email = "john@mailinator.com", Status = AuthorStatus.Active },
        //    new Author { Name = "William", Email = "william@mailinator.com", Status = AuthorStatus.Active }
        //};
        //builder.HasData(authors);
    }
}
