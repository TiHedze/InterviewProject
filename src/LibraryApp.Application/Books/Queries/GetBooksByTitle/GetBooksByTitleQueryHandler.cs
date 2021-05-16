namespace LibraryApp.Application.Books.Queries.GetBooksByTitle
{
    using AutoMapper;
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Responses;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetBooksByTitleQueryHandler : IRequestHandler<GetBooksByTitleQuery, PaginatedResponse<AuthorBookResponse>>
    {

        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public GetBooksByTitleQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PaginatedResponse<AuthorBookResponse>> Handle(GetBooksByTitleQuery request, CancellationToken cancellationToken)
        {
            var books = await this.unitOfWork.Books.FindBooksByTitleAsync(request.Title, request.Page, request.Size);

            return new PaginatedResponse<AuthorBookResponse>(request.Page, books.Count, this.mapper.Map<List<AuthorBookResponse>>(books));
        }
    }
}