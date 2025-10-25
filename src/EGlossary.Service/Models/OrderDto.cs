using EGlossary.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace EGlossary.Service.Models
{
    public class OrderDto : IRequest<int>
    {
        public int? OrderId { get; set; }
        public int? CustomerId { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherSeriesNumber { get; set; }
        public string OrderStatus { get; set; }
        public List<ProductEntity> Product { get; set; }
    }
}