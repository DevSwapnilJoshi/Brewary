using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.BreweryFeatures.Queries;

public class GetBreweryByNameQuery : IRequest<BreweryEntity>
{
    public string Name { get; set; }

    public class GetBreweryByNameQueryHandler : IRequestHandler<GetBreweryByNameQuery, BreweryEntity>
    {
        private readonly IBreweryReposistory _context;

        public GetBreweryByNameQueryHandler(IBreweryReposistory context)
        {
            _context = context;
        }

        public async Task<BreweryEntity> Handle(GetBreweryByNameQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetBreweryByName(request.Name);
        }
    }
}
