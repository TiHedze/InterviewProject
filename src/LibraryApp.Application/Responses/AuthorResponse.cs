namespace LibraryApp.Application.Responses
{
    using System;
    using System.Collections.Generic;

    public class AuthorResponse
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public List<AuthorBookResponse> Books { get; set; } = new List<AuthorBookResponse>();
    }
}