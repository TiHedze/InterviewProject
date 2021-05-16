namespace LibraryApp.Application.Authors.Commands.RemoveAuthor
{
    using AutoMapper;
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand, AuthorResponse>
    {

        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public RemoveAuthorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<AuthorResponse> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await this.unitOfWork.Authors.FindAuthorByIdSafeAsync(request.AuthorId);

            this.unitOfWork.Authors.DeleteAuthor(author);

            await this.unitOfWork.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AuthorResponse>(author);
        }
    }
}
