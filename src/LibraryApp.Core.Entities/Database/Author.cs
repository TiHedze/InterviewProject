namespace LibraryApp.Core.Entities.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Author
    {
        protected Author()
        { }

        public Author(string firstName, string lastName)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; } = string.Empty;

        public string LastName { get; protected set; } = string.Empty;

        public ICollection<Book> Books { get; protected set; } = new List<Book>();

        public void AddBook(string title)
        {
            if (!this.Books.Any(book => book.Title == title))
            {
                this.Books.Add(new Book(title, this.Id));
            }
        }

        public void RemoveBook(Guid bookId)
        {
            var book = this.Books.FirstOrDefault(book => book.Id.Equals(bookId));

            if (book is null)
            {
                return;
            }

            this.Books.Remove(book);
        }

        public void ChangeName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}