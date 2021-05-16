namespace LibraryApp.Application.Authors.Commands.RemoveAuthor
{
    using LibraryApp.Application.Responses;
    using MediatR;
    using System;

    public class RemoveAuthorCommand : IRequest<AuthorResponse>
    {
        public RemoveAuthorCommand(Guid id)
        {
            this.AuthorId = id;
        }

        public Guid AuthorId { get; set; }
    }
}
