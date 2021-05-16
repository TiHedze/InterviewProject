namespace LibraryApp.Infrastructure.Database.Core
{
    using LibraryApp.Application.Contract.Database;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext context;

        public UnitOfWork(
            LibraryContext libraryContext,
            IBookRepository bookRepository,
            IAuthorRepository authorRepository)
        {
            this.context = libraryContext;

            this.Books = bookRepository;
            this.Authors = authorRepository;
        }

        public IBookRepository Books { get; }

        public IAuthorRepository Authors { get; }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await this.context.SaveChangesAsync(cancellationToken);
        }
    }
}