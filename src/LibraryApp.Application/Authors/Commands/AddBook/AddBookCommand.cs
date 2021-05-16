namespace LibraryApp.Application.Authors.Commands.AddBook
{
    using MediatR;
    using System;

    public class AddBookCommand : IRequest
    {
        public Guid AuthorId { get; set; }

        public string Title { get; set; } = default!;
    }
}