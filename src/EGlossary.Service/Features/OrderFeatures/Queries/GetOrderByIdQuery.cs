using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.OrderFeatures.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderEntity>
    {
        public int Id { get; set; }

        public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderEntity>
        {
            private readonly IOrderReposistory _context;

            public GetOrderByIdQueryHandler(IOrderReposistory context)
            {
                _context = context;
            }

            public async Task<OrderEntity> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.GetOrderById(request.Id);
            }
        }
    }
}