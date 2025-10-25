namespace EGlossary.BusinessLayer.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}