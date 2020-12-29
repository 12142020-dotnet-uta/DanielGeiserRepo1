using System.ComponentModel.DataAnnotations;

namespace Alt_project0
{
    public class Product
    {
        [Key]
        public int productId {get; set;}
        [Required]
        public string productName {get; set;}
        [Required]
        public double price {get; set;}
        public string description {get; set;}
    }
}