using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyWeb_razor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category List")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display name must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
