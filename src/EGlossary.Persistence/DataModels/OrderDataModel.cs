using EGlossary.Domain;
using System;
using System.Collections.Generic;

namespace EGlossary.Persistence.DataModels
{
    public class OrderDataModel : BaseEntity
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderFulfillmentDate { get; set; }
        public List<ProductDataModel> ProductDetails { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}