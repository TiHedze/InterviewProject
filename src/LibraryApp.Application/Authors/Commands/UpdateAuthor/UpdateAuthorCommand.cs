namespace LibraryApp.Application.Authors.Commands.UpdateAuthor
{
    using LibraryApp.Application.Responses;
    using MediatR;
    using System;

    public class UpdateAuthorCommand : IRequest<AuthorResponse>
    {
        public UpdateAuthorCommand(Guid id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public Guid Id { get; set; } = default;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

    }
}
