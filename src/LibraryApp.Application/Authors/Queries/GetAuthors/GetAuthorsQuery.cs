namespace LibraryApp.Application.Authors.Queries.GetAuthors
{
    using LibraryApp.Application.Responses;
    using MediatR;

    public class GetAuthorsQuery: IRequest<PaginatedResponse<AuthorResponse>>
    {
        public GetAuthorsQuery(
            int page,
            int pageSize) 
        {
            this.Page = page;
            this.Size = pageSize;
        }

        public int Page { get; set; }

        public int Size { get; set; }

    }
}
