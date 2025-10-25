using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Persistence.Reposistory
{
    public class CategoryReposistory : ICategoryReposistory
    {
        private readonly InMemoryDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryReposistory(InMemoryDbContext inMemoryDbContext, IMapper mapper)
        {
            _dbContext = inMemoryDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategories()
        {
            _ = GetCategoryInMemory();
            var Categories = await _dbContext.Category.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryEntity>>(Categories);
        }

        public async Task GetCategoryInMemory()
        {
            await CategorySeedData.Seed(_dbContext).ConfigureAwait(false);
        }
    }
}