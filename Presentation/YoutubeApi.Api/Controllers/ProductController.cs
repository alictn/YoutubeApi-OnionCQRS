using MediatR;
using Microsoft.AspNetCore.Mvc;
using YoutubeApi.Application.Features.Query.GetAllProducts;

namespace YoutubeApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var response = await mediator.Send(new GetAllProductQueryRequest());

            return Ok(response);
        }
    }
}
