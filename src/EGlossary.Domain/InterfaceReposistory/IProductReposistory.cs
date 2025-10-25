using EGlossary.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Domain.InterfaceReposistory
{
    public interface IProductReposistory
    {
        Task GetProductInMemory();

        Task<IEnumerable<ProductEntity>> GetProducts();

        Task<ProductEntity> GetProductById(int Id);

        Task<int> CreateProducts(ProductEntity product);
    }
}