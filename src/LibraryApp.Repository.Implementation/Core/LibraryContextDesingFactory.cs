namespace LibraryApp.Infrastructure.Database.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using System.Reflection;

    public class LibraryContextDesingFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<LibraryContext> optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();

            optionsBuilder
                .UseSqlServer("Server=.; Database=TilenLibrary;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new LibraryContext(optionsBuilder.Options);
        }
    }
}