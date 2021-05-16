namespace LibraryApp.Application.Contract.Database
{
    using LibraryApp.Core.Entities.Database;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorRepository
    {
        Task<Author> FindAuthorByIdSafeAsync(Guid id);

        Task<Author?> FindAuthorByFullNameAsync(string firstName, string lastName);

        Task<List<Author>> GetAuthorsPaginatedAsync(int page, int size);

        Task<List<Author>> FindAuthorsByFirstNameAsync(string firstName);

        Task<List<Author>> FindAuthorsByLastNameAsync(string lastName);

        Author AddAuthor(Author author);

        Author UpdateAuthor(Author author);

        void DeleteAuthor(Author author);
    }
}