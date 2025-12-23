using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsCategory.DTOs
{
    public class CategoryDTO
    {
      
        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }
    }
}
