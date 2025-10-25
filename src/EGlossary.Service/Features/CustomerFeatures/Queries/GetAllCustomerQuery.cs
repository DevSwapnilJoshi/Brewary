using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.CustomerFeatures.Queries
{
    public class GetAllCustomerQuery : IRequest<IEnumerable<CustomerEntity>>
    {
        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerEntity>>
        {
            private readonly ICustomerReposistory _context;

            public GetAllCustomerQueryHandler(ICustomerReposistory context)
            {
                _context = context;
            }

            public async Task<IEnumerable<CustomerEntity>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                var response = await _context.GetCustomers();
                if (response.Any())
                    return response;
                else return null;
            }
        }
    }
}