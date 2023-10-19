using InfoShare_CQRS.Data.Contexts;
using InfoShare_CQRS.Data.Entities;
using InfoShare_CQRS.Mediatr.Events;
using MediatR;

namespace InfoShare_CQRS.Mediatr.EventHandlers
{
    public class BrandCreatedEventHandler : INotificationHandler<BrandCreatedEvent>
    {
        private readonly ReadDbContext _context;

        public BrandCreatedEventHandler(ReadDbContext context)
        {
            _context = context;
        }

        public async Task Handle(BrandCreatedEvent notification, CancellationToken cancellationToken)
        {
            await _context.Set<Brand>().AddAsync(new Brand
            {
                Name = notification.Name,
            });

            await _context.SaveChangesAsync();
        }
    }
}
