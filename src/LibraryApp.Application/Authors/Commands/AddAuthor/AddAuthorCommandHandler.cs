namespace LibraryApp.Application.Authors.Commands.AddAuthor
{
    using AutoMapper;
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Responses;
    using LibraryApp.Core.Entities.Database;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    internal class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AuthorResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public AddAuthorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AuthorResponse> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author(request.FirstName, request.LastName);

            this.unitOfWork.Authors.AddAuthor(author);

            await this.unitOfWork.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AuthorResponse>(author);
        }
    }
}