namespace LibraryApp.Presentation.API.Controllers
{
    using LibraryApp.Application.Authors.Commands.AddAuthor;
    using LibraryApp.Application.Authors.Commands.AddBook;
    using LibraryApp.Application.Authors.Commands.RemoveAuthor;
    using LibraryApp.Application.Authors.Commands.UpdateAuthor;
    using LibraryApp.Application.Authors.Queries.GetAuthorById;
    using LibraryApp.Application.Authors.Queries.GetAuthors;
    using LibraryApp.Application.Books.Commands.RemoveBook;
    using LibraryApp.Application.Books.Commands.UpdateBook;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class AuthorsController : BaseController
    {
        public AuthorsController(IMediator mediator) : base(mediator) { }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => await this.ProcessAsync(new GetAuthorByIdQuery(id));

        [HttpGet]
        public async Task<IActionResult> List(int page, int size) => await this.ProcessAsync(new GetAuthorsQuery(page, size));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddAuthorCommand request) => await this.ProcessAsync(request);

        [HttpPost("{id}/Book")]
        public async Task<IActionResult> PostBook([FromBody] AddBookCommand request) => await this.ProcessAsync(request);

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateAuthorCommand request) => await this.ProcessAsync(request);

        [HttpPut("{id}/Book/{bookId}")]
        public async Task<IActionResult> UpdateBook(Guid id, Guid bookId, [FromBody] UpdateBookCommand request) => await this.ProcessAsync(request);

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) => await this.ProcessAsync(new RemoveAuthorCommand(id));

        [HttpDelete("{id}/Book/{bookId}")]
        public async Task<IActionResult> DeleteBook(Guid id, Guid bookId) => await this.ProcessAsync(new RemoveBookCommand(id, bookId));
    }
}