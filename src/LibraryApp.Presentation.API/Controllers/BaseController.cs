namespace LibraryApp.Presentation.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator mediator;

        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> ProcessAsync(IRequest request)
        {
            await this.mediator.Send(request);

            return this.NoContent();
        }

        protected async Task<IActionResult> ProcessAsync<TResult>(IRequest<TResult> request)
        {
            TResult result = await this.mediator.Send(request);

            return result is null ? this.NotFound() : (IActionResult)this.Ok(result);
        }
    }
}