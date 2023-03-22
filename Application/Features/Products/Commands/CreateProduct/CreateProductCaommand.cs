using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDto.CategoryDto;
using Domain;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCaommand:IRequest<bool>
    {

        public string Name { set; get; }

        public Images? Image { set; get; }

        public int ?Discount { set; get; }
        public   string Description { set; get; }
       

       public CreateProductCaommand(string name, int? discount, string description )
        {
           Name = name;
            Discount = discount;
           Description = description;
           
            
        }

         

        
    }
}
