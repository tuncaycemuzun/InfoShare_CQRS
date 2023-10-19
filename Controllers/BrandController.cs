using InfoShare_CQRS.Data.Entities;
using InfoShare_CQRS.Mediatr.Commands;
using InfoShare_CQRS.Mediatr.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoShare_CQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBrand(CreateBrandCommand command)
        {
            var brand = await _mediator.Send(command);
            return Ok(brand.Id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrands(Guid id)
        {
            var query = new GetAllBrandQuery();
            var brand = await _mediator.Send(query);

            if (brand == null)
                return NotFound();

            return Ok(brand);
        }
    }
}
