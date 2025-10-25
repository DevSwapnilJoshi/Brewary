using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.ProductsFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<ProductEntity>
    {
        public int Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductEntity>
        {
            private readonly IProductReposistory _context;

            public GetProductByIdQueryHandler(IProductReposistory context)
            {
                _context = context;
            }

            public async Task<ProductEntity> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.GetProductById(request.Id);
            }
        }
    }
}