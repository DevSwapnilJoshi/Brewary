using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Generic;

namespace EGlossary.Service.Features.BreweryFeatures.Queries;

public class GetBreweryByDistanceQuery :  IRequest<IEnumerable<BreweryEntity>>
{
    public double latitude { get; set; }
    public double longitude { get; set; }

    public class GetBreweryByDistanceQueryHandler : IRequestHandler<GetBreweryByDistanceQuery, IEnumerable<BreweryEntity>>
    {
        private readonly IBreweryReposistory _context;

        public GetBreweryByDistanceQueryHandler(IBreweryReposistory context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BreweryEntity>> Handle(GetBreweryByDistanceQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetBreweryByDistance(request.latitude,request.latitude);
        }
    }
}
