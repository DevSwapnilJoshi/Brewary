using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Service.Features.CustomerFeatures.Queries;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace EGlossary.Service.Features.BreweryFeatures.Queries;

public class GetBreweryByIdQuery : IRequest<BreweryEntity>
{
    public Guid Id { get; set; }

    public class GetBreweryByIdQueryHandler : IRequestHandler<GetBreweryByIdQuery, BreweryEntity>
    {
        private readonly IBreweryReposistory _context;

        public GetBreweryByIdQueryHandler(IBreweryReposistory context)
        {
            _context = context;
        }

        public async Task<BreweryEntity> Handle(GetBreweryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetBreweryById(request.Id);
        }
    }
}
