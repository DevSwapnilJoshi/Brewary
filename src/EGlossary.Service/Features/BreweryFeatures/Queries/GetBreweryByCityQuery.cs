using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Collections.Generic;

namespace EGlossary.Service.Features.BreweryFeatures.Queries;

public class GetBreweryByCityQuery :  IRequest<IEnumerable<BreweryEntity>>
{
    public string City { get; set; }


    public class GetBreweryByCityQueryHandler : IRequestHandler<GetBreweryByCityQuery, IEnumerable<BreweryEntity>>
    {
        private readonly IBreweryReposistory _context;

        public GetBreweryByCityQueryHandler(IBreweryReposistory context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BreweryEntity>> Handle(GetBreweryByCityQuery request, CancellationToken cancellationToken)
        {
            return await _context.GetBreweryByCity(request.City);
        }
    }
}
