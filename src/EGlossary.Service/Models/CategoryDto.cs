using EGlossary.Domain.Entities;
using System.Collections.Generic;

namespace EGlossary.Service.Models
{
    public class CategoryDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}