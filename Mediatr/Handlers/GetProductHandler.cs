using InfoShare_CQRS.Data.Entities;
using InfoShare_CQRS.Data.Repositories;
using InfoShare_CQRS.Mediatr.Queries;
using MediatR;

namespace InfoShare_CQRS.Mediatr.Handlers
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, Product?>
    {
        private readonly IReadRepository<Product> _repository;

        public GetProductHandler(IReadRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Product?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _repository.FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
