using MediatR;

namespace InfoShare_CQRS.Mediatr.Events
{
    public class ProductCreatedEvent : INotification
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid BrandId { get; set; }
    }
}
