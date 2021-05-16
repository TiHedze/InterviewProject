namespace LibraryApp.Application.Books.Commands.RemoveBook
{
    using LibraryApp.Application.Responses;
    using MediatR;
    using System;

    public class RemoveBookCommand : IRequest<AuthorBookResponse>
    {
     
        public RemoveBookCommand(Guid authorId, Guid bookId)
        {
            this.AuthorId = authorId;
            this.Id = bookId;
        }
        
        public Guid AuthorId { get; set; }
        public Guid Id { get; set; }
    }
}
