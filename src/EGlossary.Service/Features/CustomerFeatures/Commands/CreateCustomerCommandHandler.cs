using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Service.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.CustomerFeatures.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CustomerDto, int>
    {
        private readonly ICustomerReposistory _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerReposistory context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(CustomerDto request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<CustomerEntity>(request);
            return await _context.CreateCustomer(customer);
        }
    }
}