using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Service.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.OrderFeatures.Commands
{
    public class UpdateOrderCommand : IRequestHandler<OrderDto, int>
    {
        private readonly IOrderReposistory _context;
        private readonly IMapper _mapper;

        public UpdateOrderCommand(IOrderReposistory context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(OrderDto request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<OrderEntity>(request);
            return await _context.UpdateOrder(request.OrderId, order);
        }
    }
}