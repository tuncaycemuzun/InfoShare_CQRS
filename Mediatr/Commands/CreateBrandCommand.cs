using InfoShare_CQRS.Data.Entities;
using MediatR;

namespace InfoShare_CQRS.Mediatr.Commands
{
    public class CreateBrandCommand : IRequest<Brand>
    {
        public string Name { get; set; }
    }
}
