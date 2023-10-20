using MediatR;

namespace InfoShare_CQRS.Mediatr.Events
{
    public class BrandCreatedEvent : INotification
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
