using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.OrderFeatures.Queries
{
    public class GetAllOrderQuery : IRequest<IEnumerable<OrderEntity>>
    {
        public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, IEnumerable<OrderEntity>>
        {
            private readonly IOrderReposistory _context;

            public GetAllOrderQueryHandler(IOrderReposistory context)
            {
                _context = context;
            }

            public async Task<IEnumerable<OrderEntity>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
            {
                var response = await _context.GetAllOrders();
                if (response.Any())
                    return response;
                else return null;
            }
        }
    }
}