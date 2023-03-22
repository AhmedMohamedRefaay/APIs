using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain;
namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { set; get; }

        public string Discription { set; get; }
        public int? Discount { set; get; }
        public Images? Images { set; get; }
        public Category? ParentCategory { set; get; }
      
        public UpdateProductCommand(long id, string name, string discription, int? discount)
        {
            Id = id;
            Name = name;
            Discription = discription;
            Discount = discount;
         
        }
    }
}
