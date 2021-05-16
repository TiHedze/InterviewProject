namespace LibraryApp.Infrastructure.Database.Configurations
{
    using LibraryApp.Core.Entities.Database;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(book => book.Id);

            builder.Property(book => book.Title).IsRequired();
        }
    }
}