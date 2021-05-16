namespace LibraryApp.Application.Contract.Database
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        public IBookRepository Books { get; }

        public IAuthorRepository Authors { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}