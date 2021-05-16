namespace LibraryApp.Application.Authors.Queries.GetAuthorById
{
    using AutoMapper;
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Responses;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorResponse>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAuthorByIdQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AuthorResponse> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await this.unitOfWork.Authors.FindAuthorByIdSafeAsync(request.Id);

            return this.mapper.Map<AuthorResponse>(author);
        }
    }
}