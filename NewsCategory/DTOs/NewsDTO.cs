using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsCategory.DTOs
{
    public class NewsDTO
    {
        public int Id { get; set; }
        [Required]
        
        public string Title { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public int C_Id { get; set; }
    }
}
