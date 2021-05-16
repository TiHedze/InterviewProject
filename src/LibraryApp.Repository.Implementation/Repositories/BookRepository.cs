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

    public class BookRepository : IBookRepository
    {
        private readonly DbSet<Book> books;

        public BookRepository(LibraryContext context)
        {
            this.books = context.Set<Book>();
        }

        public Book AddBook(Book book)
        {
            this.books.Add(book);

            return book;
        }

        public void DeleteBook(Book book)
        {
            this.books.Remove(book);
        }

        public async Task<Book> FindBookByIdSafeAsync(Guid id)
        {
            return await this.books.FindAsync(id) ?? throw new NotFoundException("Book not found");
        }

        public async Task<List<Book>> FindBooksByTitleAsync(string title, int page, int size)
        {
            return await this.books
                .Where(book => book.Title.Contains(title))
                .Skip((page - 1) * size)
                .Take(size)
                .OrderBy(book => book.Title)
                .ToListAsync();
        }

        public async Task<List<Book>> GetBooksPaginatedAsync(int page, int size)
        {
            return await this.books
                .Skip((page - 1) * size)
                .Take(size)
                .OrderBy(book => book.Title)
                .ToListAsync();
        }

        public Book UpdateBook(Book book)
        {
            this.books.Update(book);

            return book;
        }
    }
}