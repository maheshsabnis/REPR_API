using System.ComponentModel.DataAnnotations;

namespace REPR_API.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage ="Category Id is required")]
        public string CategoryId { get; set; } = null!;
        [Required(ErrorMessage = "Category Name is required")]
        public string CategoryName { get; set; } = null!;
        [Required(ErrorMessage = "Base Price is required")]
        public int BasePrice { get; set; }
    }
}
