using InfoShare_CQRS.Data.Entities;
using InfoShare_CQRS.Mediatr.Commands;
using InfoShare_CQRS.Mediatr.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoShare_CQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct(CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return Ok(productId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var query = new GetProductQuery { Id = id };
            var product = await _mediator.Send(query);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
