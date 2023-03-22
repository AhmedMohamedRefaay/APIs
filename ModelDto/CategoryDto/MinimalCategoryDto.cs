using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.CategoryDto
{
    public class MinimalProductDto
    {
        
        public int Id { get; set; }
        [MinLength(3), MaxLength(10)]
        public string ?Name { get; set; }

       
    }
}
 