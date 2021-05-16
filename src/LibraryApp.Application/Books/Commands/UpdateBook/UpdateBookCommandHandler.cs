namespace LibraryApp.Application.Books.Commands.UpdateBook
{
    using AutoMapper;
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, AuthorBookResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public UpdateBookCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<AuthorBookResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await this.unitOfWork.Books.FindBookByIdSafeAsync(request.Id);

            book.ChangeTitle(request.Title);

            book.ChangeAuthor(request.AuthorId);

            await this.unitOfWork.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AuthorBookResponse>(book);

        }
    }
}
