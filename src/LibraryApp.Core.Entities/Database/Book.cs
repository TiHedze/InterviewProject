namespace LibraryApp.Core.Entities.Database
{
    using System;

    public class Book
    {
        protected Book()
        { }

        public Book(
            string title,
            Guid authorId)
        {
            this.Title = title;
            this.AuthorId = authorId;
        }

        public Guid Id { get; protected set; }

        public Guid AuthorId { get; protected set; }

        public string Title { get; protected set; } = string.Empty;

        public void ChangeTitle(string title)
        {
            this.Title = title;
        }

        public void ChangeAuthor(Guid authorId)
        {
            this.AuthorId = authorId;
        }
    }
}