namespace LibraryApp.Application.Books.Commands.RemoveBook
{
    using AutoMapper;
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, AuthorBookResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public RemoveBookCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AuthorBookResponse> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            var author = await this.unitOfWork.Authors.FindAuthorByIdSafeAsync(request.AuthorId);

            var book = await this.unitOfWork.Books.FindBookByIdSafeAsync(request.Id);

            author.RemoveBook(request.Id);

            await this.unitOfWork.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AuthorBookResponse>(book);
        }
    }
}
