using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDto.CategoryDto;
using Domain;
using MediatR;
namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCaommand : IRequest<bool>
    {

        public string Name { set; get; }

        public string NameArabic { set; get; }
        public int? ParentCategory { set; get; }

       
        public string image{ set; get; }

        public CreateCategoryCaommand(string Name,string NameArabic,int? ParentCategory,string image)
        {
            this.NameArabic = NameArabic;
            this.Name = Name;
            this.ParentCategory = ParentCategory;
            this.image = image;
        }

       
    }
}
