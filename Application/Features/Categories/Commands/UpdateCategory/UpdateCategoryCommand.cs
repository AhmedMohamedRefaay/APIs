using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain;
namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { set; get; }

        public string NameArabic { set; get; }
        public string? Images { set; get; }
        public Category? ParentCategory { set; get; }
        public UpdateCategoryCommand(int id, string name,string nameArabic, string? images)
        {
            Id = id;
            NameArabic = nameArabic;
            Name = name;
            Images = images;
            
        }

        

       

        
    }
}
