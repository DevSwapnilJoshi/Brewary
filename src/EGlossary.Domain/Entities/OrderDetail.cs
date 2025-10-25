using System;

namespace EGlossary.Domain.Entities
{
    public class OrderDetails : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public OrderEntity Orders { get; set; }
        public ProductEntity Product { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}