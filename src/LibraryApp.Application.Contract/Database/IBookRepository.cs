namespace LibraryApp.Application.Contract.Database
{
    using LibraryApp.Core.Entities.Database;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookRepository
    {
        Task<List<Book>> GetBooksPaginatedAsync(int page, int size);

        Task<Book> FindBookByIdSafeAsync(Guid id); 

        Task<List<Book>> FindBooksByTitleAsync(string title, int page, int size);

        Book AddBook(Book book);

        Book UpdateBook(Book book);

        void DeleteBook(Book book);
    }
}