using System.ComponentModel.DataAnnotations;
namespace AdminDashBoard.Models
{
    public class Product
    {
        [Required]
        public string Name { set; get; }

        [Required]
        public string NameArabic { set; get; }
        [Required]
        public IFormFile Images { set; get; }
         
        public int? Discount { set; get; }
        [Required]
        public string Description { set; get; }

        [Required]
        public int AvailUnit { set; get; }
        [Required]
        public string DescriptionArabic { set; get; }
        [Required]
        public int CategoryId { set; get; }
        [Required]
        public float Price { set; get; }
    }
}
