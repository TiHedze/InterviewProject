namespace LibraryApp.Infrastructure.Database.Repositories
{
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Application.Contract.Exceptions;
    using LibraryApp.Core.Entities.Database;
    using LibraryApp.Infrastructure.Database.Core;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AuthorRepository : IAuthorRepository
    {
        private readonly DbSet<Author> authors;

        public AuthorRepository(LibraryContext context)
        {
            this.authors = context.Set<Author>();
        }

        public Author AddAuthor(Author author)
        {
            this.authors.Add(author);

            return author;
        }

        public void DeleteAuthor(Author author)
        {
            this.authors.Remove(author);
        }

        public async Task<Author?> FindAuthorByFullNameAsync(string firstName, string lastName)
        {
            return await this.authors
                .Where(author => author.FirstName.Equals(firstName) && author.LastName.Equals(lastName))
                .SingleOrDefaultAsync();
        }

        public async Task<Author> FindAuthorByIdSafeAsync(Guid id)
        {
            return await this.authors.FindAsync(id) ?? throw new NotFoundException("Author not found.");
        }

        public async Task<List<Author>> FindAuthorsByFirstNameAsync(string firstName)
        {
            return await this.authors
                .Where(author => author.FirstName.Equals(firstName))
                .ToListAsync();
        }

        public async Task<List<Author>> FindAuthorsByLastNameAsync(string lastName)
        {
            return await this.authors
                .Where(author => author.LastName.Equals(lastName))
                .ToListAsync();
        }

        public async Task<List<Author>> GetAuthorsPaginatedAsync(int page, int size)
        {
            return await this.authors
                .Skip((page - 1) * size)
                .Take(size)
                .OrderBy(author => author.LastName)
                .ThenBy(author => author.FirstName)
                .ToListAsync();
        }

        public Author UpdateAuthor(Author author)
        {
            this.authors.Update(author);

            return author;
        }
    }
}