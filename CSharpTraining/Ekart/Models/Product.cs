using System.ComponentModel.DataAnnotations;

namespace Ekart.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Category")]
        public int CatagoryId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
