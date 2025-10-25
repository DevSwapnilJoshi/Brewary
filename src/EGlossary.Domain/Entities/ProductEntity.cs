using EGlossary.Domain.Enum;
using System;

namespace EGlossary.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public Sizes Sizes { get; set; }
        public string SubCategory { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}