using InfoShare_CQRS.Data.Entities;
using MediatR;

namespace InfoShare_CQRS.Mediatr.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
