using InfoShare_CQRS.Data.Entities;
using MediatR;

namespace InfoShare_CQRS.Mediatr.Queries
{
    public class GetAllBrandQuery : IRequest<IList<Brand>>
    {
    }
}
