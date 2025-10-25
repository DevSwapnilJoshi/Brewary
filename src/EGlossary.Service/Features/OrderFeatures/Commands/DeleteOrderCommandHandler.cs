using AutoMapper;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.OrderFeatures.Commands
{
    public class DeleteOrderCommandHandler : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderCommandHandler, bool>
        {
            private readonly IOrderReposistory _context;
            private readonly IMapper _mapper;

            public DeleteOrderByIdCommandHandler(IOrderReposistory context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<bool> Handle(DeleteOrderCommandHandler request, CancellationToken cancellationToken)
            {
                return await _context.DeleteOrder(request.Id);
            }
        }
    }
}