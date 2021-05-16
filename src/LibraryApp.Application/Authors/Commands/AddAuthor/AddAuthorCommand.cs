namespace LibraryApp.Application.Authors.Commands.AddAuthor
{
    using LibraryApp.Application.Responses;
    using MediatR;

    public class AddAuthorCommand : IRequest<AuthorResponse>
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;
    }
}