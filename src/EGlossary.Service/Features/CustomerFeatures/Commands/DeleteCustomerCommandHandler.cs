using AutoMapper;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.CustomerFeatures.Commands
{
    public class DeleteCustomerCommandHandler : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerCommandHandler, bool>
        {
            private readonly ICustomerReposistory _context;
            private readonly IMapper _mapper;

            public DeleteCustomerByIdCommandHandler(ICustomerReposistory context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<bool> Handle(DeleteCustomerCommandHandler request, CancellationToken cancellationToken)
            {
                return await _context.DeleteCustomer(request.Id);
            }
        }
    }
}