namespace LibraryApp.Application.Books.Commands.UpdateBook
{
    using LibraryApp.Application.Responses;
    using MediatR;
    using System;

    public class UpdateBookCommand : IRequest<AuthorBookResponse>
    {
        public Guid AuthorId { get; set; }

        public Guid Id { get; set; }

        public string Title { get; set; } = default!;
    }
}
