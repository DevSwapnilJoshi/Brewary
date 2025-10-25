using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EGlossary.Service.Features.BreweryFeatures.Queries
{
    public class SearchBreweryQuery : IRequest<IEnumerable<BreweryEntity>>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Phone { get; set; }
        public class SearchBreweryQueryHandler : IRequestHandler<SearchBreweryQuery, IEnumerable<BreweryEntity>>
        {
            private readonly IBreweryReposistory _context;

            public SearchBreweryQueryHandler(IBreweryReposistory context)
            {
                _context = context;
            }

            public async Task<IEnumerable<BreweryEntity>> Handle(SearchBreweryQuery request, CancellationToken cancellationToken)
            {
                var query = await _context.GetBreweries();
                if (!string.IsNullOrWhiteSpace(request.Name))
                    query = query.Where(b => b.Name.Contains(request.Name));
                if (!string.IsNullOrWhiteSpace(request.City))
                    query = query.Where(b => b.City == request.City);
                if (!string.IsNullOrWhiteSpace(request.State))
                    query = query.Where(b => b.State == request.State);
                if (!string.IsNullOrWhiteSpace(request.Type))
                    query = query.Where(b => b.BreweryType == request.Type);

                if (!string.IsNullOrWhiteSpace(request.Phone))
                    query = query.Where(b => b.BreweryType == request.Phone);
                return query;

            }
        }
    }
}
