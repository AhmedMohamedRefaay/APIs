using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace ModelDto.CategoryDto
{
    public class MinimalCategoryDetails : MinimalProductDto
    {
        public Category ?parentCategory { get; set; }

        public IEnumerable<Category> ?Subcategories { set; get; }
        public Images ?Image { get; set; }
    }
}
