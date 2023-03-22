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

        public Category ?ParentCategory { set; get; }

        public Images? image{ set; get; }

        public CreateCategoryCaommand(string Name,Category ParentCategory,Images images)
        {
            this.Name = Name;
            this.ParentCategory = ParentCategory;
            this.image = images;
        }

       
    }
}
