namespace LibraryApp.Infrastructure.Database.Configurations
{
    using LibraryApp.Core.Entities.Database;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(author => author.Id);

            builder.Property(author => author.FirstName).IsRequired();

            builder.Property(author => author.LastName).IsRequired();

            builder
                .HasMany(author => author.Books)
                .WithOne()
                .HasForeignKey(foreignKeyExpression => foreignKeyExpression.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}