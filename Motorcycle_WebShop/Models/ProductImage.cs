using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motorcycle_WebShop.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        public bool IsMainImage { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, MinimumLength = 5)]
        public string Title { get; set; }

        [Required(ErrorMessage = "File path is required")]
        [StringLength(500, MinimumLength = 5)]
        public string FilePath { get; set; }

        [NotMapped]
        public string ProductTitle { get; set; }
    }
}