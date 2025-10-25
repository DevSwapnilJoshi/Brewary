using EGlossary.Domain.Enum;
using MediatR;

namespace EGlossary.Service.Models
{
    public class ProductDto : IRequest<int>
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public UnitOfMeasurement? UnitOfMeasurement { get; set; }
        public Sizes? Sizes { get; set; }
        public int? CategoryId { get; set; }
    }
}