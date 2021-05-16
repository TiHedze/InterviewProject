namespace LibraryApp.Application.Authors.Commands.AddBook
{
    using LibraryApp.Application.Contract.Database;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AddBookCommandHandler : AsyncRequestHandler<AddBookCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddBookCommandHandler(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected override async Task Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var author = await this.unitOfWork.Authors.FindAuthorByIdSafeAsync(request.AuthorId);

            author.AddBook(request.Title);

            await this.unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}