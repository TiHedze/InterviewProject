namespace LibraryApp.Application.Responses
{
    using System;

    public class AuthorBookResponse
    {
        public Guid AuthorId { get; set; }

        public Guid Id { get; set; }

        public string Title { get; set; } = default!;
    }
}