using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsCategory.EF.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Title { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [ForeignKey("Cat")]
        public int C_Id { get; set; }
        public virtual Category Cat { get; set; }

    }
}
