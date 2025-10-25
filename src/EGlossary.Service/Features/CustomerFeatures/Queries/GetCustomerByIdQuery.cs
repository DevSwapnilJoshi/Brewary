using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.CustomerFeatures.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerEntity>
    {
        public int Id { get; set; }

        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerEntity>
        {
            private readonly ICustomerReposistory _context;

            public GetCustomerByIdQueryHandler(ICustomerReposistory context)
            {
                _context = context;
            }

            public async Task<CustomerEntity> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
            {
                return await _context.GetCustomerById(request.Id);
            }
        }
    }
}