using InfoShare_CQRS.Data.Entities;
using InfoShare_CQRS.Data.Repositories;
using InfoShare_CQRS.Mediatr.Queries;
using MediatR;

namespace InfoShare_CQRS.Mediatr.Handlers
{
    public class GetAllBrandHandler : IRequestHandler<GetAllBrandQuery, IList<Brand>>
    {
        private readonly IReadRepository<Brand> _repository;

        public GetAllBrandHandler(IReadRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<IList<Brand>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
