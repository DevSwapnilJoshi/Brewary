using AutoMapper;
using EGlossary.Domain.Entities;
using EGlossary.Domain.InterfaceReposistory;
using EGlossary.Persistence.DataModels;
using EGlossary.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGlossary.Persistence.Reposistory
{
    public class ProductReposistory : IProductReposistory
    {
        private readonly InMemoryDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductReposistory(InMemoryDbContext inMemoryDbContext, IMapper mapper)
        {
            _dbContext = inMemoryDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            _ = GetProductInMemory();
            var products = await _dbContext.Product.ToListAsync();
            return _mapper.Map<IEnumerable<ProductEntity>>(products);
        }

        public async Task<int> CreateProducts(ProductEntity productEntity)
        {
            var product = _mapper.Map<ProductDataModel>(productEntity);
            _dbContext.Product.AddRange(product);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductEntity> GetProductById(int Id)
        {
            _ = GetProductInMemory();
            var product = await _dbContext.Product.Where(p => p.Id == Id).FirstOrDefaultAsync();
            return _mapper.Map<ProductEntity>(product);
        }

        public async Task GetProductInMemory()
        {
            await ProductsSeedData.Seed(_dbContext).ConfigureAwait(false);
        }
    }
}