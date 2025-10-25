using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.BreweryFeatures.Queries;

public class GetAllBreweryQuery : IRequest<IEnumerable<BreweryEntity>>
{
    public class GetAllBreweryQueryHandler : IRequestHandler<GetAllBreweryQuery, IEnumerable<BreweryEntity>>
    {
        private readonly IBreweryReposistory _context;

        public GetAllBreweryQueryHandler(IBreweryReposistory context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BreweryEntity>> Handle(GetAllBreweryQuery request, CancellationToken cancellationToken)
        {
            var response = await _context.GetBreweries();
            if (response.Any())
                return response;
            else return null;
        }
    }
}