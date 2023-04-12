using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace ModelDto.CategoryDto
{
    public class MinimalCategoryDetails : MinimalCategoryDto
    {
        

         
        public IEnumerable<Category> ?Subcategories { set; get; }
    
    }
}
