using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace AdminDashBoard.Models
{
    public class test
    {
        

            public string Name { set; get; }

            public string NameArabic { set; get; }


            public int? Discount { set; get; }
            public string Description { set; get; }

            public int AvailUnit { set; get; }
            public string DescriptionArabic { set; get; }
        [Display(Name = "Category")]
        public int CategoryId { set; get; }
        public SelectList category { set; get; }
        public IFormFile file { set; get; }
            public float Price { set; get; }
        }
}
