using System.Collections.Generic;

namespace EGlossary.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}