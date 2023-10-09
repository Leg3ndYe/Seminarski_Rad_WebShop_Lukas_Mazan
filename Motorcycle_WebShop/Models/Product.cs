using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Motorcycle_WebShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "Title is required")]
        [StringLength(250, MinimumLength = 5)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Column(TypeName = "decimal(9,2)")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }

        [ForeignKey("ProductId")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
