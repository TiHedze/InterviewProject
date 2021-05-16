
namespace LibraryApp.Application.Authors.Commands.UpdateAuthor
{

    using AutoMapper;
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, AuthorResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public UpdateAuthorCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<AuthorResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await this.unitOfWork.Authors.FindAuthorByIdSafeAsync(request.Id);

            author.ChangeName(request.FirstName, request.LastName);

            await this.unitOfWork.SaveChangesAsync(cancellationToken);

            return this.mapper.Map<AuthorResponse>(author);
        }
    }
}
