using System;
using System.Collections.Generic;

namespace EGlossary.Domain.Entities
{
    public class OrderEntity : BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderFulfillmentDate { get; set; }
        public List<ProductEntity> ProductDetails { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}