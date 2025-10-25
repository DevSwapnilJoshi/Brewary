using EGlossary.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGlossary.Domain.InterfaceReposistory
{
    public interface ICategoryReposistory
    {
        Task<IEnumerable<CategoryEntity>> GetCategories();
    }
}