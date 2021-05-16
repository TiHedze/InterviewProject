namespace LibraryApp.Application.Books.Queries.GetBooks
{
    using LibraryApp.Application.Responses;
    using MediatR;

    public class GetBooksQuery : IRequest<PaginatedResponse<AuthorBookResponse>>
    {
        public GetBooksQuery(int page, int size)
        {
            this.Page = page;
            this.Size = size;
        }

        public int Page { get; set; }

        public int Size { get; set; }
    }
}
