using CodeFirstMigrations.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CodeFirstMigrations.Domain.Books;

internal sealed class BookEntityConfiguration
    : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");
        builder.HasKey(x => x.Id);
        builder.HasIndex(i => i.AuthorId, "idx_books_author_id");

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("char(36)")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(p => p.AuthorId)
            .HasColumnName("author_id")
            .HasColumnType("char(36)")
            .IsRequired();

        builder.Property(p => p.Title)
            .HasColumnName("title")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("description")
            .HasColumnType("nvarchar(2000)")
            .HasMaxLength(2000);

        builder.Property(p => p.ReleasedOn)
            .HasColumnName("released_on")
            .HasColumnType("date")
            .HasConversion<DateOnlyConverter, DateOnlyComparer>();

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

        builder.HasOne(p => p.Author)
            .WithMany(p => p.Books)
            .HasForeignKey(p => p.AuthorId);
    }
}
