using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EGlossary.Service.Features.CategoryFeatures.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryEntity>>
    {
        public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryEntity>>
        {
            private readonly ICategoryReposistory _context;

            public GetAllCategoryQueryHandler(ICategoryReposistory context)
            {
                _context = context;
            }

            public async Task<IEnumerable<CategoryEntity>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var response = await _context.GetCategories();
                if (response.Any())
                    return response;
                else return null;
            }
        }
    }
}