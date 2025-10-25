using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.ProductsFeatures.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductEntity>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductEntity>>
        {
            private readonly IProductReposistory _context;

            public GetAllProductQueryHandler(IProductReposistory context)
            {
                _context = context;
            }

            public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                return await _context.GetProducts();
            }
        }
    }
}