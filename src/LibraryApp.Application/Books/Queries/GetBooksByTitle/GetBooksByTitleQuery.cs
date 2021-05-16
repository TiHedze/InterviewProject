namespace LibraryApp.Application.Books.Queries.GetBooksByTitle
{
    using LibraryApp.Application.Responses;
    using MediatR;

    public class GetBooksByTitleQuery : IRequest<PaginatedResponse<AuthorBookResponse>>
    {
        public int Page { get; set; } = default!;

        public int Size { get; set; } = default!;

        public string Title { get; set; } = default!;
    }
}
