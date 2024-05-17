using System.ComponentModel.DataAnnotations;

namespace REPR_API.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage ="Product Id is required")]
        public string? ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; } = null!;
        [Required(ErrorMessage = "Manufacturer is required")]
        public string Manufacturer { get; set; } = null!;
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Category Unique Id is required")]
        public int CategoryUniqueId { get; set; }
    }
}
