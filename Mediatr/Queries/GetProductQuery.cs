using InfoShare_CQRS.Data.Entities;
using MediatR;

namespace InfoShare_CQRS.Mediatr.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}
