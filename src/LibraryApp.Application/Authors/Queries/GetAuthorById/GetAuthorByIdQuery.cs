namespace LibraryApp.Application.Authors.Queries.GetAuthorById
{
    using LibraryApp.Application.Responses;
    using MediatR;
    using System;

    public class GetAuthorByIdQuery : IRequest<AuthorResponse>
    {
        public GetAuthorByIdQuery(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}