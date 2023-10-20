using InfoShare_CQRS.Data.Entities;
using InfoShare_CQRS.Data.Repositories;
using InfoShare_CQRS.Mediatr.Commands;
using InfoShare_CQRS.Mediatr.Events;
using MediatR;

namespace InfoShare_CQRS.Mediatr.Handlers
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand, Brand>
    {
        private readonly IWriteRepository<Brand> _repository;
        private readonly IMediator _mediator;

        public CreateBrandHandler(IMediator mediator, IWriteRepository<Brand> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<Brand> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _repository.AddAsync(new Brand
            {
                Name = request.Name,
            });

            await _repository.SaveChangesAsync();

            var brandCreatedEvent = new BrandCreatedEvent
            {
                Id = brand.Id,
                Name = request.Name,
            };

            await _mediator.Publish(brandCreatedEvent);

            return brand;
        }
    }
}
