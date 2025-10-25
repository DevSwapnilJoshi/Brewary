using EGlossary.BusinessLayer.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace EGlossary.BusinessLayer.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        [Column(TypeName = "Price")]
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