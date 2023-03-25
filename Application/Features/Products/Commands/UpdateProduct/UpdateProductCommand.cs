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
        public long Id { set; get; }
        public string Name { set; get; }

        public string NameArabic { set; get; }
        public string Image { set; get; }

        public int? Discount { set; get; }
        public string Description { set; get; }

        public string DescriptionArabic { set; get; }
        
        public float Price { set; get; }
        public UpdateProductCommand(long Id,string Name, string NameArabic, string DescriptionArabic,
            int? Discount, string Description,   string Image,float Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.NameArabic = NameArabic;
            this.DescriptionArabic = DescriptionArabic;
            this.Discount = Discount;
            this.Description = Description;
            this.Image = Image;
            this.Price = Price;

        }
    }
}
