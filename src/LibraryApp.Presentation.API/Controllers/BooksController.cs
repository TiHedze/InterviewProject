namespace LibraryApp.Presentation.API.Controllers
{
    using LibraryApp.Application.Authors.Commands.AddBook;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class BooksController : BaseController
    {
        public BooksController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddBookCommand request)
        {
            return await this.ProcessAsync(request);
        }

        [HttpGet]
        public Task<IActionResult> GetBooks()
        {
            throw new NotImplementedException();
        }

    }
}