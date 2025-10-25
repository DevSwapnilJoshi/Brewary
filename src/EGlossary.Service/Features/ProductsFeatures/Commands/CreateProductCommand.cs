using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Service.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.ProductsFeatures.Commands
{
    public class CreateProductCommand : IRequestHandler<ProductDto, int>
    {
        private readonly IProductReposistory _context;
        private readonly IMapper _mapper;

        public CreateProductCommand(IProductReposistory context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(ProductDto request, CancellationToken cancellationToken)
        {
            var AddProduct = _mapper.Map<ProductEntity>(request);
            return await _context.CreateProducts(AddProduct);
        }
    }
}