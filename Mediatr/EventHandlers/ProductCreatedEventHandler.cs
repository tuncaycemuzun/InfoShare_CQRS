using InfoShare_CQRS.Data.Contexts;
using InfoShare_CQRS.Data.Entities;
using InfoShare_CQRS.Data.Repositories;
using InfoShare_CQRS.Mediatr.Events;
using MediatR;

namespace InfoShare_CQRS.Mediatr.EventHandlers
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ReadDbContext _context;

        public ProductCreatedEventHandler(ReadDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {

            await _context.Set<Product>().AddAsync(new Product
            {
                Id = notification.ProductId,
                Name = notification.Name,
                Price = notification.Price,
                BrandId = notification.BrandId
            });

            await _context.SaveChangesAsync();
        }
    }
}
