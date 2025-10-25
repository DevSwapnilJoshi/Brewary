using EGlossary.Domain;
using System.Collections.Generic;

namespace EGlossary.Persistence.DataModels
{
    public class CategoryDataModel : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<ProductDataModel> Products { get; set; }
    }
}