using InfoShare_CQRS.Data.Entities;
using InfoShare_CQRS.Data.Repositories;
using InfoShare_CQRS.Mediatr.Commands;
using InfoShare_CQRS.Mediatr.Events;
using MediatR;

namespace InfoShare_CQRS.Mediatr.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IWriteRepository<Product> _repository;
        private readonly IMediator _mediator;

        public CreateProductHandler(IWriteRepository<Product> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.AddAsync(new Product
            {
                Name = request.Name,
                Price = request.Price
            });

            var productCreatedEvent = new ProductCreatedEvent
            {
                ProductId = product.Id,
                Name = request.Name,
                Price = request.Price
            };

            await _mediator.Publish(productCreatedEvent);

            return product;
        }

    }
}
