namespace LibraryApp.Application.Authors.Queries.GetAuthors
{
    using AutoMapper;
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Responses;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, PaginatedResponse<AuthorResponse>>
    {
        private IMapper mapper;
        private IUnitOfWork unitOfWork;

        public GetAuthorsQueryHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResponse<AuthorResponse>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await this.unitOfWork.Authors.GetAuthorsPaginatedAsync(request.Page, request.Size);

            return new PaginatedResponse<AuthorResponse>(request.Page, authors.Count, this.mapper.Map<List<AuthorResponse>>(authors));
        }
    }
}
