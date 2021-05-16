namespace LibraryApp.Application.Books.Queries.GetBooks
{
    using AutoMapper;
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Responses;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PaginatedResponse<AuthorBookResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        public GetBooksQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PaginatedResponse<AuthorBookResponse>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await this.unitOfWork.Books.GetBooksPaginatedAsync(request.Page, request.Size);

            return new PaginatedResponse<AuthorBookResponse>(request.Page, books.Count, this.mapper.Map<List<AuthorBookResponse>>(books));
        }

    }
}
