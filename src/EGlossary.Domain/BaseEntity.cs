using System.ComponentModel.DataAnnotations;

namespace EGlossary.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}