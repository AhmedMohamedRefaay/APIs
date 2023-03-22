using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace ModelDto.ProductDto
{
    public class MinimalProductDetails : MinimalProductDto
    {
        public Category ?category { get; set; }
        public int? CategoryId { set; get; }
        public int? Discount { get; set; }
       
        public Images ?Image { get; set; }
    }
}
