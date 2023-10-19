using MediatR;

namespace InfoShare_CQRS.Mediatr.Events
{
    public class BrandCreatedEvent : INotification
    {
        public string Name { get; set; }
    }
}
